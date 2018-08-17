using System;

public class RaceFactory
{
    public Race CreaterRace(string type, int length, string route, int prizePool)
    {
        Race newRace = null;

        switch (type)
        {
            case "Casual":
                newRace = new CasualRace(length, route, prizePool);
                break;
            case "Drag":
                newRace = new DragRace(length, route, prizePool);
                break;
            case "Drift":
                newRace = new DriftRace(length, route, prizePool);
                break;
            default:
                throw new NotSupportedException();
        }

        return newRace;
    }
}