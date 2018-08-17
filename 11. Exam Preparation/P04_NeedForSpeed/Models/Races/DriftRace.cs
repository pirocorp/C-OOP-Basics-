using System.Collections.Generic;
using System.Linq;

public class DriftRace : Race
{
    public DriftRace(int length, string route, int prizePool) 
        : base(length, route, prizePool)
    {
    }

    protected override List<string> FinishingList => this.Participants
        .OrderByDescending(x => x.SuspensionPerformance)
        .Select(x => $"{{0}}. {x.Brand} {x.Model} {x.SuspensionPerformance}PP - ${{1}}")
        .ToList();
}