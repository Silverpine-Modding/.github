using System.IO.Compression;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Text.Json;
using System.Text.Json.Nodes;

const string org = "Silverpine-Modding";
string root = args.Length > 0 ? Path.GetFullPath(args[0]) : Directory.GetCurrentDirectory();
var options = new JsonSerializerOptions { WriteIndented = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
var overrides = JsonNode.Parse(File.ReadAllText(Path.Combine(root, "catalog-overrides.json")))!.AsObject();
using var api = new HttpClient { BaseAddress = new Uri("https://api.github.com/"), Timeout = TimeSpan.FromSeconds(90) };
api.DefaultRequestHeaders.UserAgent.ParseAdd("Silverpine-Version-Catalog/1.0");
api.DefaultRequestHeaders.Accept.ParseAdd("application/vnd.github+json");
api.DefaultRequestHeaders.Add("X-GitHub-Api-Version", "2022-11-28");
string? token = Environment.GetEnvironmentVariable("GH_TOKEN");
if (!string.IsNullOrEmpty(token)) api.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
// Never send a GitHub token to an asset CDN.
using var download = new HttpClient { Timeout = TimeSpan.FromMinutes(3) };
download.DefaultRequestHeaders.UserAgent.ParseAdd("Silverpine-Version-Catalog/1.0");
var repos = new List<JsonNode>();
for (int page = 1; ; page++)
{
    var batch = (await GetJson($"orgs/{org}/repos?type=public&per_page=100&page={page}"))!.AsArray();
    repos.AddRange(batch.Select(x => x!));
    if (batch.Count < 100) break;
}
var mods = new JsonArray();
var identities = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
foreach (var repo in repos.Where(r => S(r, "name") != ".github").OrderBy(r => S(r, "name"), StringComparer.OrdinalIgnoreCase))
{
    string name = S(repo, "name"), fullName = S(repo, "full_name");
    JsonNode? policy = overrides[name];
    if (policy?["kind"]?.GetValue<string>() == "tool") { Console.WriteLine(name + ": standalone tool, excluded"); continue; }
    var release = await GetJson($"repos/{fullName}/releases/latest", allow404: true);
    var entry = new JsonObject
    {
        ["repository"] = fullName, ["name"] = name.Replace("Silverpine-Saelac-", "", StringComparison.OrdinalIgnoreCase),
        ["description"] = S(repo, "description"), ["repositoryUrl"] = S(repo, "html_url"),
        ["status"] = policy?["status"]?.GetValue<string>() ?? (repo["archived"]!.GetValue<bool>() ? "archived" : "active"),
        ["kind"] = policy?["kind"]?.GetValue<string>() ?? "mod",
        ["notes"] = policy?["notes"]?.DeepClone(), ["replacementRepository"] = policy?["replacementRepository"]?.DeepClone(),
        ["replacementMinimumVersion"] = policy?["replacementMinimumVersion"]?.DeepClone(),
        ["releaseTag"] = release?["tag_name"]?.DeepClone(), ["releaseUrl"] = release?["html_url"]?.DeepClone(),
        ["publishedAt"] = release?["published_at"]?.DeepClone(), ["version"] = null,
        ["components"] = new JsonArray()
    };
    if (release == null)
    {
        entry["status"] = "unreleased";
        Console.WriteLine(name + ": no stable release");
    }
    else if (entry["kind"]!.GetValue<string>() == "tool")
        entry["version"] = S(release, "tag_name").TrimStart('v', 'V');
    else
    {
        var assets = release["assets"]!.AsArray().Select(x => x!).ToArray();
        var dlls = assets.Where(a => S(a, "name").EndsWith(".dll", StringComparison.OrdinalIgnoreCase)).ToArray();
        var files = new List<(string Name, byte[] Bytes)>();
        foreach (var asset in dlls) files.Add((S(asset, "name"), await Download(asset)));
        var zips = assets.Where(a => S(a, "name").EndsWith(".zip", StringComparison.OrdinalIgnoreCase)).ToArray();
        if (zips.Length > 1)
            zips = zips.Where(a => dlls.Any(d => S(a, "name").StartsWith(Path.GetFileNameWithoutExtension(S(d, "name")) + "-", StringComparison.OrdinalIgnoreCase))).ToArray();
        if (zips.Length > 1 || (zips.Length == 0 && dlls.Length == 0))
            throw new InvalidDataException(name + ": select an unambiguous mod ZIP/DLL release asset before publishing the catalog.");
        if (zips.Length == 1)
        {
            using var zip = new ZipArchive(new MemoryStream(await Download(zips[0])));
            foreach (var file in zip.Entries.Where(e => e.Name.EndsWith(".dll", StringComparison.OrdinalIgnoreCase)))
            {
                if (file.Length > 32 * 1024 * 1024) throw new InvalidDataException("Oversized assembly: " + file.FullName);
                using var stream = file.Open(); using var bytes = new MemoryStream(); stream.CopyTo(bytes);
                files.Add((file.Name, bytes.ToArray()));
            }
        }
        var components = entry["components"]!.AsArray();
        foreach (var file in files)
        {
            if (file.Name.Equals("ModdingTools.dll", StringComparison.OrdinalIgnoreCase) && !name.EndsWith("Modding-Tools")) continue;
            if (policy?["assemblies"] is JsonArray allowed && !allowed.Any(a => a!.GetValue<string>().Equals(file.Name, StringComparison.OrdinalIgnoreCase))) continue;
            foreach (var component in Inspect(file.Bytes))
            {
                string id = S(component, "id");
                var duplicate = components.FirstOrDefault(c => S(c!, "id").Equals(id, StringComparison.OrdinalIgnoreCase));
                if (duplicate != null)
                {
                    if (!JsonNode.DeepEquals(duplicate, component)) throw new InvalidDataException(name + ": ZIP and DLL metadata disagree for " + id);
                    continue;
                }
                if (!identities.Add(id)) throw new InvalidDataException("Duplicate component identity: " + id);
                components.Add(component);
            }
        }
        if (components.Count == 0) throw new InvalidDataException(name + ": no plugin/patcher metadata in published assets.");
        entry["version"] = components[0]!["version"]!.DeepClone();
        entry["name"] = components[0]!["name"]!.DeepClone();
        Console.WriteLine($"{name}: {S(release, "tag_name")} / {components.Count} identities");
    }
    mods.Add(entry);
}
// Write only after every repository and asset has been read successfully.
var catalog = new JsonObject { ["schemaVersion"] = 1, ["generatedAt"] = DateTimeOffset.UtcNow.ToString("O"), ["mods"] = mods };
string destination = Path.Combine(root, "versions.json");
if (File.Exists(destination))
{
    var previous = JsonNode.Parse(File.ReadAllText(destination))!;
    if (JsonNode.DeepEquals(previous["mods"], mods)) { Console.WriteLine("Catalog already current."); return; }
}
File.WriteAllText(destination + ".tmp", catalog.ToJsonString(options) + "\n");
File.Move(destination + ".tmp", destination, overwrite: true);
Console.WriteLine($"Published metadata for {mods.Count} repositories ({identities.Count} component identities).");

async Task<JsonNode?> GetJson(string path, bool allow404 = false)
{
    using var response = await api.GetAsync(path);
    if (allow404 && response.StatusCode == HttpStatusCode.NotFound) return null;
    response.EnsureSuccessStatusCode();
    return JsonNode.Parse(await response.Content.ReadAsStringAsync());
}
async Task<byte[]> Download(JsonNode asset)
{
    if (asset["size"]!.GetValue<long>() > 64 * 1024 * 1024) throw new InvalidDataException("Oversized release asset.");
    return await download.GetByteArrayAsync(S(asset, "browser_download_url"));
}
static string S(JsonNode node, string key) => node[key]?.GetValue<string>() ?? "";

static IEnumerable<JsonObject> Inspect(byte[] bytes)
{
    using var pe = new PEReader(new MemoryStream(bytes));
    if (!pe.HasMetadata) yield break;
    var reader = pe.GetMetadataReader();
    var assembly = reader.GetAssemblyDefinition();
    string assemblyName = reader.GetString(assembly.Name);
    var plugins = new List<JsonObject>();
    bool patcher = false;
    foreach (var handle in reader.TypeDefinitions)
    {
        var type = reader.GetTypeDefinition(handle);
        var attributes = type.GetCustomAttributes().Select(h => reader.GetCustomAttribute(h)).ToArray();
        var plugin = attributes.Where(a => AttributeName(reader, a) == "BepInEx.BepInPlugin").ToArray();
        if (plugin.Length > 0)
        {
            var values = plugin[0].DecodeValue(new AttributeTypes()).FixedArguments;
            var dependencies = new JsonArray();
            foreach (var attr in attributes.Where(a => AttributeName(reader, a) == "BepInEx.BepInDependency"))
            {
                var args = attr.DecodeValue(new AttributeTypes()).FixedArguments;
                bool soft = args.Length > 1 && args[1].Value is int flags && (flags & 2) != 0;
                dependencies.Add(new JsonObject { ["id"] = (string)args[0].Value!,
                    ["minimumVersion"] = args.Length > 1 ? args[1].Value as string : null, ["optional"] = soft });
            }
            plugins.Add(new JsonObject { ["id"] = (string)values[0].Value!, ["name"] = (string)values[1].Value!,
                ["version"] = (string)values[2].Value!, ["assembly"] = assemblyName, ["kind"] = "plugin", ["dependencies"] = dependencies });
        }
        if (type.GetMethods().Any(m => reader.GetString(reader.GetMethodDefinition(m).Name) == "Patch") &&
            type.GetProperties().Any(p => reader.GetString(reader.GetPropertyDefinition(p).Name) == "TargetDLLs")) patcher = true;
    }
    foreach (var plugin in plugins) yield return plugin;
    if (plugins.Count == 0 && patcher)
        yield return new JsonObject { ["id"] = "assembly:" + assemblyName, ["name"] = assemblyName,
            ["version"] = assembly.Version.ToString(), ["assembly"] = assemblyName, ["kind"] = "patcher", ["dependencies"] = new JsonArray() };
}
static string AttributeName(MetadataReader reader, CustomAttribute attribute)
{
    if (attribute.Constructor.Kind != HandleKind.MemberReference) return "";
    var parent = reader.GetMemberReference((MemberReferenceHandle)attribute.Constructor).Parent;
    if (parent.Kind != HandleKind.TypeReference) return "";
    var type = reader.GetTypeReference((TypeReferenceHandle)parent);
    return reader.GetString(type.Namespace) + "." + reader.GetString(type.Name);
}
sealed class AttributeTypes : ICustomAttributeTypeProvider<string>
{
    public string GetPrimitiveType(PrimitiveTypeCode code) => code.ToString();
    public string GetSystemType() => "System.Type";
    public bool IsSystemType(string type) => type == "System.Type";
    public string GetSZArrayType(string elementType) => elementType + "[]";
    public string GetTypeFromDefinition(MetadataReader reader, TypeDefinitionHandle handle, byte rawTypeKind) => reader.GetString(reader.GetTypeDefinition(handle).Name);
    public string GetTypeFromReference(MetadataReader reader, TypeReferenceHandle handle, byte rawTypeKind) => reader.GetString(reader.GetTypeReference(handle).Name);
    public string GetTypeFromSerializedName(string name) => name;
    public PrimitiveTypeCode GetUnderlyingEnumType(string type) => PrimitiveTypeCode.Int32;
}
