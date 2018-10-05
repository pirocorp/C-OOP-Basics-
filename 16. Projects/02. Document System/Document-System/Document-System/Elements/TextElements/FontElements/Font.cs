namespace Document_System.Elements.TextElements.FontElements
{
    using System.IO;
    using Enums;
    using Renderers;
    using RendersFactories;

    public class Font
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

        public void Render(TextWriter writer, RenderTypes renderTypes)
        {
            var renderer = RenderFactory.Create(renderTypes, ElementTypes.Font, this);
            renderer.Render(writer);
        }
    }
}