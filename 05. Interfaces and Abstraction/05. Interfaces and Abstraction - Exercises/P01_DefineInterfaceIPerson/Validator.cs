using System;

public static class Validator
{
    public static void ValidateString(string value, string nameOfProperty)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"{nameOfProperty} cannot be null, empty or white space");
        }
    }

    public static void ValidateAge(int value, string nameOfProperty)
    {
        if (value < 0 || value > 200)
        {
            throw new ArgumentException($"Age cannot be negative or more than 200");
        }
    }
}
