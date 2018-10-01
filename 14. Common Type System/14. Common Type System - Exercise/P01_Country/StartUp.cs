namespace P01_Country
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var countries = new List<Country>()
            {
                new Country("Bulgaria", 7100000, 111000, "Sofia", "Plovdiv", "Varna"),
                new Country("USA", 300000000, 1200000, "New York", "Los Angeles", "San Francisco"),
                new Country("Bulgaria", 8000000, 10),
                new Country("Bulgaria", 8000000, 111000),
                new Country("Croatia", 8000000, 111000)
            };

            countries.Sort();

            foreach (var country in countries)
            {
                Console.WriteLine(country);
            }

            Country bg = new Country("Bulgaria", 7100000, 111000, "Sofia", "Plovdiv", "Varna");
            Country usa = new Country("USA", 300000000, 1200000, "New York", "Los Angeles", "San Francisco");
            Country bg2 = new Country("Bulgaria", 8000000, 10);
            Country bg3 = new Country("Bulgaria", 8000000, 111000);
            Country hr = new Country("Croatia", 8000000, 111000);

            Console.WriteLine();
            Console.WriteLine(bg == bg2); // True
            Console.WriteLine(bg == usa); // False
            Console.WriteLine(bg != bg2); // False
            Console.WriteLine(bg != usa); // True

            var bgCopy = bg.Clone() as Country;
            bg.AddCity("Kaspichan");
            Console.WriteLine();
            Console.WriteLine(string.Join(", ", bg.Cities));
            Console.WriteLine(string.Join(", ", bgCopy.Cities));
        }
    }
}
