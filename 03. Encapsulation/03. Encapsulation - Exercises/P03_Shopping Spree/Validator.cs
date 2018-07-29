using System;

public static class Validator
{
    public static void ValidateMoney(decimal value)
    {
        if (value < 0)
        {
            throw new ArgumentException($"Money cannot be negative");
        }
    }

    public static void ValidateName(string value)
    {
        if (string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"Name cannot be empty");
        }
    }
}