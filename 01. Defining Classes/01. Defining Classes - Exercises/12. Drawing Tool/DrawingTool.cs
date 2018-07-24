namespace _12._Drawing_Tool
{
    using System.Text;

    public class DrawingTool
    {
        public DrawingTool(int width, int height, string name)
        {
            this.width = width;
            this.height = height;
            this.name = name;
        }

        private int width;
        private int height;
        private string name;

        public string Draw()
        {
            var sb = new StringBuilder();

            sb.Append("|");
            sb.Append(new string('-', width));
            sb.AppendLine("|");

            for (var i = 0; i < height - 2; i++)
            {
                sb.Append("|");
                sb.Append(new string(' ', width));
                sb.AppendLine("|");
            }

            sb.Append("|");
            sb.Append(new string('-', width));
            sb.AppendLine("|");

            return sb.ToString();
        }
    }
}
