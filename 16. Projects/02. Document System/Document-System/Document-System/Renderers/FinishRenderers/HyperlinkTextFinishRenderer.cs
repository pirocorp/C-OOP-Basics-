namespace Document_System.Renderers.FinishRenderers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Elements.CompositeElements;

    public class HyperlinkTextFinishRenderer : FinishRenderer
    {
        private Hyperlink hyperlink;

        public HyperlinkTextFinishRenderer(Hyperlink hyperlink)
        {
            this.hyperlink = hyperlink;
        }

        public override void Render(TextWriter writer)
        {
            writer.Write("[/url]");
        }
    }
}