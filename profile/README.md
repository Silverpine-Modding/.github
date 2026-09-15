# Silverpine Modding

Plugins, content tools, and gameplay extensions for **Silverpine**, created by **Saelac with ChatGPT**.

Build custom worlds, create items and characters, expand conversations, and tailor the game to your playthrough. Browse **46 public plugin and patcher repositories** below. Each plugin name opens its repository; **Releases** opens its download page.

[Get started](#get-started) · [Framework and utilities](#framework-and-utilities) · [Conversations and companions](#conversations-and-companions) · [NPCs, relationships, and routines](#npcs-relationships-and-routines)

[Items, equipment, and crafting](#items-equipment-and-crafting) · [Worlds, building, and enemies](#worlds-building-and-enemies) · [Player characters and artwork](#player-characters-and-artwork) · [AI and dialogue settings](#ai-and-dialogue-settings) · [Fixes and preloader patchers](#fixes-and-preloader-patchers)

## Get started

1. **Check the plugin's requirements.** These projects target Silverpine 1.7.3 and BepInEx 5; each repository documents its dependencies and installation steps.
2. **Install [Modding Tools](https://github.com/Silverpine-Modding/Silverpine-Saelac-Modding-Tools/releases) when required.** It provides the shared menus and services used by many plugins. Use the version required by your chosen plugins and keep one shared copy of `ModdingTools.dll` and its supplied `Newtonsoft.Json.dll`.
3. **Download from the project's Releases page** and follow its package layout. Runtime plugins go under `BepInEx/plugins/`; preloader patchers go under `BepInEx/patchers/`. Close the game before installing and restart afterward.
4. **Open the plugin's controls.** Many tools appear in the main-menu **Modding Tools** menu or the in-game inventory **Mods** tab. Individual repositories explain other menus, actions, and configuration files.

## Framework and utilities

| Plugin | What it does | Downloads |
| --- | --- | --- |
| [Modding Tools](https://github.com/Silverpine-Modding/Silverpine-Saelac-Modding-Tools) | Shared framework for mod menus, UI, persistent objects, construction, audio, and dialogue integration, with a configurable construction shortcut (**B** by default). Required by many plugins. | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-Modding-Tools/releases) |
| [BepInEx Folder Warnings](https://github.com/Silverpine-Modding/Silverpine-Saelac-BepInExFolderWarnings) | Detects plugin DLLs placed in the patchers folder, or patchers placed in the plugins folder, and logs instructions for correcting them. | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-BepInExFolderWarnings/releases) |
| [Salt Extra Debug](https://github.com/Silverpine-Modding/Silverpine-Saelac-SaltExtraDebug) | Enables the debug menu and adds persistent gameplay controls, including free building, construction overrides, stat toggles, and NPC utilities. | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-SaltExtraDebug/releases) |

## Conversations and companions

| Plugin | What it does | Downloads |
| --- | --- | --- |
| [Arrival Meetings](https://github.com/Silverpine-Modding/Silverpine-Saelac-ArrivalMeetings) | Travel to rooms grouped by property owner and choose arrival guests. Add nearby NPCs or remove current participants without traveling, with generated greetings and farewells. | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-ArrivalMeetings/releases) |
| [Conversation Observer](https://github.com/Silverpine-Modding/Silverpine-Saelac-ConversationObserver) | Use **Step Away** to let NPCs continue talking to one another, then **Interrupt** to rejoin the conversation. | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-ConversationObserver/releases) |
| [Conversation Participant Picker](https://github.com/Silverpine-Modding/Silverpine-Saelac-ConversationParticipantPicker) | Choose which nearby, visible NPCs join a new conversation, including conversations with multiple participants. | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-ConversationParticipantPicker/releases) |
| [Follow NPC](https://github.com/Silverpine-Modding/Silverpine-Saelac-FollowNPC) | Ask an NPC to lead you somewhere, automatically follow them on foot, and resume the conversation when you arrive. | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-FollowNPC/releases) |
| [Instant Dialogue Patcher](https://github.com/Silverpine-Modding/Silverpine-Saelac-InstantDialoguePatcher) | Displays completed dialogue immediately instead of revealing it character by character, while preserving names, formatting, and pagination. **Preloader patcher.** | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-InstantDialoguePatcher/releases) |
| [Monster Dialogue](https://github.com/Silverpine-Modding/Silverpine-Saelac-MonsterDialogue) | Talk to monsters and animals through native neural dialogue, with editable personalities, portraits, shared memories during tile visits, and mixed NPC groups. | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-MonsterDialogue/releases) |
| [Salt Dialogue Impersonator](https://github.com/Silverpine-Modding/Silverpine-Saelac-SaltDialogueImpersonator) | Choose a conversation participant and author an NPC dialogue turn under their name, with the game's normal NPC response checks. | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-SaltDialogueImpersonator/releases) |
| [Toggle Follower](https://github.com/Silverpine-Modding/Silverpine-Saelac-ToggleFollower) | Make a nearby NPC follow you or stop following through the Actions menu or radial wheel, restoring their previous routine when toggled off. | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-ToggleFollower/releases) |

## NPCs, relationships, and routines

| Plugin | What it does | Downloads |
| --- | --- | --- |
| [Acacia Unlocked](https://github.com/Silverpine-Modding/Silverpine-Saelac-AcaciaUnlocked) | Expands Acacia's resident, conversation, movement, and routine behavior after she joins the player. | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-AcaciaUnlocked/releases) |
| [Custom NPC Knowledge Variables](https://github.com/Silverpine-Modding/Silverpine-Saelac-CustomNPCKnowledgeVariables) | Supports `%PLAYER_NAME%` in custom NPC knowledge, resolving it for dialogue and generation requests while preserving the authored placeholder. | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-CustomNPCKnowledgeVariables/releases) |
| [Custom NPC Silverpine Acquaintances](https://github.com/Silverpine-Modding/Silverpine-Saelac-CustomNPCSilverpineAcquaintances) | Adds an editor button to create missing acquaintance relationships with Silverpine-faction NPCs, including enabled custom NPCs, without overwriting existing relationships. | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-CustomNPCSilverpineAcquaintances/releases) |
| [Custom Rumors](https://github.com/Silverpine-Modding/Silverpine-saelac-custom-rumors) | Configure rumor generation, recipients, and delivery; compose rumors between NPCs or tell a nearby NPC a rumor directly. | [Releases](https://github.com/Silverpine-Modding/Silverpine-saelac-custom-rumors/releases) |
| [Dynamic NPC Relationships](https://github.com/Silverpine-Modding/Silverpine-saelac-dynamic-relationships) | Lets previously unassigned NPC pairs develop persistent relationships from their interactions, with relationship state stored per save. | [Releases](https://github.com/Silverpine-Modding/Silverpine-saelac-dynamic-relationships/releases) |
| [Expanded Important Relationships](https://github.com/Silverpine-Modding/Silverpine-Saelac-ExpandedImportantRelationships) | Raises the custom NPC editor's important-relationship limit from two to five. | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-ExpandedImportantRelationships/releases) |
| [Lua Routine Extensions](https://github.com/Silverpine-Modding/Silverpine-Saelac-LuaRoutineExtensions) | Adds schedule and NPC checks to custom-character Lua, guidance for AI-generated routines, and compatibility with alternate weekday-function names in existing scripts. | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-LuaRoutineExtensions/releases) |
| [Missing NPC Relationship Save Bypass](https://github.com/Silverpine-Modding/Silverpine-Saelac-MissingNPCRelationshipSaveBypass) | Allows custom NPC definitions to be saved when a relationship target is not installed, while retaining the other editor validation rules. | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-MissingNPCRelationshipSaveBypass/releases) |
| [QOLNPCSelector](https://github.com/Silverpine-Modding/Silverpine-Saelac-QOLNPCSelector) | Toggle custom NPCs, save or restore enabled-roster presets, randomize selections, and manage individual or connected SILC files through searchable menus. | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-QOLNPCSelector/releases) |
| [Runtime NPC Editor](https://github.com/Silverpine-Modding/Silverpine-Saelac-RuntimeNPCEditor) | Edit loaded NPC descriptions, personality traits, and the destinations and activities of existing routines through the in-game Mods menu. | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-RuntimeNPCEditor/releases) |
| [Silverpine Guard System](https://github.com/Silverpine-Modding/Silverpine-Saelac-SilverpineGuardSystem) | Designate guards, dispatch nearby responders, and manage fines and jail behavior through a Guard & Jail Manager. | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-SilverpineGuardSystem/releases) |

## Items, equipment, and crafting

| Plugin | What it does | Downloads |
| --- | --- | --- |
| [Additional Equipment Slots](https://github.com/Silverpine-Modding/Silverpine-Saelac-AdditionalEquipmentSlots) | Adds fourteen equipment slots for Custom Item Loader, including head, back, hands, feet, offhand, and accessories. | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-AdditionalEquipmentSlots/releases) |
| [Attribute Expansion](https://github.com/Silverpine-Modding/Silverpine-Saelac-AttributeExpansion) | Adds advanced equipment attribute modifiers to the Custom Item Editor and applies them to the corresponding game calculations. Requires Custom Item Loader. | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-AttributeExpansion/releases) |
| [Custom Crafting Recipes](https://github.com/Silverpine-Modding/Silverpine-Saelac-CustomCraftingRecipes) | Create recipe packs for the custom crafting workbench, Alchemy, and Cooking, with an in-game recipe editor and support for custom items. | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-CustomCraftingRecipes/releases) |
| [Custom Growables](https://github.com/Silverpine-Modding/Silverpine-Saelac-CustomGrowables) | Turn Custom Item Loader items into persistent plants with configurable growth stages, artwork, harvests, regrowth, and an in-game Growables Editor. | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-CustomGrowables/releases) |
| [Custom Item Loader](https://github.com/Silverpine-Modding/Silverpine-Saelac-CustomItemLoader) | Load and edit JSON item packs with custom artwork and GLB-rendered sprites through an in-game Custom Item Editor. | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-CustomItemLoader/releases) |
| [Custom Item Prompt Patcher](https://github.com/Silverpine-Modding/Silverpine-Saelac-CustomItemPromptPatcher) | Connects the debug item action to the Manual Custom Item Generator and supports saving its custom components. Requires CustomItemFreezeFix. **Preloader patcher.** | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-CustomItemPromptPatcher/releases) |
| [Manual Custom Item Generator / CustomItemFreezeFix](https://github.com/Silverpine-Modding/Silverpine-Saelac-CustomItemFreezeFix) | Replaces the unfinished debug item generator with a manual wizard for item appearance, descriptions, rarity, and other properties, avoiding the blocked loading dialog. | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-CustomItemFreezeFix/releases) |
| [Revealing](https://github.com/Silverpine-Modding/Silverpine-Saelac-Revealing) | Gives custom clothing and accessories precise coverage settings and authored descriptions for dialogue prompts. Requires Custom Item Loader. | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-Revealing/releases) |
| [Vendor Inventory Manager](https://github.com/Silverpine-Modding/Silverpine-Saelac-VendorInventoryManager) | Create vendor-stock packs with fixed minimum quantities, exclusions, and randomized item filters for base-game and eligible custom vendors. | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-VendorInventoryManager/releases) |

## Worlds, building, and enemies

| Plugin | What it does | Downloads |
| --- | --- | --- |
| [Custom Enemy Loader](https://github.com/Silverpine-Modding/Silverpine-Saelac-CustomEnemyLoader) | Load JSON enemy packs with custom stats, combat behavior, artwork, sounds, and world-generation locations, using PNGs or GLB-rendered sprites. | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-CustomEnemyLoader/releases) |
| [Custom World Setup](https://github.com/Silverpine-Modding/Silverpine-Saelac-CustomWorldSetup) | Design world layouts with a visual editor, configurable terrain tiles, roads, rivers, bridges, and persistent wilderness areas. Includes optional landmark relocation addons. | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-CustomWorldSetup/releases) |
| [Named NPC Property](https://github.com/Silverpine-Modding/Silverpine-Saelac-NamedNPCProperty) | Assign named or shared property to NPCs or the player, transfer ownership, and support house keys, local door knocking, and overnight invitations from co-owners. | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-NamedNPCProperty/releases) |
| [Silverpine Vertical Layers](https://github.com/Silverpine-Modding/Silverpine-Saelac-SilverpineVerticalLayers) | Adds connected, buildable upper floors to Silverpine's base world tile, with stairs, projected floors, and structural supports. | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-SilverpineVerticalLayers/releases) |
| [Structure Handler](https://github.com/Silverpine-Modding/Silverpine-Saelac-StructureHandler) | Edit, export, and import structures using shared mod menus and a main-menu structure editor, with support for terrain and placed objects. | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-StructureHandler/releases) |
| [Terrain Construction](https://github.com/Silverpine-Modding/Silverpine-Saelac-TerrainConstruction) | Adds a Terrains construction category for replacing ground and floor tiles, including persistent snowy or frozen variants, without material or hammer costs. | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-TerrainConstruction/releases) |

Custom World Setup also packages **Acacia's Den Relocator**, **Oriana Lake Relocator**, and **Orson Cabin Relocator**. Their documentation and downloads are in the [Custom World Setup repository](https://github.com/Silverpine-Modding/Silverpine-Saelac-CustomWorldSetup).

## Player characters and artwork

| Plugin | What it does | Downloads |
| --- | --- | --- |
| [Player Character Sprite Scaler](https://github.com/Silverpine-Modding/Silverpine-Saelac-PlayerCharacterSpriteScaler) | Adjust world-sprite and portrait X/Y scaling, flip portrait artwork, and save portable SILC artwork with separate recovery backups. | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-PlayerCharacterSpriteScaler/releases) |
| [Player Dialog Art](https://github.com/Silverpine-Modding/Silverpine-Saelac-PlayerDialogArt) | Choose a temporary player dialogue portrait and independently toggle the player's AI-driven facial expressions from the in-game mod menu. | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-PlayerDialogArt/releases) |
| [QOLCharSelector](https://github.com/Silverpine-Modding/Silverpine-Saelac-QOLCharSelector) | Adds a searchable, scrollable player-character list with names and world sprites beside the start-screen character selector. | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-QOLCharSelector/releases) |

## AI and dialogue settings

| Plugin | What it does | Downloads |
| --- | --- | --- |
| [NovelAI Endpoint](https://github.com/Silverpine-Modding/Silverpine-Saelac-NovelAIEndpoint) | Adds NovelAI as a text-generation provider, with streaming responses, model selection, request pacing, and encrypted API-key storage. | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-NovelAIEndpoint/releases) |
| [NPC Relationship Context Optimizer](https://github.com/Silverpine-Modding/Silverpine-Saelac-NPCRelationshipContextOptimizer) | Reduces relationship-related dialogue prompt growth for large custom NPC rosters while retaining relevant character details and indirect character lookup. | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-NPCRelationshipContextOptimizer/releases) |
| [NPC Response Multiplier](https://github.com/Silverpine-Modding/Silverpine-Saelac-NPCResponseMultiplier) | Adjust NPC response token budgets and verbosity together through Modding Tools, starting at the game's normal 1x setting. | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-NPCResponseMultiplier/releases) |

## Fixes and preloader patchers

| Plugin | What it does | Downloads |
| --- | --- | --- |
| [Acacia Custom Content Patcher](https://github.com/Silverpine-Modding/Silverpine-Saelac-AcaciaCustomContentPatcher) | Removes Acacia-specific custom-content editor restrictions and retains her original personality traits when override fields are blank. **Preloader patcher.** | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-AcaciaCustomContentPatcher/releases) |
| [Extended Custom NPC Slots Rumor Fix](https://github.com/Silverpine-Modding/Silverpine-Saelac-ExtendedCustomNPCSlotsRumorFix) | Repairs missing rumor entries in older saves when expanded NPC slots are used. Requires the separate ExtendedCustomNPCSlots preloader patcher; this plugin does not add slots. | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-ExtendedCustomNPCSlotsRumorFix/releases) |
| [Projectile Transition Fix](https://github.com/Silverpine-Modding/Silverpine-Saelac-ProjectileTransitionFix) | Safely cancels projectiles when their owner or target disappears during a transition and handles related damage-processing null references. | [Releases](https://github.com/Silverpine-Modding/Silverpine-Saelac-ProjectileTransitionFix/releases) |

## Help and development

For setup, dependencies, configuration, and source code, open the relevant repository above. Report plugin-specific problems through that repository's **Issues** tab, including the plugin version and steps to reproduce the problem.

Building a plugin? Start with the [Modding Tools framework and API documentation](https://github.com/Silverpine-Modding/Silverpine-Saelac-Modding-Tools).

---

Catalog checked against the organization's public repositories on **September 15, 2026**. Version requirements and release details are maintained in each project. [Browse all repositories](https://github.com/orgs/Silverpine-Modding/repositories).
