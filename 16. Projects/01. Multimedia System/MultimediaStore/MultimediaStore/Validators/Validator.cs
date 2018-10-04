namespace MultimediaStore.Validators
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class Validator
    {
        public static void ValidateId(string nameOfProperty, string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException($"{nameOfProperty} cannot be null or empty.");
            }

            if (value.Length < 4)
            {
                throw new ArgumentOutOfRangeException($"{nameOfProperty} must be at least 4 characters long.");
            }
        }

        public static void ValidateTitle(string nameOfProperty, string value)
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
    }
}