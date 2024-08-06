using System;

public class CommandProcessor
{
    private readonly Robot _robot;

    public CommandProcessor(Robot robot)
    {
        _robot = robot;
    }

    public void ProcessCommand(string command)
    {
        var parts = command.Split(' ');
        var mainCommand = parts[0];

        switch (mainCommand)
        {
            case "PLACE":
                if (parts.Length == 2)
                {
                    var args = parts[1].Split(',');
                    if (args.Length == 2 || args.Length == 3)
                    {
                        int x, y;
                        string facing = args.Length == 3 ? args[2] : _robot.Report().Split(' ')[1];
                        if (int.TryParse(args[0], out x) && int.TryParse(args[1], out y))
                        {
                            _robot.Place(x, y, facing);
                        }
                    }
                }
                break;
            case "MOVE":
                _robot.Move();
                break;
            case "LEFT":
                _robot.Left();
                break;
            case "RIGHT":
                _robot.Right();
                break;
            case "REPORT":
                Console.WriteLine(_robot.Report());
                break;
        }
    }
}
