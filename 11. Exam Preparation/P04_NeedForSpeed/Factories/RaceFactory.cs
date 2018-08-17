using System;

public class RaceFactory
{
    public Race CreaterRace(string type, int length, string route, int prizePool, params int[] aditionalParameter)
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
            case "Circuit":
                newRace = new CircuitRace(length, route, prizePool, aditionalParameter[0]);
                break;
            case "TimeLimit":
                newRace = new TimeLimitRace(length, route, prizePool, aditionalParameter[0]);
                break;
            default:
                throw new NotSupportedException();
        }

        return newRace;
    }
}