namespace Document_System.Renderers.HtmlRenderers.HtmlCompositeRenders
{
    using System.IO;
    using Elements.CompositeElements;

    public class HtmlParagraphRenderer : HtmlRenderer
    {
        private Paragraph paragraph;

        public HtmlParagraphRenderer(Paragraph paragraph)
        {
            this.paragraph = paragraph;
        }

        public override void Render(TextWriter writer)
        {
            writer.WriteLine();
            writer.Write("<p>");
        }
    }
}