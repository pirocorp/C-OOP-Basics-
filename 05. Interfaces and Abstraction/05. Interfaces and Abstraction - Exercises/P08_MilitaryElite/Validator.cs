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

    public static void ValidateSalary(decimal value, string nameOfProperty)
    {
        if (value < 0)
        {
            throw new ArgumentException($"{nameOfProperty} cannot be negative");
        }
    }
}