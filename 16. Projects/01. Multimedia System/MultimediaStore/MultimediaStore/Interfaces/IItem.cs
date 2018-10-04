namespace MultimediaStore.Interfaces
{
    using System.Collections.Generic;

    public interface IItem
    {
        string Id { get; }

        string Title { get; }

        decimal Price { get; }

        IReadOnlyCollection<string> Genres { get; }
    }
}
