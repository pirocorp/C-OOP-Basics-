﻿namespace BashSoft.Exceptions
{
    using System;

    public class InvalidFileNameException : Exception
    {
        private const string FORBIDDEN_SYMBOLS_CONTAINED_IN_NAME =
            "The given name contains symbols that are not allowed to be used in names of files and folders.";

        public InvalidFileNameException() 
            : base(FORBIDDEN_SYMBOLS_CONTAINED_IN_NAME)
        {
        }

        public InvalidFileNameException(string message) 
            : base(message)
        {
        }
    }
}