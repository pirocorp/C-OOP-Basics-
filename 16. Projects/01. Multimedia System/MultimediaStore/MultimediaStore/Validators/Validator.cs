namespace MultimediaStore.Validators
{
    using System;

    public static class Validator
    {
        private const int DEFAULT_MIN_LENGTH_OF_ID = 4;
        private const int DEFAULT_MIN_LENGTH_OF_AUTHOR = 3;

        public static void ValidateId(string nameOfProperty, string value)
        {
            ValidateNonEmptyString(nameOfProperty, value);
            ValidateStringLength(nameOfProperty, value, DEFAULT_MIN_LENGTH_OF_ID);
        }

        public static void ValidateAuthor(string nameOfProperty, string value)
        {
            ValidateNonEmptyString(nameOfProperty, value);
            ValidateStringLength(nameOfProperty, value, DEFAULT_MIN_LENGTH_OF_AUTHOR);
        }

        private static void ValidateStringLength(string nameOfProperty, string value, int length)
        {
            if (value.Length < length)
            {
                throw new ArgumentOutOfRangeException($"{nameOfProperty} must be at least {length} characters long.");
            }
        }

        public static void ValidateNonEmptyString(string nameOfProperty, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException($"{nameOfProperty} cannot be null or empty.");
            }
        }

        public static void ValidatePrice(string nameOfProperty, decimal value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException($"{nameOfProperty} cannot be negative.");
            }
        }

        public static void ValidateObjectExist(string nameOfProperty, object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException($"{nameOfProperty} cannot be null.");
            }
        }

        public static void ValidateVideoLength(string nameOfProperty, double value)
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException($"{nameOfProperty} cannot be negative.");
            }
        }
    }
}