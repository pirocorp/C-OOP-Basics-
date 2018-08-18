namespace StorageMaster.Utilities
{
    using System;

    public static class Validator
    {
        public static void ValidatePrice(double value)
        {
            if (value < 0)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidPrice);
            }
        }
    }
}