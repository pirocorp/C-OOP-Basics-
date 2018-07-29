using System;

public class Player
{
    private string name;
    private int endurance;
    private int sprint;
    private int dribble;
    private int passing;
    private int shooting;

    public string Name
    {
        get => this.name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }

            this.name = value;
        }
    }

    public int Endurance
    {
        get => this.endurance;
        private set
        {
            CheckStatsValue(value, nameof(Endurance));
            this.endurance = value;
        }
    }

    public int Sprint
    {
        get => this.sprint;
        private set
        {
            CheckStatsValue(value, nameof(Sprint));
            this.sprint = value;
        }
    }

    public int Dribble
    {
        get => this.dribble;
        private set
        {
            CheckStatsValue(value, nameof(Dribble));
            this.dribble = value;
        }
    }

    public int Passing
    {
        get => this.passing;
        private set
        {
            CheckStatsValue(value, nameof(Passing));
            this.passing = value;
        }
    }

    public int Shooting
    {
        get => this.shooting;
        private set
        {
            CheckStatsValue(value, nameof(Shooting));
            this.shooting = value;
        }
    }

    public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
    {
        this.Name = name;
        this.Endurance = endurance;
        this.Sprint = sprint;
        this.Dribble = dribble;
        this.Passing = passing;
        this.Shooting = shooting;
    }

    private static void CheckStatsValue(int value, string statName)
    {
        if (value < 0 || value > 100)
        {
            throw new ArgumentException($"{statName} should be between 0 and 100.");
        }
    }
}