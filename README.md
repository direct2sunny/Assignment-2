**Assignment-2**


**Description**:

"Gem Hunters" is a console-based 2D strategy game where two players compete to collect the most gems on a 6x6 square board within a limited number of turns. Each player starts in opposite corners of the board, with Player 1 beginning in the top-left corner and Player 2 in the bottom-right corner. The game's board features not only gems but also obstacles that players must navigate around. These elements are randomly placed at the start of the game and remain static throughout.


**Position**:

The Position class is a fundamental component in the "Gem Hunters" game, representing the coordinates of entities on the 2D game board, such as players, gems, and obstacles. It is designed to track the location of these entities within the game's grid-based system.

**Players**:

The player represents a player in a game with basic functionality for movement and gem collection. It contains properties to track the player's name, position on a 2D grid, and the number of collected gems. The Position property is of a custom type, presumably a class or struct, that contains X and Y coordinates indicating the player's location on the grid.

**Cell**:

The Cell class in the game serves as a fundamental building block for the game board's grid. Each instance of Cell represents a single square on the grid, which can be occupied by different objects in the game.

**Board**:

The board is the backbone for a grid-based game environment in C#. It models a 6x6 game board containing obstacles, gems, and potentially a player. The class is structured to initialize the game board, populate it with obstacles and gems, and display its current state. 

**Game**:

The Game class in the "Gem Hunters" game acts as the central controlling entity that orchestrates the gameplay, managing the game's state, the progression of turns, and the interaction between various game components like the board, players, and game rules. Here's a detailed explanation of its structure and functionality:

**Properties**

**Board:** 
An instance of the Board class representing the game board. It holds the game layout, including the positions of gems, obstacles, and empty spaces.

**Player1 and Player2:**
Instances of the Player class represent the two players in the game. Each player has a name, a position on the board, and a count of collected gems.

**Current Turn:** 
This is a reference to the player whose turn is currently active. This alternates between Player 1 and Player 2 as the game progresses.

**Total Turns:** 
An integer is tracking the total number of turns that have occurred. The game ends after 30 turns (15 turns for each player).

**Constructor**

**Game:** 
The constructor initializes the game by creating a new board, setting up the two players at their starting positions, and setting the initial turn to Player 1. It also initializes the TotalTurns counter to 0.

**Methods**

**Start:** This method kicks off the game loop. It repeatedly updates the game state by:
They are clearing the console and displaying the current state of the board with the players' positions.
Prompting the current player to input a move direction.
Checking if the move is valid (i.e., within the board boundaries and not into an obstacle).
Move the player and attempt to collect a gem if one is present on the new square.
Switching turns between players and incrementing the TotalTurns counter.
The loop continues until the game is over, which is determined by the IsGameOver method.

**Switch Turn:** 
Alternates the current active player between Player1 and Player2. This method is called after each turn to ensure that players take turns in a fair sequence.

**Is Game Over:**
Check if the game has reached its end condition. In "Gem Hunters," the game ends after 30 moves (15 for each player), so this method returns true when TotalTurns reaches 30.

**Announce Winner:**
Once the game is over, this method compares the GemCount of both players to determine the winner. The winner is the player who has collected the most gems. The game ends in a tie if both players have the same number of gems. The result is then displayed to the console.

**Gameplay Flow:** 
The game initializes and enters the main loop;

The current player is prompted to move with each turn.

The board is updated based on the player's action, including moving the player's position and collecting gems.

The game checks for the end condition after each turn. If the condition is met, the loop exits.

The winner is announced based on the number of gems each player collects.

The game ended up with a winner or tie.

