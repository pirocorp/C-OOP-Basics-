namespace DungeonsAndCodeWizards.Utilities
{
    using System;

    public static class Validator
    {
        public static void ValidateName(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.InvalidName);
            }
        }
    }
}