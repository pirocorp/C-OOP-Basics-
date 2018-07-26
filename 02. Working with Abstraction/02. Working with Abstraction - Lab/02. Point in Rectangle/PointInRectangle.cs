namespace _02._Point_in_Rectangle
{
    using System;

    public class PointInRectangle
    {
        public static void Main()
        {
            var rectangle = Rectangle.Parse(Console.ReadLine());

            var n = int.Parse(Console.ReadLine());

            for (var i = 0; i < n; i++)
            {
                var currentPoint = Point.Parse(Console.ReadLine());
                Console.WriteLine(rectangle.PointInRectangle(currentPoint));
            }
        }
    }
}
