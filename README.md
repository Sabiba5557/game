🟡 Pacman Game (Windows Forms – C#)

A simple Pac-Man style game built using C# and Windows Forms.
The player controls Pacman, collects coins, avoids ghosts, and tries to win by collecting all coins.

🎮 Gameplay Overview
* Control Pacman using the arrow keys
* Collect all coins to win
* Touching a ghost or wall ends the game
* Press Enter to restart after Game Over
  
🕹️ Controls
Key                 	Action
⬆️ Up Arrow	         Move Up
⬇️ Down Arrow      	Move Down
⬅️ Left Arrow     	Move Left
➡️ Right Arrow    	Move Right
⏎ Enter	            Restart Game (after Game Over)

🧠 Game Logic
Player (Pacman)
*Moves in four directions
*Speed controlled by playerSpeed
*Wraps around screen boundaries

Coins
*Tagged as "coin"
*Increase score when collected
*Disappear after collision

Walls
*Tagged as "wall"
*Collision ends the game immediately

Ghosts
*Tagged as "ghost"
*Red Ghost: Horizontal movement with wall bounce
*Yellow Ghost: Horizontal movement with boundary blocks
*Pink Ghost: Moves diagonally and bounces off edges and walls

🏆 Win & Lose Conditions
✅ Win: Collect all 73 coins
❌ Lose: Collide with any ghost or wall

🔁 Game Reset
When the game resets:
*Score resets to 0
*All coins become visible again
*Player and ghosts return to starting positions
*Game timer restarts
