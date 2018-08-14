using System;
using System.Collections.Generic;

public class HarvesterFactory
{
    public Harvester MakeHarvester(List<string> arguments)
    {
        var type = arguments[0];
        var id = arguments[1];
        var oreOutput = double.Parse(arguments[2]);
        var energyRequirement = double.Parse(arguments[3]);

        Harvester currentHarvester = null;

        switch (type)
        {
            case "Sonic":
                var sonicFactor = int.Parse(arguments[4]);
                currentHarvester = new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);
                break;
            case "Hammer":
                currentHarvester = new HammerHarvester(id, oreOutput, energyRequirement);
                break;
            default:
                throw new NotSupportedException();
        }

        return currentHarvester;
    }
}