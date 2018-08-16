using System;
using System.Collections.Generic;

public class ProviderFactory
{
    public Provider MakeProvider(List<string> arguments)
    {
        var typeOfProvider = arguments[0];
        var id = arguments[1];
        var energyOutput = double.Parse(arguments[2]);

        Provider currentProvider = null;

        switch (typeOfProvider)
        {
            case "Solar":
                currentProvider = new SolarProvider(id, energyOutput);
                break;

            case "Pressure":
                currentProvider = new PressureProvider(id, energyOutput);
                break;

            default:
                throw new NotSupportedException();
        }

        return currentProvider;
    }
}