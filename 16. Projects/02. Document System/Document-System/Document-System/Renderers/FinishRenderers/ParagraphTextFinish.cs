namespace Document_System.Renderers.FinishRenderers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Elements.CompositeElements;

    public class ParagraphTextFinish : FinishRenderer
    {
        private Paragraph paragraph;

        public ParagraphTextFinish(Paragraph paragraph)
        {
            this.paragraph = paragraph;
        }
        public override void Render(TextWriter writer)
        {
            writer.WriteLine();
        }
    }
}