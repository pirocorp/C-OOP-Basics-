namespace Document_System.Structure
{
    using System.IO;
    using Renderers;

    public class Font : IHtmlRenderer
    {
        private const string DEFAULT_FONT_NAME = "Arial";
        private const float DEFAULT_FONT_SIZE = 12;
        private const FontStyle DEFAULT_FONT_STYLE = FontStyle.Normal;

        public Font(string name = null, float? size = null, 
            FontStyle? style = null, Color color = null)
        {
            this.Name = name;
            this.Size = size;
            this.Style = style;
            this.Color = color;
        }

        private static Color DefaultFontColor => Color.Black;

        public static Font DefaultFont => new Font(DEFAULT_FONT_NAME, DEFAULT_FONT_SIZE, DEFAULT_FONT_STYLE, DefaultFontColor);

        public string Name { get; set; }

        public float? Size { get; set; }

        public FontStyle? Style { get; set; }

        public Color Color { get; set; }

        public void RenderHtml(TextWriter writer)
        {
            if (this.Name != null)
            {
                writer.Write($"font-family:{this.Name};");
            }

            if (this.Size != null)
            {
                writer.Write($"font-size:{this.Size}pt;");
            }

            if (this.Color != null)
            {
                writer.Write($"color:");
                this.Color.RenderHtml(writer);
                writer.Write(";");
            }

            if ((this.Style & FontStyle.Bold) == FontStyle.Bold)
            {
                writer.Write("font-weight:bold;");
            }

            if ((this.Style & FontStyle.Italic) == FontStyle.Italic)
            {
                writer.Write("font-style:italic;");
            }
        }
    }
}