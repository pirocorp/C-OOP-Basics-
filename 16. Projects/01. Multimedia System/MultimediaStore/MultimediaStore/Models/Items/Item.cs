namespace MultimediaStore.Models.Items
{
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;
    using Validators;

    public abstract class Item : IItem
    {
        private string id;
        private string title;
        private decimal price;
        private readonly List<string> genres;

        protected Item(string id, string title, decimal price)
            : this(id, title, price, new List<string>())
        {
        }

        protected Item(string id, string title, decimal price, List<string> genres)
        {
            this.Id = id;
            this.Title = title;
            this.Price = price;
            this.genres = genres;
        }

        public string Id
        {
            get => this.id;
            private set
            {
                Validator.ValidateId(nameof(this.Id), value);
                this.id = value;
            }
        }

        public string Title
        {
            get => this.title;
            private set
            {
                Validator.ValidateNonEmptyString(nameof(this.Title), value);
                this.title = value;
            }
        }

        public decimal Price
        {
            get => this.price;
            private set
            {
                Validator.ValidatePrice(nameof(this.Price), value);
                this.price = value;
            }
        }

        public IReadOnlyCollection<string> Genres => this.genres;

        protected static IDictionary<string, string> GetItemParams(string paramsString)
        {
            var keyValuePairs = new Dictionary<string, string>();
            var pairs = paramsString.Split('&');

            foreach (var pair in pairs)
            {
                var keyValuePair = pair.Split('=');
                keyValuePairs[keyValuePair[0]] = keyValuePair[1];
            }

            return keyValuePairs;
        }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"{this.GetType().Name} {this.Id}");
            result.AppendLine($"Title: {this.Title}");
            result.AppendLine($"Price: {this.Price:F2}");
            result.AppendLine($"Genres: {string.Join(", ", this.Genres)}");

            return result.ToString();
        }
    }
}