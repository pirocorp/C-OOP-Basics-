namespace Document_System.Elements.TextElements
{
    using System.IO;
    using Enums;
    using FontElements;
    using RendersFactories;
    using Utils;

    public class TextElement : Element
    {
        public TextElement(string text, Font font = null)
        {
            this.Text = text;
            this.Font = font;
        }

        public string Text { get; set; }

        public Font Font { get; set; }

        public override void Render(TextWriter writer, RenderTypes renderTypes)
        {
            var renderer = RenderFactory.Create(renderTypes, ElementTypes.TextElement, this);
            renderer.Render(writer);
        }
    }
}