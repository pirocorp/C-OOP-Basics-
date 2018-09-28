namespace P01_Predicates
{
    using System;
    using System.Collections.Generic;

    public class Predicates
    {
        static void Main()
        {
            var elements = new List<int>()
            {
                1, 2, 3, 4, 6, 11, 3,
            };

            Console.WriteLine(elements.FirstOrDefault(x => x > 7));
            Console.WriteLine(elements.FirstOrDefault(x => x < 0));
        }
    }
}
