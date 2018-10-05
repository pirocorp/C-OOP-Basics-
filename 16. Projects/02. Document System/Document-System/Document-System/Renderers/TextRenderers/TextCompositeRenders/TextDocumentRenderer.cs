namespace Document_System.Renderers.TextRenderers.TextCompositeRenders
{
    using System.IO;
    using Elements.CompositeElements;

    public class TextDocumentRenderer : TextRenderer
    {
        private readonly Document document;

        public TextDocumentRenderer(Document doc)
        {
            this.document = doc;
        }

        public override void Render(TextWriter writer)
        {
            if (this.document.Title != null)
            {
                writer.WriteLine($"Title: {this.document.Title}");
            }

            if (this.document.Author != null)
            {
                writer.WriteLine($"Author: {this.document.Author}");
            }
        }
    }
}