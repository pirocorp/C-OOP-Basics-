using System;
using System.Collections.Generic;

public class Startup
{
    static void Main()
    {
        var teams = new Dictionary<string, Team>();

        var inputLine = string.Empty;

        while ((inputLine = Console.ReadLine()) != "END")
        {
            var tokens = inputLine.Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries);

            var command = tokens[0];

            switch (command)
            {
                case "Team":
                    AddNewTeam(teams, tokens);
                    break;
                case "Add":
                    AddNewPlayerToTheTeam(teams, tokens);
                    break;
                case "Remove":
                    RemovePlayerFromTheTeam(teams, tokens);
                    break;
                case "Rating":
                    PrintTeamRating(teams, tokens);
                    break;
            }
        }
    }

    private static void PrintTeamRating(Dictionary<string, Team> teams, string[] tokens)
    {
        var teamName = tokens[1];

        if (!teams.ContainsKey(teamName))
        {
            Console.WriteLine($"Team {teamName} does not exist.");
            return;
        }

        Console.WriteLine($"{teams[teamName].Name} - {Math.Round(teams[teamName].Rating())}");
    }

    private static void RemovePlayerFromTheTeam(Dictionary<string, Team> teams, string[] tokens)
    {
        var teamName = tokens[1];

        if (!teams.ContainsKey(teamName))
        {
            Console.WriteLine($"Team {teamName} does not exist.");
            return;
        }

        var playerName = tokens[2];

        try
        {
            teams[teamName].RemovePlayer(playerName);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private static void AddNewPlayerToTheTeam(Dictionary<string, Team> teams, string[] tokens)
    {
        var teamName = tokens[1];

        if (!teams.ContainsKey(teamName))
        {
            Console.WriteLine($"Team {teamName} does not exist.");
            return;
        }

        var playerName = tokens[2];
        var playerEndurance = int.Parse(tokens[3]);
        var playerSprint = int.Parse(tokens[4]);
        var playerDribble = int.Parse(tokens[5]);
        var playerPassing = int.Parse(tokens[6]);
        var playerShooting = int.Parse(tokens[7]);

        try
        {
            var currentPlayer = new Player(playerName, playerEndurance, playerSprint, playerDribble, playerPassing, playerShooting);
            teams[teamName].AddPlayer(currentPlayer);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    private static void AddNewTeam(Dictionary<string, Team> teams, string[] tokens)
    {
        var teamName = tokens[1];

        try
        {
            var newTeam = new Team(teamName);
            teams.Add(teamName, newTeam);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}