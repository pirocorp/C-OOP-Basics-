namespace Document_System.Renderers.HtmlRenderers.HtmlTextElementRenderers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Elements.TextElements.FontElements;

    public class TextFontRenderer : HtmlRenderer
    {
        private readonly Font font;

        public TextFontRenderer(Font font)
        {
            this.font = font;
        }

        public override void Render(TextWriter writer)
        {
        }
    }
}