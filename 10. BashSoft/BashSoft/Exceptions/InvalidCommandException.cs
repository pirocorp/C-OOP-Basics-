namespace BashSoft.Exceptions
{
    using System;

    public class InvalidCommandException : Exception
    {
        private const string INVALID_COMMAND = "The command {0} is invalid!";

        public InvalidCommandException(string command) 
            : base(string.Format(INVALID_COMMAND, command))
        {
        }
    }
}