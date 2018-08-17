using System;
using System.Collections.Generic;

public class PerformanceCar : Car
{
    private const int HORSE_POWER_MODIFIER = 50;
    private const int SUSPENSION_MODIFIER = 25;

    private List<string> addOns;

    public PerformanceCar(string brand, string model, int yearOfProduction, int horsePower, int acceleration, int suspension, int durability)
        : base(brand, model, yearOfProduction, HorsePowerModifier(horsePower), acceleration, SuspensionModifier(suspension), durability)
    {
        this.addOns = new List<string>();
    }

    public IReadOnlyCollection<string> AddOns => this.addOns;

    private static int HorsePowerModifier(int horsePower)
    {
        var addition = (horsePower * HORSE_POWER_MODIFIER) / 100;
        var result = horsePower + addition;
        return result;
    }

    private static int SuspensionModifier(int suspension)
    {
        var subtraction = (suspension * SUSPENSION_MODIFIER) / 100;
        var result = suspension - subtraction;
        return result;
    }

    public override void Tune(int tuneIndex, string addOn)
    {
        base.Tune(tuneIndex, addOn);
        this.addOns.Add(addOn);
    }

    public override string ToString()
    {
        var result = string.Empty;

        if (this.addOns.Count > 0)
        {
            result = string.Join(", ", this.addOns);
        }
        else
        {
            result = "None";
        }

        return $"{base.ToString()}" + Environment.NewLine +
               $"Add-ons: {result}";
    }
}