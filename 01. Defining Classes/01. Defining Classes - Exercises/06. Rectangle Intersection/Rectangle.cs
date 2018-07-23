using System;

namespace _06._Rectangle_Intersection
{
    public class Rectangle
    {
        public Rectangle(string id, double width, double height, double topX, double topY)
        {
            this.id = id;
            this.width = width;
            this.height = height;
            this.topX = topX;
            this.topY = topY;
        }

        private string id;
        private double width;
        private double height;
        private double topX;
        private double topY;
        
        public string Id
        {
            get => id;
            set => id = value;
        }

        public double Width
        {
            get => width;
            set => width = value;
        }

        public double Height
        {
            get => height;
            set => height = value;
        }

        public double TopX
        {
            get => topX;
            set => topX = value;
        }

        public double TopY
        {
            get => topY;
            set => topY = value;
        }

        public static Rectangle Parse(string input)
        {
            var tokens = input.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

            var id = tokens[0];
            var width = double.Parse(tokens[1]);
            var height = double.Parse(tokens[2]);
            var topX = double.Parse(tokens[3]);
            var topY = double.Parse(tokens[4]);

            return new Rectangle(id, width, height, topX, topY);
        }

        public bool Intersect(Rectangle inputRectangle)
        {
            var firstRectangleTopX = this.TopX;
            var firstRectangleTopY = this.TopY;
            var firstRectangleBottomX = this.topX + this.width;
            var firstRectangleBottomY = this.topY + this.height;

            var firstMinX = Math.Min(firstRectangleTopX, firstRectangleBottomX);
            var firstMaxX = Math.Max(firstRectangleTopX, firstRectangleBottomX);
            var firstMinY = Math.Min(firstRectangleTopY, firstRectangleBottomY);
            var firstMaxY = Math.Max(firstRectangleTopY, firstRectangleBottomY);

            var secondRectangleTopX = inputRectangle.TopX;
            var secondRectangleTopY = inputRectangle.TopY;
            var secondRectangleBottomX = inputRectangle.TopX + inputRectangle.width;
            var secondRectangleBottomY = inputRectangle.TopY + inputRectangle.height;

            var secondMinX = Math.Min(secondRectangleTopX, secondRectangleBottomX);
            var secondMaxX = Math.Max(secondRectangleTopX, secondRectangleBottomX);
            var secondMinY = Math.Min(secondRectangleTopY, secondRectangleBottomY);
            var secondMaxY = Math.Max(secondRectangleTopY, secondRectangleBottomY);

            var noOverlap = firstMinX > secondMaxX || secondMinX > firstMaxX ||
                            firstMinY > secondMaxY || secondMinY > firstMaxY;

            return !noOverlap;
        }
    }
}
