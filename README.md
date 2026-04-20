# Maze Race

A competitive multiplayer game built in Unity where 2 players race through an arena 
to collect coins before their opponent. The game rewards both speed and strategy.

## Built With

- Unity 6 (6000.3.3f1)
- Unity Netcode for GameObjects
- C#

## Setup Instructions

1. Clone the repository:
2. Open **Unity Hub** and click **Open Project**
3. Navigate to the cloned folder and open it
4. Let Unity import all assets and packages
5. Open the **MainMenu** scene from `Assets/Scenes/`

## How to Test Multiplayer

1. Build the project via **File → Build Settings → Build**
2. Run the built **.exe** — this will be the client
3. Hit **Play** in the Unity Editor — this will be the host
4. In the **Editor** click **Host Game**
5. In the **.exe** click **Join Game** (leave IP blank for localhost)
6. Both instances should load into the game scene

To test over a network, enter the host machine's local IP address 
in the IP field before clicking Join Game.

## Key Scripts

| Script | Location | Purpose |
|--------|----------|---------|
| GameManager.cs | Assets/Scripts/ | Singleton managing score and game events |
| PlayerController.cs | Assets/Scripts/ | Networked player movement |
| CoinPickup.cs | Assets/Scripts/ | Coin collection and score delegation |
| CoinSpawner.cs | Assets/Scripts/ | Spawns coins at scene start on host |
| UIManager.cs | Assets/Scripts/ | Subscribes to delegates and updates HUD |
| NetworkManagerUI.cs | Assets/Scripts/ | Host/client connection logic |

## Technical Requirements Implemented

- **Singleton Pattern** — GameManager persists across scenes via DontDestroyOnLoad
- **Delegate Usage** — onScoreChanged and onGameOver events broadcast game state changes
- **Multiplayer** — Unity Netcode synchronizes player movement and coin collection

## Known Issues / In Progress

- Maze layout is a placeholder arena — full maze coming in final submission
- Game over condition triggers when all coins are collected but results screen not yet implemented
- Player spawning at specific spawn points needs refinement
