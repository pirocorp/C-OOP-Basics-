namespace P01_Point3D
{
    using System;

    public class Startup
    {
        static void Main()
        {
            var p1 = new Point3D(3, 4, 5);

            Console.WriteLine(p1);
            Console.WriteLine(Point3D.GetStartingPoint);
        }
    }
}