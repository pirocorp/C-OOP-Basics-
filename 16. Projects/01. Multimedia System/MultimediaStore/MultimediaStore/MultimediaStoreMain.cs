namespace MultimediaStore
{
    using System.Collections.Generic;
    using Models.Items;

    public class MultimediaStoreMain
    {
        public static void Main()
        {
            Item sallingerBook = new Book("4adwlj4", "Catcher in the Rye", 20.00m, "J. D. Salinger", "fiction");
            Item threeManBook = new Book("84djesd", "Three Men in a Boat", 39.99m, "Jerome K. Jerome", new List<string> { "comedy" });
            Item acGame = new Game("9gkjdsa", "AC Revelations", 78.00m, "historical", AgeRestriction.Teen);
            Item bubbleSplashGame = new Game("r8743jf", "Bubble Splash", 7.80m, new List<string> { "child", "fun" });
            Item godfatherMovie = new Movie("483252j", "The Godfather", 99.00m, 178, "crime");
            Item dieHardMovie = new Movie("9853kfds", "Die Hard 4", 9.90m, 144, new List<string> { "action", "crime", "thriller" });

        }
    }
}
