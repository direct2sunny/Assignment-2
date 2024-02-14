using System;

public class Position
{
    public int X { get; set; }
    public int Y { get; set; }

    public Position(int x, int y)
    {
        // Constructor
        X = x;
        Y = y;
    }
}
public class Player
{
    public string Name { get; set; }
    public Position Position { get; set; }
    public int GemCount { get; set; }

    public Player(string name, Position position)
    {
        Name = name;
        Position = position;
        GemCount = 0;
    }

    public void Move(char direction)
    {
        switch (direction)
        {
            case 'U': Position.Y--; break;
            case 'D': Position.Y++; break;
            case 'L': Position.X--; break;
            case 'R': Position.X++; break;
        }
    }
}
public class Cell
{
    public string Occupant { get; set; }

    public Cell(string occupant = "-")
    {
        Occupant = occupant;
    }
}
using System;

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

    public void Display()
    {
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                Console.Write(Grid[i, j].Occupant + " ");
            }
            Console.WriteLine();
        }
    }

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

    public bool IsValidMove(Player player, char direction)
    {
        // Implement validation logic here
        return true; // Placeholder
    }

    public void CollectGem(Player player)
    {
        // Implement gem collection logic here
    }
}
