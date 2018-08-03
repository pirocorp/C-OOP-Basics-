namespace P09_CollectionHierarchy
{
    using System.Collections.Generic;
    using Interfaces;
    using System.Linq;

    public class MyList : AddRemoveCollection, IMyList
    {
        private const int RemovalIndex = 0;

        public IReadOnlyCollection<string> Used => this.Data;

        public override string Remove()
        {
            var firstElemennt = this.Data.First();
            this.Data.RemoveAt(RemovalIndex);
            return firstElemennt;
        }
    }
}