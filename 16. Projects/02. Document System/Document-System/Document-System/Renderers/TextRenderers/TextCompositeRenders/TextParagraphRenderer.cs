namespace Document_System.Renderers.TextRenderers.TextCompositeRenders
{
    using System.IO;
    using Elements.CompositeElements;

    public class TextParagraphRenderer : TextRenderer
    {
        private Paragraph paragraph;

        public TextParagraphRenderer(Paragraph paragraph)
        {
            this.paragraph = paragraph;
        }

        public override void Render(TextWriter writer)
        {
            writer.WriteLine();
        }
    }
}