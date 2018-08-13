namespace BashSoft.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class NotANumberException : Exception
    {
        private const string UNABLE_TO_PARSE_NUMBER = "The sequence you've written is not a valid number.";

        public NotANumberException() 
            : base(UNABLE_TO_PARSE_NUMBER)
        {
        }

        public NotANumberException(string message) 
            : base(message)
        {
        }
    }
}