namespace Document_System.Elements.TextElements
{
    using System.IO;
    using Enums;
    using FontElements;
    using Renderers.HtmlRenderers;
    using Utils;

    public class HtmlTextElementRenderer : HtmlRenderer
    {
        private readonly TextElement textElement;

        public HtmlTextElementRenderer(TextElement textElement)
        {
            this.textElement = textElement;
        }

        public override void Render(TextWriter writer)
        {
            if (this.textElement.Font != null)
            {
                writer.Write("<span style=\"");
                this.textElement.Font.Render(writer, RenderTypes.Html);
                writer.Write("\">");
            }

            writer.Write(this.textElement.Text.HtmlEncode());

            if (this.textElement.Font != null)
            {
                writer.Write("</span>");
            }
        }
    }
}