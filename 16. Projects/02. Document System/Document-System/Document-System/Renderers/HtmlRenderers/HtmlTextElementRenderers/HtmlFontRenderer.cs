namespace Document_System.Renderers.HtmlRenderers.HtmlTextElementRenderers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Elements.TextElements.FontElements;

    public class HtmlFontRenderer : HtmlRenderer
    {
        private readonly Font font;

        public HtmlFontRenderer(Font font)
        {
            this.font = font;
        }

        public override void Render(TextWriter writer)
        {
            if (this.font.Name != null)
            {
                writer.Write($"font-family:{this.font.Name};");
            }

            if (this.font.Size != null)
            {
                writer.Write($"font-size:{this.font.Size}pt;");
            }

            if (this.font.Color != null)
            {
                writer.Write("color:");
                this.font.Color.RenderHtml(writer);
                writer.Write(";");
            }

            if ((this.font.Style & FontStyle.Bold) != 0)
            {
                writer.Write("font-weight:bold;");
            }

            if ((this.font.Style & FontStyle.Italic) != 0)
            {
                writer.Write("font-style:italic;");
            }
        }
    }
}