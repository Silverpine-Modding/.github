# Silverpine mod version catalog

[Public JSON](https://raw.githubusercontent.com/Silverpine-Modding/.github/main/versions.json)
is consumed by the optional
[Mod Update Checker](https://github.com/Silverpine-Modding/Silverpine-Saelac-ModUpdateChecker).
Modding Tools itself stays offline.

The schemaVersion 1 document contains:

- generatedAt: UTC time when catalog content last changed.
- mods: one entry per public mod repository, with repository/name/description,
  active/obsolete/archived/unreleased status, releaseTag, releaseUrl and publishedAt.
- components: actual BepInEx GUID/name/version metadata, or assembly-prefixed
  identities and CLR assembly versions for preloader patchers. A repository
  can contain multiple identities (compatibility aliases or bundled addons).
- dependencies: BepInDependency GUIDs, minimum versions and optional flags
  extracted from the released plugin.
- replacementRepository, replacementMinimumVersion and notes for obsolete mods.

Versions come from released binaries, not README text or unreleased source.
Three- and four-component numeric versions compare with missing fields set to
zero. Release tags are display labels, not the comparison input.
No authentication is needed by players. Their installed list stays local.
SILC Studio is a standalone executable and is deliberately excluded.

## Refreshing

The **Refresh mod version catalog** workflow runs every six hours, on manual
workflow dispatch, on repository_dispatch type refresh-catalog, and when its
builder/configuration changes. GitHub schedules can be delayed; maintainers
can run the workflow immediately after publishing a release. Public-repository
schedules may be disabled by GitHub after prolonged repository inactivity;
re-enable the workflow in Actions when needed.

The builder enumerates all public Silverpine-Modding repositories and uses
GitHub's latest stable release endpoint. It inspects standalone DLLs and the
primary ZIP without executing them. It discovers additional bundled plugin
identities, deduplicates matching DLL/ZIP metadata, excludes bundled copies
of the shared framework, and fails on conflicting identities.
Standalone utilities must be marked kind: tool in catalog-overrides.json.
New mod repositories are picked up automatically.

Run locally with .NET 9 or newer:

    dotnet run --project tools/CatalogBuilder -c Release -- .

For an authenticated GitHub API allowance, set GH_TOKEN in the process
environment using your credential manager. Never commit a token. The workflow
uses its repository-scoped GITHUB_TOKEN. Tokens are sent only to api.github.com,
not release download hosts, and are never part of the public catalog.

Publish assets before refreshing (draft releases are convenient for this).
Keep a primary mod ZIP with a matching DLL basename when a release has other
ZIPs. Ambiguous ZIPs, missing assets, unreadable metadata, request failures,
conflicting component identities and mismatched standalone/ZIP versions fail
the run **without replacing the previous catalog**. Mark tool/obsolete policies
explicitly in catalog-overrides.json; the builder does not guess obsolescence
from release-note prose. The optional assemblies array can restrict an entry
to specific DLL filenames when a package contains unrelated plugins.

If no stable release exists the repository is marked unreleased, with no
component mapping. Failed/unloaded local plugins remain outside the checker's
loaded-plugin inventory. Do not report missing catalog matches as current.

The organization homepage is curated separately; catalog refreshes do not
rewrite its project summaries.
