using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Race
{
    private List<Car> participants;

    public Race(int length, string route, int prizePool)
    {
        this.Length = length;
        this.Route = route;
        this.PrizePool = prizePool;
        this.participants = new List<Car>();
    }

    public int Length { get; set; }

    public string Route { get; set; }

    public int PrizePool { get; set; }

    public IReadOnlyCollection<Car> Participants => this.participants;

    protected abstract List<string> FinishingList { get; }

    public virtual void AddParticipant(Car newParticipant)
    {
        this.participants.Add(newParticipant);
        newParticipant.StartRace();
    }

    public virtual string RaceResult()
    {
        this.ParticipantsCompleteRace();

        this.TopParticipantsResult();

        return $"{this.Route} - {this.Length}" + Environment.NewLine +
               $"{this.TopParticipantsResult()}";
    }

    private string TopParticipantsResult()
    {
        var sb = new StringBuilder();

        var prizes = this.CalculatePrizes();

        List<string> topParticipants = null;

        if (this.FinishingList.Count > 3)
        {
            topParticipants = this.FinishingList
                .Take(3)
                .ToList();
        }
        else
        {
            topParticipants = this.FinishingList
                .ToList();
        }

        var position = 0;

        foreach (var car in topParticipants)
        {
            var currentPrize = prizes[position];
            sb.AppendLine(string.Format(car, ++position, currentPrize));
        }

        return sb.ToString().TrimEnd();
    }

    private int[] CalculatePrizes()
    {
        var firstPrize = (50 * this.PrizePool) / 100;
        var secondPrize = (30 * this.PrizePool) / 100;
        var thirdPrize = (20 * this.PrizePool) / 100;

        return new[] {firstPrize, secondPrize, thirdPrize};
    }

    private void ParticipantsCompleteRace()
    {
        foreach (var participant in this.Participants)
        {
            participant.EndRace(); 
        }
    }
}