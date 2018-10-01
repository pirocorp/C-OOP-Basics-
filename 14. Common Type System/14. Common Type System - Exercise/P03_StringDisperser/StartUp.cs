namespace P03_StringDisperser
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var stringDisperser = new StringDisperser("gosho", "pesho", "tanio");

            Console.WriteLine(stringDisperser);

            var dispersers = new List<StringDisperser>()
            {
                new StringDisperser("az", "buz", "guz"),
                new StringDisperser("chervenkoc", "torbalan"),
                new StringDisperser("zelentaifun", "gorskipojar"),
                new StringDisperser("Ah", "toz", "shit")
            };

            PrintDispersers(dispersers);

            dispersers.Sort();

            PrintDispersers(dispersers);

        }

        private static void PrintDispersers(List<StringDisperser> dispersers)
        {
            Console.WriteLine();
            foreach (var disperser in dispersers)
            {
                foreach (var ch in disperser)
                {
                    Console.Write($"{ch} ");
                }

                Console.WriteLine();
            }
        }
    }
}
