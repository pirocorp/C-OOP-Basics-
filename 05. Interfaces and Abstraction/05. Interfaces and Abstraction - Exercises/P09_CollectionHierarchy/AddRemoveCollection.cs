namespace P09_CollectionHierarchy
{
    using Interfaces;
    using System.Linq;

    public class AddRemoveCollection : AddCollection, IAddRemoveCollection
    {
        private const int IndexForAddingNewElement = 0;

        public virtual string Remove()
        {
            var lastElement = this.Data.Last();
            this.Data.RemoveAt(this.Data.Count - 1);
            return lastElement;
        }

        public override int Add(string element)
        {
            this.Data.Insert(IndexForAddingNewElement, element);
            return IndexForAddingNewElement;
        }
    }
}
