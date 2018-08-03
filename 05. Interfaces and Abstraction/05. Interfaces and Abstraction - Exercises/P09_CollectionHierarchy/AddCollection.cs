namespace P09_CollectionHierarchy
{
    using Interfaces;
    using System.Collections.Generic;

    public class AddCollection : IAddCollection
    {
        public AddCollection()
        {
            this.Data = new List<string>();
        }

        protected List<string> Data { get; set; }

        public virtual int Add(string element)
        {
            this.Data.Add(element);
            return this.Data.Count - 1;
        }
    }
}