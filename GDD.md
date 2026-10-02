# Game Design Document: "Memo & Co"

## 1. Executive Summary
*   **Genre:** 2D Casual Puzzle / Memory Match
*   **Platform:** PC & WebGL (Hosted on Itch.io)
*   **Target Audience:** Casual gamers, students, and peers looking for quick, customizable multiplayer sessions.
*   **Core Concept:** A classic Memory Match game focused on high customizability, allowing players to scale difficulty, play together on one screen (Hotseat), and use custom-drawn or imported visuals.
*   **Project Purpose:** A developer portfolio pet-project demonstrating clean architecture, UI/UX polishing ("game juice"), and scalable C# coding in Unity.


## 2. Gameplay & Core Mechanics

### 2.1 Core Loop
1. **Setup:** Choose grid size and game mode -> 
2. **Action:** Flip two cards face up -> 
3. **Check:** If they match, cards are locked/removed and points are awarded; if not, they flip back face down -> 
4. **Turn Progression:** Win the game by matching all pairs or pass the turn to the next player.

### 2.2 Key Features & Mechanics
*   **Dynamic Grid Generation:** The board automatically scales based on player preference (e.g., 4x4, 6x4, 6x6). The code ensures an even number of cards and shuffles them randomly using the Fisher-Yates algorithm.
*   **Turn-Based Local Multiplayer (Hotseat):** Supports 1 to 3 players sharing the same screen. 
    *   If Player A finds a match, they get another turn.
    *   If Player A fails, the turn passes to Player B.
*   **Custom Content Creation (MVP+ Phase):**
    *   *In-Game Canvas:* A simple pixel-art drawing tool where players can draw on a UI texture grid and use it as card artwork.
    *   *Image Import:* Ability to load external `.png`/`.jpg` images to generate custom decks.


## 3. Game States & Flow
The application operates within three main states managed by a state-driven `GameManager`:

1.  **Main Menu State:**
    *   Select Grid Size (Dropdown/Slider).
    *   Select Player Count (1-3).
    *   Access Custom Card Creator.
    *   "Start Game" button.
2.  **Gameplay State:**
    *   Board generation animation.
    *   Turn indicators and score tracking UI.
    *   Pause menu.
3.  **End Game State:**
    *   Victory screen showing the winner (or final score/time for solo mode).
    *   "Play Again" and "Back to Main Menu" buttons.


## 4. Technical Architecture (Unity / C#)

To ensure the project can expand into a collection of mini-games, the architecture follows loose coupling principles (Managers + Components):

*   **`GameManager.cs` (Persistent Persistent Singleton):** Controls the global state machine (Menu, Gameplay, Reset, Pause).
*   **`MemoGameController.cs` (Scene-Specific):** Holds references to the active cards, tracks the active player, checks for card ID matches, and manages scores.
*   **`BoardGenerator.cs`:** Instantiates card prefabs inside a Unity `GridLayoutGroup` based on selected dimensions, assigning unique pair IDs.
*   **`Card.cs` (Attached to Card Prefab):** Handles individual card states (FaceDown, FaceUp, Locked), triggers flip animations (via Scale X tweening), and passes click events to the controller.


## 5. Visuals & Aesthetic ("Game Juice")
Since the developer is a programmer, art constraints are handled strategically:
*   **Art Style:** Clean, minimalist geometric shapes or unified free pixel-art asset packs from Itch.io.
*   **Juiciness (UI/UX Polishing):** 
    *   Smooth card flipping transitions.
    *   Particle effects (sparks/bursts) upon successful matches.
    *   Camera shake or visual screen flashes for wrong moves.
    *   Color-coded UI panels that change smoothly depending on whose turn it is.


## 6. MVP Roadmap & Milestones

*   **Milestone 1 (Core Prototype):** Card flipping logic, basic match checking, and grid spawning with placeholder colors.
*   **Milestone 2 (Game Loop):** Main Menu implementation, grid size options, and a single-player win/lose condition.
*   **Milestone 3 (Hotseat Multiplayer):** Turn-switching logic for multiple players, score tracking UI, and adding sound effects/particles.
*   **Milestone 4 (Polish & WebGL):** Integration of custom drawing/loading tools, code refactoring, WebGL optimization, and deployment to Itch.io.
