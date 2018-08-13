namespace BashSoft.Exceptions
{
    using System;

    public class DuplicateEntryInStructureException : Exception
    {
        private const string DUPLICATE_ENTRY = "The {0} already exists in {1}.";

        public DuplicateEntryInStructureException(string entry, string structure) 
            : base(string.Format(DUPLICATE_ENTRY, entry, structure))
        {
        }

        public DuplicateEntryInStructureException(string message) 
            : base(message)
        {
        }
    }
}