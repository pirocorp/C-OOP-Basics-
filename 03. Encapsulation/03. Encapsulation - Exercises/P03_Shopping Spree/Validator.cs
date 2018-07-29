using System;

public static class Validator
{
    public static void ValidateMoney(decimal value)
    {
        throw new ArgumentException($"Money cannot be negative");
    }

    public static void ValidateName(string value)
    {
        throw new ArgumentException($"Name cannot be empty");
    }
}