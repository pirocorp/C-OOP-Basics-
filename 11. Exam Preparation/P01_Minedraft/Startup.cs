using System;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        ReadInput();
    }

    private static void ReadInput()
    {
        var manager = new DraftManager();

        while (true)
        {
            var tokens = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            var command = tokens[0];
            var arguments = tokens.Skip(1).ToList();

            switch (command)
            {
                case "RegisterHarvester":
                    Console.WriteLine(manager.RegisterHarvester(arguments));
                    break;

                case "RegisterProvider":
                    Console.WriteLine(manager.RegisterProvider(arguments));
                    break;

                case "Day":
                    Console.WriteLine(manager.Day());
                    break;

                case "Mode":
                    Console.WriteLine(manager.Mode(arguments));
                    break;

                case "Check":
                    Console.WriteLine(manager.Check(arguments));
                    break;

                case "Shutdown":
                    Console.WriteLine(manager.ShutDown());
                    return;
            }
        }
    }
}