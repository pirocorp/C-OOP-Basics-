namespace P09_CollectionHierarchy.Interfaces
{
    using System.Collections.Generic;

    public interface IMyList : IAddRemoveCollection
    {
        IReadOnlyCollection<string> Used { get; }
    }
}
