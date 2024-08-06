using System;

class Program
{
    static void Main(string[] args)
    {
        var table = new Table(5, 5);
        var robot = new Robot(table);
        var commandProcessor = new CommandProcessor(robot);

        Console.WriteLine("Enter commands (PLACE X,Y,F | MOVE | LEFT | RIGHT | REPORT):");

        while (true)
        {
            var input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) break;

            commandProcessor.ProcessCommand(input.Trim().ToUpper());
        }
    }
}
