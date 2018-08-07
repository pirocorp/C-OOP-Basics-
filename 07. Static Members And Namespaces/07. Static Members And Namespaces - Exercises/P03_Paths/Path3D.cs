namespace P03_Paths
{
    using System;
    using System.Collections.Generic;
    using P01_Point3D;

    public class Path3D
    {
        public Path3D(List<Point3D> pointsInSpace)
        {
            this.PointsInSpace = pointsInSpace;
        }

        public List<Point3D> PointsInSpace { get; set; }

        public static Path3D Parse(string input)
        {
            var tokens = input.Split("} {", StringSplitOptions.RemoveEmptyEntries);

            var points = new List<Point3D>();

            foreach (var pointInput in tokens)
            {
                var currentPoint = Point3D.Parse(pointInput);
                points.Add(currentPoint);
            }

            return new Path3D(points);
        }

        public override string ToString()
        {
            return $"{string.Join(", ", PointsInSpace)}";
        }
    }
}