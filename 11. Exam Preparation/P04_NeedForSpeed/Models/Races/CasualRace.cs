using System.Collections.Generic;
using System.Linq;

public class CasualRace : Race
{
    public CasualRace(int length, string route, int prizePool) 
        : base(length, route, prizePool)
    {
    }

    protected override List<string> FinishingList => this.Participants
        .OrderByDescending(x => x.OverallPerformance)
        .Select(x => $"{{0}}. {x.Brand} {x.Model} {x.OverallPerformance}PP - ${{1}}")
        .ToList();
}