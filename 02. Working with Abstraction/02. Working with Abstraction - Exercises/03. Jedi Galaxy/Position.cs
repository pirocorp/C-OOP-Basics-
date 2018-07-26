namespace _03._Jedi_Galaxy
{
    public class Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Position Parse(int[] input)
        {
            var x = input[0];
            var y = input[1];

            return new Position(x, y);
        }
    }
}