# Robomania

A 2D side-scrolling shooter built in Unity, where you control **RoboMan**, aim and fire with the mouse, and fight off crusher-type enemies that patrol the level.

## Gameplay

- **Move** with the horizontal input axis (A/D or arrow keys) — RoboMan is clamped to a fixed horizontal play area and flips to face the direction he's moving/aiming.
- **Jump** with the Jump input (Space by default), only while grounded.
- **Aim** with the mouse — a crosshair follows the cursor, and RoboMan's blaster rotates to point at it.
- **Shoot** with left-click, firing a proton projectile toward the crosshair.
- Enemies (**Crushers**) patrol the level — one bounces back and forth across the screen, the other launches itself with an initial impulse.
- Both the player and enemies have health bars and flash white on taking damage; running out of health destroys/deactivates the object. When RoboMan dies, the scene reloads automatically after a short delay.

## Tech Stack

- **Engine:** Unity 2022.3.17f1
- **Rendering:** 2D (Sprite Renderer, Box/Rigidbody 2D physics)
- **UI:** Unity UI (Slider-based health bars), TextMeshPro

## Project Structure

```
Assets/
  Animations/        Animator controllers and clips for the Crusher and Robot
  Prefab/             Player, Crusher1, Crusher2, Crosshair, GroundPlatform, bullet prefabs
  Resources/           Explosion effects and flash materials, loaded at runtime via Resources.Load
  Scenes/              Robomania (main scene), SampleScene
  Scripts/             Gameplay scripts (see below)
  Sprites/             Player, enemy, bullet, ground, crosshair, and health bar art
Packages/              Unity package manifest
ProjectSettings/       Unity project configuration
```

### Scripts

| Script | Responsibility |
|---|---|
| `PlayerControls.cs` | Player movement, jumping, ground detection, and facing direction |
| `ProjectileAndAim.cs` | Mouse-aimed crosshair, blaster rotation, and firing projectiles |
| `PlayerHealth.cs` | Player damage-on-collision, hit-flash effect, death, and scene restart |
| `EnemyHealth.cs` | Enemy damage-on-bullet-hit, hit-flash effect, and destruction |
| `Crusher1.cs` | Enemy patrol movement — bounces between fixed x-bounds |
| `Crusher2.cs` | Enemy launch movement — impulse-based movement on spawn |
| `DestroyOnInvisible.cs` | Cleans up projectiles after a timeout or on hitting the ground |
| `ScreenColliderManager.cs` | Builds invisible boundary colliders around the edges of the screen |

## Getting Started

1. Install **Unity Hub** and **Unity 2022.3.17f1** (or a compatible 2022.3 LTS patch version).
2. Clone the repository:
   ```
   git clone https://github.com/BitaBig/robotmania.git
   ```
3. Open the project folder in Unity Hub (Unity will resolve packages from `Packages/manifest.json` on first open — this can take a few minutes).
4. Open `Assets/Scenes/Robomania.unity` and press **Play**.

## Known Issues

- First-time or fresh clones may hit a `CS0006: Metadata file ... could not be found` error related to `com.unity.collab-proxy` (Unity's Plastic/Collab package). If this happens, either let Unity fully regenerate the `Library` folder on first open, or remove the `com.unity.collab-proxy` line from `Packages/manifest.json` if you don't use Unity Version Control.

## License

No license specified yet — add one (e.g. MIT) if you intend for others to reuse this code.
