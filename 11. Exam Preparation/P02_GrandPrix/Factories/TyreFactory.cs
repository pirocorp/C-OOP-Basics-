using System;

public class TyreFactory
{
    public Tyre CreateTyre(string[] tyreArgs)
    {
        var tyreType = tyreArgs[0];
        var tyreHardness = double.Parse(tyreArgs[1]);

        Tyre tyre = null;

        if (tyreType == "Hard")
        {
            tyre = new HardTyre(tyreHardness);
        }
        else if (tyreType == "Ultrasoft")
        {
            var grip = double.Parse(tyreArgs[2]);

            tyre = new UltrasoftTyre(tyreHardness, grip);
        }

        if (tyre == null)
        {
            throw new ArgumentException("Invalid Tyre Type");
        }

        return tyre;
    }
}