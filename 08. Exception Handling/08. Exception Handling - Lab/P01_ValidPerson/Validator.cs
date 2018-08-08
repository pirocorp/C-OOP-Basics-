namespace P01_ValidPerson
{
    using System;

    public static class Validator
    {
        public static void StringIsNullOrEmpty(string value, string nameOfProperty)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(nameOfProperty, $"{nameOfProperty} cannot be null or empty.");
            }
        }

        public static void ValidateAge(int value, string nameOfProperty)
        {
            if (value < 0 || value > 120)
            {
                throw new ArgumentOutOfRangeException(nameOfProperty, $"{nameOfProperty} should be in range [0...120].");
            }
        }
    }
}