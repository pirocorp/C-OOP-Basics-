namespace P05_HTMLDispatcher
{
    using System;

    public class Validator
    {
        public static void ValidateStringNullEmptyOrWhite(string value, string nameOfProperty)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"{nameOfProperty} cannot be null, empty or whitespace.");
            }
        }
    }
}