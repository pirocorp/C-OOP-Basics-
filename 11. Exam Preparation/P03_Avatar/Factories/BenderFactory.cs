using System;
using System.Collections.Generic;

public class BenderFactory
{
    public Bender CreateBender(List<string> benderArgs)
    {
        Bender newBender = null;

        var type = benderArgs[0];
        var name = benderArgs[1];
        var power = int.Parse(benderArgs[2]);
        var secondaryParameter = double.Parse(benderArgs[3]);

        switch (type)
        {
            case "Air":
                newBender = new AirBender(name, power, secondaryParameter);
                break;
            case "Water":
                newBender = new WaterBender(name, power, secondaryParameter);
                break;
            case "Fire":
                newBender = new FireBender(name, power, secondaryParameter);
                break;
            case "Earth":
                newBender = new EarthBender(name, power, secondaryParameter);
                break;
            default:
                throw new NotSupportedException();
        }

        return newBender;
    }
}