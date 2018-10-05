namespace Document_System.Renderers.HtmlRenderers.HtmlCompositeRenders
{
    using System.IO;
    using Elements.CompositeElements;
    using Utils;

    public class HtmlDocumentRenderer : HtmlRenderer
    {
        private readonly Document document;

        public HtmlDocumentRenderer(Document document)
        {
            this.document = document;
        }

        public override void Render(TextWriter writer)
        {
            writer.WriteLine("<!DOCTYPE html>");
            writer.WriteLine("<html>");
            writer.WriteLine("<head>");

            if(this.document.Title != null)
            {
                writer.WriteLine($"<title>{this.document.Title.HtmlEncode()}</title>");
            }

            if (this.document.Author != null)
            {
                writer.WriteLine($"<meta name=\"author\" content=\"{this.document.Author.HtmlEncode()}\"/>");
            }

            writer.WriteLine("</head>");
            writer.WriteLine("<body>");
        }
    }
}