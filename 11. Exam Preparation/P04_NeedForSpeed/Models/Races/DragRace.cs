using System.Collections.Generic;
using System.Linq;

public class DragRace : Race
{
    public DragRace(int length, string route, int prizePool) 
        : base(length, route, prizePool)
    {
    }

    protected override List<string> FinishingList => this.Participants
        .OrderByDescending(x => x.EnginePerformance)
        .Select(x => $"{{0}}. {x.Brand} {x.Model} {x.EnginePerformance}PP - ${{1}}")
        .ToList();
}