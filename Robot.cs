using System;

public class Robot
{
    private int _x;
    private int _y;
    private string _facing;
    private readonly Table _table;

    private static readonly string[] Directions = { "NORTH", "EAST", "SOUTH", "WEST" };

    public Robot(Table table)
    {
        _table = table;
    }

    public void Place(int x, int y, string facing)
    {
        if (_table.IsValidPosition(x, y) && Array.Exists(Directions, d => d == facing))
        {
            _x = x;
            _y = y;
            _facing = facing;
        }
    }

    public void Move()
    {
        int newX = _x;
        int newY = _y;

        switch (_facing)
        {
            case "NORTH":
                newY++;
                break;
            case "EAST":
                newX++;
                break;
            case "SOUTH":
                newY--;
                break;
            case "WEST":
                newX--;
                break;
        }

        if (_table.IsValidPosition(newX, newY))
        {
            _x = newX;
            _y = newY;
        }
    }

    public void Left()
    {
        int currentDirectionIndex = Array.IndexOf(Directions, _facing);
        _facing = Directions[(currentDirectionIndex + 3) % 4];
    }

    public void Right()
    {
        int currentDirectionIndex = Array.IndexOf(Directions, _facing);
        _facing = Directions[(currentDirectionIndex + 1) % 4];
    }

    public string Report()
    {
        return $"{_x},{_y} {_facing}";
    }
}
