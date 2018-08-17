using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CircuitRace : Race
{
    private int laps;

    public CircuitRace(int length, string route, int prizePool, int laps) 
        : base(length, route, prizePool)
    {
        this.laps = laps;
    }

    protected override List<string> FinishingList => this.Participants
        .OrderByDescending(x => x.OverallPerformance)
        .Select(x => $"{{0}}. {x.Brand} {x.Model} {x.OverallPerformance}PP - ${{1}}")
        .ToList();

    

    public override string RaceResult()
    {
        this.CalculateDurabilityForEachParticipant();

        Car[] topParticipants = null;

        if (this.Participants.Count > 4)
        {
            topParticipants = this.Participants
                .OrderByDescending(x => x.OverallPerformance)
                .Take(4)
                .ToArray();
        }
        else
        {
            topParticipants = this.Participants
                .OrderByDescending(x => x.OverallPerformance)
                .ToArray();
        }

        var sb = new StringBuilder();

        sb.AppendLine($"{this.Route} - {this.Length * this.laps}");

        var position = 0;
        var prizes = this.CalculatePrizes();

        foreach (var winner in topParticipants)
        {
            var currentPrize = prizes[position];
            sb.AppendLine(
                $"{++position}. {winner.Brand} {winner.Model} {winner.OverallPerformance}PP - ${currentPrize}");
        }

        return sb.ToString().TrimEnd();
    }

    private void CalculateDurabilityForEachParticipant()
    {
        //Overal Performance (this.HorsePower / this.Acceleration) + (this.Suspension + this.Durability)
        var amortization = this.Length * this.Length * this.laps;

        foreach (var participant in this.Participants)
        {
            participant.Amortization(amortization);
        }
    }

    private int[] CalculatePrizes()
    {
        var firstPrize = (40 * this.PrizePool) / 100;
        var secondPrize = (30 * this.PrizePool) / 100;
        var thirdPrize = (20 * this.PrizePool) / 100;
        var fourthPrize = (10 * this.PrizePool) / 100;

        return new[] { firstPrize, secondPrize, thirdPrize, fourthPrize};
    }
}