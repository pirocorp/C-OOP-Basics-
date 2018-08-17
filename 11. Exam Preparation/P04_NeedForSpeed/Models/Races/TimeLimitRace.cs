using System;
using System.Collections.Generic;
using System.Linq;

public class TimeLimitRace : Race
{
    private int goldTime;

    public TimeLimitRace(int length, string route, int prizePool, int goldTime) 
        : base(length, route, prizePool)
    {
        this.goldTime = goldTime;
    }

    protected override List<string> FinishingList => this.Participants
        .Select(x => $"{x.Brand} {x.Model} - {this.TimePerformance} s.")
        .ToList();

    private int TimePerformance => this.Length * (this.Participants.First().TimePerformance);

    public override void AddParticipant(Car newParticipant)
    {
        if (this.Participants.Count > 0)
        {
            throw new ArgumentException();
        }

        base.AddParticipant(newParticipant);
    }

    private string EarnedTime()
    {
        var tp = this.TimePerformance;

        if (tp <= this.goldTime)
        {
            return $"Gold";
        }
        else if (tp <= this.goldTime + 15)
        {
            return $"Silver";
        }
        else
        {
            return $"Bronze";
        }
    }

    private Dictionary<string, int> CalculatePrizes()
    {
        var result = new Dictionary<string, int>();

        var goldPrize = this.PrizePool;
        var silverPrize = (this.PrizePool * 50) / 100;
        var bronzePrize = (this.PrizePool * 30) / 100;

        result["Gold"] = goldPrize;
        result["Silver"] = silverPrize;
        result["Bronze"] = bronzePrize;

        return result;
    }

    public override string RaceResult()
    {
        return $"{this.Route} - {this.Length}" + Environment.NewLine +
               $"{this.Participants.First().Brand} {this.Participants.First().Model} - {this.TimePerformance} s." + Environment.NewLine +
               $"{this.EarnedTime()} Time, ${this.CalculatePrizes()[this.EarnedTime()]}." + Environment.NewLine;
    }
}