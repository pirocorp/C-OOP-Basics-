using System;
using System.Collections.Generic;
using System.Linq;

public class Team
{
    private string name;
    private List<Player> players;

    public string Name
    {
        get => this.name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("A playerName should not be empty.");
            }

            this.name = value;
        }
    }

    public Team(string name)
    {
        this.Name = name;
        players = new List<Player>();
    }

    private static double OveralSkillOfPlayer(Player player)
    {
        double[] stats =
        {
            player.Endurance,
            player.Sprint,
            player.Dribble,
            player.Passing,
            player.Shooting,
        };

        return stats.Average();
    }

    public double Rating()
    {
        if (players.Count > 0)
        {
            return players.Select(OveralSkillOfPlayer).Average();
        }
        else
        {
            return 0;
        }
    }

    public void AddPlayer(Player player)
    {
        if (player == null)
        {
            throw new ArgumentNullException($"{nameof(AddPlayer)}");
        }

        players.Add(player);
    }

    public void RemovePlayer(string playerName)
    {
        var playerToBeRemoved = players.FirstOrDefault(x => x.Name == playerName);

        if (playerToBeRemoved == null)
        {
            throw new ArgumentException($"Player {playerName} is not in {this.Name} team.");
        }

        players.Remove(playerToBeRemoved);
    }
}