namespace _02._Point_in_Rectangle
{
    using System;
    using System.Linq;

    public class Rectangle
    {
        private Point topLeft;
        private Point bottomRight;

        public Rectangle(Point topLeft, Point bottomRight)
        {
            this.topLeft = topLeft;
            this.bottomRight = bottomRight;
        }

        public static Rectangle Parse(string inputLine)
        {
            var tokens = inputLine
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .Select(int.Parse)
                .ToArray();

            var firstArray = tokens.Take(tokens.Length / 2).ToArray();
            var secondArray = tokens.Skip(tokens.Length / 2).ToArray();

            var topLeft = Point.Parse(firstArray);
            var bottomRight = Point.Parse(secondArray);

            return new Rectangle(topLeft, bottomRight);
        }

        public bool PointInRectangle(Point point)
        {
            var pointX = point.X;
            var pointY = point.Y;

            var xCordinate = pointX >= this.topLeft.X && pointX <= this.bottomRight.X;
            var yCordinate = pointY >= this.topLeft.Y && pointY <= this.bottomRight.Y;

            return xCordinate && yCordinate;
        }
    }
}