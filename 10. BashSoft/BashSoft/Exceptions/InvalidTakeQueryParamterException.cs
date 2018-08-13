namespace BashSoft.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class InvalidTakeQueryParamterException : Exception
    {
        private const string INVALID_TAKE_QUERY_PARAMTER = "The take command expected does not match the format wanted!";

        public InvalidTakeQueryParamterException()
            :base(INVALID_TAKE_QUERY_PARAMTER)
        {
        }

        public InvalidTakeQueryParamterException(string message) 
            : base(message)
        {
        }
    }
}