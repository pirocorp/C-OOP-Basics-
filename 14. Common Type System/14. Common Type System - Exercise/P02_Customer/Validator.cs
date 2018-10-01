namespace P02_Customer
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class Validator
    {
        public static void EmptyString(string nameOfProperty, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"{nameOfProperty} cannot be empty string.");
            }
        }

        public static void NegativeValue(string nameOfProperty, decimal value)
        {
            if (value < 0)
            {
                throw new ArgumentException($"{nameOfProperty} cannot be negative.");
            }
        }
    }
}