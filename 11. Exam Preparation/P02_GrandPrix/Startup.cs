using System;

public class Startup
{
    public static void Main()
    {
        var numberOfLaps = int.Parse(Console.ReadLine());
        var trackLength = int.Parse(Console.ReadLine());

        var raceTower = new RaceTower();
        raceTower.SetTrackInfo(numberOfLaps, trackLength);

        var engine = new Engine(raceTower);
        engine.Run();
    }
}