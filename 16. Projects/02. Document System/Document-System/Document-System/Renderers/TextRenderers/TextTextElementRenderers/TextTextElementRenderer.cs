namespace Document_System.Renderers.TextRenderers.TextTextElementRenderers
{
    using System.IO;
    using Elements.TextElements;

    public class TextTextElementRenderer : TextRenderer
    {
        private readonly TextElement textElement;

        public TextTextElementRenderer(TextElement textElement)
        {
            this.textElement = textElement;
        }

        public override void Render(TextWriter writer)
        {
            writer.Write(this.textElement.Text);
        }
    }
}