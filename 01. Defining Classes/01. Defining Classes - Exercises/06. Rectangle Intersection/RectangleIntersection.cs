namespace _06._Rectangle_Intersection
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class RectangleIntersection
    {
        static void Main()
        {
            var tokens = Console.ReadLine().Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            var rectangles = new Dictionary<string, Rectangle>();

            var n = tokens[0];
            var m = tokens[1];

            for (var i = 0; i < n; i++)
            {
                var inputLine = Console.ReadLine();

                var rectangleId = inputLine
                    .Split(new []{" "}, StringSplitOptions.RemoveEmptyEntries)
                    .First();

                var currentRectangle = Rectangle.Parse(inputLine);

                rectangles[rectangleId] = currentRectangle;
            }

            for (var i = 0; i < m; i++)
            {
                var rectangleIds = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                var firstId = rectangleIds[0];
                var secondId = rectangleIds[1];

                var firstRectangle = rectangles[firstId];
                var secondRectangle = rectangles[secondId];

                Console.WriteLine(firstRectangle.Intersect(secondRectangle).ToString().ToLower());
            }
        }
    }
}
