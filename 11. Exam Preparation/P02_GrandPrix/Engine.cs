using System;
using System.Linq;

public class Engine
{
    private RaceTower raceTower;

    public Engine(RaceTower raceTower)
    {
        this.raceTower = raceTower;
    }

    public void Run()
    {
        while (true)
        {
            var commandArgs = Console.ReadLine().Split();
            var commandType = commandArgs[0];
            var methodArgs = commandArgs.Skip(1).ToList();

            switch (commandType)
            {
                case "RegisterDriver":
                    this.raceTower.RegisterDriver(methodArgs);
                    break;
                case "Leaderboard":
                    Console.WriteLine(this.raceTower.GetLeaderboard());
                    break;
                case "CompleteLaps":
                    var result = this.raceTower.CompleteLaps(methodArgs);

                    if (!string.IsNullOrWhiteSpace(result))
                    {
                        Console.WriteLine(result);
                    }
                    break;
                case "Box":
                    this.raceTower.DriverBoxes(methodArgs);
                    break;
                case "ChangeWeather":
                    this.raceTower.ChangeWeather(methodArgs);
                    break;
                default:
                    Console.WriteLine($"INVALID COMMAND");
                    break;
            }


            if (this.raceTower.Track.CurrentLap == this.raceTower.Track.LapsNumber)
            {
                return;
            }
        }
    }
}