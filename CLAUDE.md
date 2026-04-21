# CraftClash — Claude Code Context

## Project
Unity 6 LTS, WebGL target, 1v1 PvP space shooter.
Players build a ship from modules before each match.
First ship to 0 HP loses.
Photon Fusion 2 Shared Mode added in Phase 2 by a separate agent.

## Architecture rules — enforce in every file
- Input.GetKey only in Scripts/Input/PlayerInput.cs
- Manual DI only — all dependencies injected via [SerializeField] Inspector refs; no singletons, no FindObjectOfType
- No Photon namespace until Phase 2
- All cross-system communication via UnityEvents
- No async/await — coroutines only
- All tunable values exposed as [SerializeField]
- ShipController never reads input directly — reads ShipInputData struct only
- No hardcoded HP, damage or speed values — all come from module data

## Folder structure
Assets/Scripts/Input/
Assets/Scripts/Ship/
Assets/Scripts/Combat/
Assets/Scripts/Game/
Assets/Scripts/UI/
Assets/Prefabs/
Assets/Sprites/
Assets/_Scenes/