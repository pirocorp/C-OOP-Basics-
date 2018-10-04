namespace MultimediaStore.Models.Items
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Game : Item
    {
        private const AgeRestriction DEFAULT_AGE_RESTRICTION = AgeRestriction.Minor;

        public Game(string id, string title, decimal price, List<string> genres, AgeRestriction ageRestriction = DEFAULT_AGE_RESTRICTION)
            : base(id, title, price, genres)
        {
            this.AgeRestriction = ageRestriction;
        }

        public Game(string id, string name, decimal price, string genre, AgeRestriction ageRestriction = DEFAULT_AGE_RESTRICTION)
            : this(id, name, price, new List<string> { genre }, ageRestriction)
        {
        }

        public AgeRestriction AgeRestriction { get; private set; }

        public static Game Parse(string paramsString)
        {
            var itemParams = GetItemParams(paramsString);

            var id = itemParams["id"];
            var title = itemParams["title"];
            var price = decimal.Parse(itemParams["price"]);
            var genre = itemParams["genre"];
            var ageRestriction = ToEnum(itemParams["ageRestriction"]);

            var game = new Game(id, title, price, genre, ageRestriction);
            return game;
        }

        private static AgeRestriction ToEnum(string enumString)
        {
            return (AgeRestriction)Enum.Parse(typeof(AgeRestriction), enumString);
        }
    }
}