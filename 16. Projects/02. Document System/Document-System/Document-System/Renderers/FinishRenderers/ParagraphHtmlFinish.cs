namespace Document_System.Renderers.FinishRenderers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Elements.CompositeElements;

    public class ParagraphHtmlFinish : FinishRenderer
    {
        private Paragraph paragraph;

        public ParagraphHtmlFinish(Paragraph paragraph)
        {
            this.paragraph = paragraph;
        }
        public override void Render(TextWriter writer)
        {
            writer.WriteLine("</p>");
        }
    }
}