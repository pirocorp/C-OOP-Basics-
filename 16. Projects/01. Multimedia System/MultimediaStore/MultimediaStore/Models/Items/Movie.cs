namespace MultimediaStore.Models.Items
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Validators;

    public class Movie : Item
    {
        private double length;

        public Movie(string id, string title, decimal price, double length, List<string> genres)
            : base(id, title, price, genres)
        {
            this.Length = length;
        }

        public Movie(string id, string name, decimal price, double length, string genre)
            : this(id, name, price, length, new List<string> { genre })
        {
        }

        public double Length
        {
            get => this.length;
            private set
            {
                Validator.ValidateVideoLength(nameof(this.Length), value);
                this.length = value;
            }
        }

        public static Movie Parse(string paramsString)
        {
            var itemParams = GetItemParams(paramsString);

            var id = itemParams["id"];
            var title = itemParams["title"];
            var price = decimal.Parse(itemParams["price"]);
            var genre = itemParams["genre"];
            var length = int.Parse(itemParams["length"]);

            var movie = new Movie(id, title, price, length, genre);
            return movie;
        }
    }
}