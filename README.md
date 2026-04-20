# Maze Race

A competitive multiplayer and solo maze game built in Unity where players 
race to collect coins. The multiplayer mode pits two players against each 
other in a maze, while solo mode challenges a single player to collect all 
coins as fast as possible.

## Built With

- Unity 6 (6000.3.3f1)
- Unity Netcode for GameObjects
- SQLite (via sqlite-net-pcl)
- C#

## How to Play

### Controls
- **WASD** — Move player
- **Escape** — Open/Close pause menu

### Multiplayer Mode
- First player clicks **Host Game**
- Second player enters the host's IP address and clicks **Join Game**
- Both players load into the maze
- Collect coins to earn points
- First player to reach 150 points wins

### Solo Mode
- Click **Solo Play** from the main menu
- Navigate the maze and collect all 31 coins as fast as possible
- Your completion time is saved to the solo leaderboard

## Setup Instructions

1. Clone the repository:
2. Open **Unity Hub** and click **Open Project**
3. Navigate to the cloned folder and open it
4. Let Unity import all assets and packages
5. Open the **MainMenu** scene from `Assets/Scenes/`
6. Press **Play** to test in the editor

## How to Test Multiplayer

1. Build the project via **File → Build Settings → Build**
2. Run the built **.exe** — this will be the client
3. Hit **Play** in the Unity Editor — this will be the host
4. In the **Editor** click **Host Game**
5. In the **.exe** click **Join Game** (leave IP blank for localhost)
6. Both instances should load into the game scene

To test over a local network, enter the host machine's IP address in the 
IP field before clicking Join Game.

## Scene Structure

| Scene | Description |
|-------|-------------|
| MainMenu | Title screen with Solo, Host, and Join buttons |
| GameScene | Multiplayer maze — first to 150 points wins |
| SoloMode | Solo maze — collect all 31 coins as fast as possible |
| GameOver | Submit your name and score to the leaderboard |
| HighScores | View top 5 scores for multiplayer or solo mode |

## Technical Requirements

| Requirement | Implementation | Location |
|-------------|---------------|----------|
| Singleton | GameManager, AudioManager, DatabaseManager, CoinPoolManager | Assets/Scripts/ |
| Delegate | onScoreChanged, onGameOver events in GameManager | GameManager.cs |
| Object Pool | CoinPoolManager reuses coin GameObjects between rounds | CoinPoolManager.cs |
| Database | SQLite stores multiplayer and solo high scores | DatabaseManager.cs |
| Save/Load | High scores persist between sessions via SQLite | DatabaseManager.cs |
| Audio | AudioManager handles background music and coin SFX | AudioManager.cs |

## Project Structure
Assets/
├── Audio/          # Background music and sound effects

├── Prefabs/        # Player and Coin prefabs

├── Scenes/         # All game scenes

├── Scripts/        # All C# scripts

└── UI/             # UI assets

## Technologies Used

- Unity 6 (6000.3.3f1)
- Unity Netcode for GameObjects
- Unity Transport
- SQLite via NuGet (sqlite-net-pcl)
- TextMeshPro
- C#
