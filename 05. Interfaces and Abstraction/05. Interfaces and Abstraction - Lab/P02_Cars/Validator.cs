using System;

public static class Validator
{
    public static void ValidateString(string input, string nameOfProperty)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            throw new ArgumentException($"{nameOfProperty} cannot be null, empty or white space!");
        }
    }

    public static void ValidateBatteryCount(int batteryCount, string nameOfProperty)
    {
        if (batteryCount <= 0)
        {
            throw new ArgumentException($"{nameOfProperty} count cannot be zero or negative!");
        }
    }
}