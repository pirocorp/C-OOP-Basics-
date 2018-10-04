namespace MultimediaStore.Models.Items
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;
    using Validators;

    public class Book : Item
    {
        private string author;

        public Book(string id, string title, decimal price, string author, List<string> genres)
            : base(id, title, price, genres)
        {
            this.Author = author;
        }

        public Book(string id, string name, decimal price, string author, string genre)
            : this(id, name, price, author, new List<string> { genre })
        {
        }

        public string Author
        {
            get => this.author;
            private set
            {
                Validator.ValidateAuthor(nameof(this.Author), value);
                this.author = value;
            }
        }


        public static Book Parse(string paramsString)
        {
            var itemParams = GetItemParams(paramsString);

            var id = itemParams["id"];
            var title = itemParams["title"];
            var author = itemParams["author"];
            var price = decimal.Parse(itemParams["price"]);
            var genre = itemParams["genre"];

            var book = new Book(id, title, price, author, genre);
            return book;
        }
    }
}