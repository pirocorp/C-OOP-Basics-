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
    }
}