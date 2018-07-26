namespace _02._Point_in_Rectangle
{
    using System;
    using System.Linq;

    public class Point
    {
        private int x;
        private int y;

        public int X => x;
        public int Y => y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Point Parse(string input)
        {
            var tokens = input
                .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .Select(int.Parse)
                .ToArray();

            return Parse(tokens);
        }

        public static Point Parse(int[] tokens)
        {
            var x = tokens[0];
            var y = tokens[1];

            return new Point(x, y);
        }
    }
}