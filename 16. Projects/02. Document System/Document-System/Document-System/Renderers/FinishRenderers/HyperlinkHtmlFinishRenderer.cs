namespace Document_System.Renderers.FinishRenderers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Elements.CompositeElements;

    public class HyperlinkHtmlFinishRenderer : FinishRenderer
    {
        private Hyperlink hyperlink;

        public HyperlinkHtmlFinishRenderer(Hyperlink hyperlink)
        {
            this.hyperlink = hyperlink;
        }

        public override void Render(TextWriter writer)
        {
            writer.Write("</a>");
        }
    }
}