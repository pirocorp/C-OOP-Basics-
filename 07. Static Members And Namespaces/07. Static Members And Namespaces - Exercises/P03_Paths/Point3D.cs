namespace P01_Point3D
{
    using System;
    using System.Linq;

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

        public static Point3D Parse(string inputData)
        {
            var tokens = inputData
                .Split(new[] {"{", "}", ", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            var x = tokens[0];
            var y = tokens[1];
            var z = tokens[2];

            return new Point3D(x, y, z);
        }

        public override string ToString()
        {
            return $"{{{this.X}, {this.Y}, {this.Z}}}";
        }
    }
}