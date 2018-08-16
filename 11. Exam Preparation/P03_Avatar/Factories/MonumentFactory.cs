using System;
using System.Collections.Generic;

public class MonumentFactory
{
    public Monument CreateMonument(List<string> monumentArgs)
    {
        var type = monumentArgs[0];
        var name = monumentArgs[1];
        var affinity = int.Parse(monumentArgs[2]);

        Monument newMonument = null;

        switch (type)
        {
            case "Air":
                newMonument = new AirMonument(name, affinity);
                break;
            case "Water":
                newMonument = new WaterMonument(name, affinity);
                break;
            case "Fire":
                newMonument = new FireMonument(name, affinity);
                break;
            case "Earth":
                newMonument = new EarthMonument(name, affinity);
                break;
            default:
                throw new NotSupportedException();
        }

        return newMonument;
    }
}