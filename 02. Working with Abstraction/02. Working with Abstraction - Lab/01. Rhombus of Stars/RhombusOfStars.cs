namespace _01._Rhombus_of_Stars
{
    using System;

    public class RhombusOfStars
    {
        public static void Main()
        {
            var rombusSize = int.Parse(Console.ReadLine());

            for (var stars = 1; stars <= rombusSize; stars++)
            {
                PrintLine(rombusSize, stars, Console.WriteLine);
            }

            for (var stars = rombusSize - 1; stars > 0; stars--)
            {
                PrintLine(rombusSize, stars, Console.WriteLine);
            }
        }

        private static void PrintLine(int rombusSize, int starsCount, Action<string> printOutput)
        {
            var whitespacesCount = rombusSize - starsCount;
            var stars = new string('*', starsCount).ToCharArray();
            var line = $"{new string(' ', whitespacesCount)}{string.Join(" ", stars)}";
            printOutput(line);
        }
    }
}