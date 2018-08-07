namespace P02_DistanceCalculator
{
    using System;

    public class Point3D
    {
        private static readonly Point3D StartingPoint;

        static Point3D()
        {
            StartingPoint = new Point3D();
        }

        public Point3D()
        {
            this.X = 0;
            this.Y = 0;
            this.Z = 0;
        }

        public Point3D(double x, double y, double z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public double Z { get; set; }

        public static Point3D GetStartingPoint => StartingPoint;

        public double DistanceToPoint(Point3D endPoint)
        {
            var distance = Math.Pow((endPoint.X - this.X), 2) + 
                           Math.Pow((endPoint.Y - this.Y), 2) +
                           Math.Pow((endPoint.Z - this.Z), 2);

            return Math.Sqrt(distance);
        }

        public override string ToString()
        {
            return $"{{{this.X}, {this.Y}, {this.Z}}}";
        }
    }
}