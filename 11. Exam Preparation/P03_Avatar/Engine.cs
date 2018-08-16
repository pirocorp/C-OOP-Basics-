using System;
using System.Linq;

public class Engine
{
    public void Run()
    {
        var nationBuilder = new NationsBuilder();

        while (true)
        {
            var inputArgs = Console.ReadLine().Split();
            var command = inputArgs[0];
            var commandArgs = inputArgs.Skip(1).ToList();

            switch (command)
            {
                case "Bender":
                    nationBuilder.AssignBender(commandArgs);
                    break;
                case "Monument":
                    nationBuilder.AssignMonument(commandArgs);
                    break;
                case "Status":
                    Console.WriteLine(nationBuilder.GetStatus(commandArgs[0]));
                    break;
                case "War":
                    nationBuilder.IssueWar(commandArgs[0]);
                    break;
                case "Quit":
                    Console.WriteLine(nationBuilder.GetWarsRecord());
                    return;
            }
        }
    }
}