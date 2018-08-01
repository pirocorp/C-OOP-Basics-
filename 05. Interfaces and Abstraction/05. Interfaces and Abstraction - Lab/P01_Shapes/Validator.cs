using System;

public static class Validator
{
    public static void ValidateInt(int value, string nameOfProperty)
    {
        if (value <= 0)
        {
            throw new ArgumentException($"{nameOfProperty} cannot be negative or zero");
        }
    }
}