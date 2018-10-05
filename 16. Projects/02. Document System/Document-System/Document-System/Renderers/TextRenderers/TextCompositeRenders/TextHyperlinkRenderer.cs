namespace Document_System.Renderers.TextRenderers.TextCompositeRenders
{
    using System.IO;
    using Elements.CompositeElements;

    public class TextHyperlinkRenderer : TextRenderer
    {
        private Hyperlink hyperlink;

        public TextHyperlinkRenderer(Hyperlink hyperlink)
        {
            this.hyperlink = hyperlink;
        }

        public override void Render(TextWriter writer)
        {
            writer.Write($"[url=\"{this.hyperlink.Url}\"]");
        }
    }
}