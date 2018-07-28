using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        
        var team = new Team("SoftUni");

        for (var i = 0; i < n; i++)
        {
            var cmdArgs = Console.ReadLine().Split();

            try
            {
                var player = new Person(cmdArgs[0], cmdArgs[1], int.Parse(cmdArgs[2]), decimal.Parse(cmdArgs[3]));
                team.AddPlayer(player);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
        Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
    }
}