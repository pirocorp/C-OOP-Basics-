namespace P02_DistanceCalculator
{
    using System;
    using P02_DistanceCalculator;

    public class Startup
    {
        public static void Main()
        {
            var point1 = new Point3D(1, 1, 0);
            var point2 = new Point3D(2, 1, 2);

            Console.WriteLine(point1.DistanceToPoint(point2));
            Console.WriteLine(point2.DistanceToPoint(point1));
        }
    }
}
