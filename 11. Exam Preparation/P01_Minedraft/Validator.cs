using System;

public static class Validator
{
    public static void NotNegativeNumber(double value, string nameOfProperty)
    {
        if (value < 0)
        {
            throw new ArgumentException($"{nameOfProperty} cannot be negative!", nameOfProperty);
        }
    }

    public static void EnergyRequirement(double value, string nameOfProperty, double maxValue)
    {
        NotNegativeNumber(value, nameOfProperty);

        if (value > maxValue)
        {
            throw new ArgumentException($"{nameOfProperty} must be lower or equal to {maxValue}", nameOfProperty);
        }
    }

    public static void EnergyOutput(double value, string nameOfProperty, double maxValue)
    {
        if (value <= 0)
        {
            throw new ArgumentException($"{nameOfProperty} must be positive.", nameOfProperty);
        }

        if (value >= maxValue)
        {
            throw new ArgumentException($"{nameOfProperty} must be less then {maxValue}.", nameOfProperty);
        }
    }
}