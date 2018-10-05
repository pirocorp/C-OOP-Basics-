namespace Document_System.Structure
{
    using System.IO;
    using Utils;

    public class Document : CompositeElement
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public override void RenderHtml(TextWriter writer)
        {
            writer.WriteLine("<!DOCTYPE html>");
            writer.WriteLine("<html>");
            writer.WriteLine("<head>");

            if(this.Title != null)
            {
                writer.WriteLine($"<title>{this.Title.HtmlEncode()}</title>");
            }

            if (this.Author != null)
            {
                writer.WriteLine($"<meta name=\"author\" content=\"{this.Author.HtmlEncode()}\"/>");
            }

            writer.WriteLine("</head>");
            writer.WriteLine("<body>");
            base.RenderHtml(writer);
            writer.WriteLine("</body>");
            writer.WriteLine("</html>");
        }

        public override void RenderText(TextWriter writer)
        {
            if (this.Title != null)
            {
                writer.WriteLine($"Title: {this.Title}");
            }

            if (this.Author != null)
            {
                writer.WriteLine($"Author: {this.Author}");
            }

            base.RenderText(writer);
        }
    }
}