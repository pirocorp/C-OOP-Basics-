namespace _11._Cat_Lady
{
    using System;
    using System.Collections.Generic;
    
    public class CatLady
    {
        public static void Main(string[] args)
        {
            var inputLine = string.Empty;

            var cats = new Dictionary<string, Cat>();

            while ((inputLine = Console.ReadLine()) != "End")
            {
                var tokens = inputLine.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                var name = tokens[1];

                cats.Add(name, Cat.Parse(tokens));
            }

            var searchedCat = Console.ReadLine();
            Console.WriteLine(cats[searchedCat]);
        }
    }
}
