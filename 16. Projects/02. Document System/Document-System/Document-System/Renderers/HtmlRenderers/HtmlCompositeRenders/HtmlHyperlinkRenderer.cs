namespace Document_System.Renderers.HtmlRenderers.HtmlCompositeRenders
{
    using System.IO;
    using Elements.CompositeElements;
    using Utils;

    public class HtmlHyperlinkRenderer : HtmlRenderer
    {
        private Hyperlink hyperlink;

        public HtmlHyperlinkRenderer(Hyperlink hyperlink)
        {
            this.hyperlink = hyperlink;
        }

        public override void Render(TextWriter writer)
        {
            writer.Write($"<a href=\"{this.hyperlink.Url.HtmlEncode()}\">");
        }
    }
}