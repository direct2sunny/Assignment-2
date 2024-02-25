using System;

// The GemHunters Game Class.
namespace GemHunters
{
    class Program
    {
        // Main method that initiates the game.
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
        }
    }

    // Represents a position on the game board.
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        // Constructor. 
        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    // Defines a Player Class.
    public class Player
    {
        public string Name { get; set; }
        public Position Position { get; set; }
        public int GemCount { get; set; }

        // Constructor.
        public Player(string name, Position position)
        {
            Name = name;
            Position = position;
            GemCount = 0;
        }

        // Moves the player in a specified direction.
        public void Move(char direction)
        {
            switch (direction)
            {
                case 'U': Position.Y = Math.Max(Position.Y - 1, 0); break;
                case 'D': Position.Y = Math.Min(Position.Y + 1, 5); break;
                case 'L': Position.X = Math.Max(Position.X - 1, 0); break;
                case 'R': Position.X = Math.Min(Position.X + 1, 5); break;
            }
        }
    }

    // Represents a Cell Class.
    public class Cell
    {
        public string Occupant { get; set; }

        // Constructor.
        public Cell(string occupant = "-")
        {
            Occupant = occupant;
        }
    }

    // Represents The Board Class, A 6x6 Grid.
    public class Board
    {
        public Cell[,] Grid { get; set; }

       
        public Board()
        {
            Grid = new Cell[6, 6];
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    Grid[i, j] = new Cell();
                }
            }
            PlaceObstacles();
            PlaceGems();
        }

        // Places Obstacles Randomly Class.
        private void PlaceObstacles()
        {
            Random rand = new Random();
            for (int i = 0; i < 10; i++)
            {
                int x, y;
                do
                {
                    x = rand.Next(0, 6);
                    y = rand.Next(0, 6);
                } while (Grid[y, x].Occupant != "-");
                Grid[y, x].Occupant = "O";
            }
        }

        // Places Gems Randomly Class.
        private void PlaceGems()
        {
            Random rand = new Random();
            for (int i = 0; i < 5; i++)
            {
                int x, y;
                do
                {
                    x = rand.Next(0, 6);
                    y = rand.Next(0, 6);
                } while (Grid[y, x].Occupant != "-");
                Grid[y, x].Occupant = "G";
            }
        }

        // Displays the board and the players' positions and gem counts.
        public void Display(Player player1, Player player2)
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (i == player1.Position.Y && j == player1.Position.X)
                    {
                        Console.Write("P1 ");
                    }
                    else if (i == player2.Position.Y && j == player2.Position.X)
                    {
                        Console.Write("P2 ");
                    }
                    else
                    {
                        Console.Write(Grid[i, j].Occupant + " ");
                    }
                }
                Console.WriteLine();
            }
            // Gem Counts For Both Players.
            Console.WriteLine($"P1 Gems: {player1.GemCount}, P2 Gems: {player2.GemCount}");
        }

        // Checks if a move is valid before it is made.
        public bool IsValidMove(Player player, char direction)
        {
            int newX = player.Position.X;
            int newY = player.Position.Y;
            switch (direction)
            {
                case 'U': newY--; break;
                case 'D': newY++; break;
                case 'L': newX--; break;
                case 'R': newX++; break;
            }
            return newX >= 0 && newX < 6 && newY >= 0 && newY < 6 && Grid[newY, newX].Occupant != "O";
        }

        
        public void CollectGem(Player player)
        {
            if (Grid[player.Position.Y, player.Position.X].Occupant == "G")
            {
                player.GemCount++;
                Grid[player.Position.Y, player.Position.X].Occupant = "-";
            }
        }
    }

    // The Game Class.
    public class Game
    {
        public Board Board { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        private Player CurrentTurn { get; set; }
        private int TotalTurns { get; set; }

        
        public Game()
        {
            Board = new Board();
            Player1 = new Player("P1", new Position(0, 0));
            Player2 = new Player("P2", new Position(5, 5));
            CurrentTurn = Player1;
            TotalTurns = 0;
        }

        // Starts The Game and Manages Turns Until The Game is Over.
        public void Start()
        {
            Console.WriteLine("Welcome to Gem Hunters!");
            while (!IsGameOver())
            {
                Console.Clear();
                Board.Display(Player1, Player2);
                Console.WriteLine($"Turn: {TotalTurns + 1}");
                Console.Write($"{CurrentTurn.Name}'s move (U/D/L/R): ");
                var input = Console.ReadLine().ToUpper();
                if (!string.IsNullOrEmpty(input))
                {
                    char direction = input[0];
                    if (Board.IsValidMove(CurrentTurn, direction))
                    {
                        CurrentTurn.Move(direction);
                        Board.CollectGem(CurrentTurn);
                        SwitchTurn();
                    }
                    else
                    {
                        Console.WriteLine("Invalid move. Try again.");
                        Console.ReadKey();
                    }
                }
            }
            AnnounceWinner();
        }

        // Switch Players.
        private void SwitchTurn()
        {
            CurrentTurn = CurrentTurn == Player1 ? Player2 : Player1;
            TotalTurns++;
        }

        // The Game is Over Based on Turn Count or Gem Collection.
        private bool IsGameOver()
        {
            return TotalTurns == 30 || (Player1.GemCount + Player2.GemCount == 5);
        }

        // The Winner Based on Gem Count.
        private void AnnounceWinner()
        {
            Console.WriteLine($"Game Over. P1 Gems: {Player1.GemCount}, P2 Gems: {Player2.GemCount}");
            if (Player1.GemCount > Player2.GemCount)
            {
                Console.WriteLine("Player 1 wins!");
            }
            else if (Player2.GemCount > Player1.GemCount)
            {
                Console.WriteLine("Player 2 wins!");
            }
            else
            {
                Console.WriteLine("It's a tie!");
            }
        }
    }
}
