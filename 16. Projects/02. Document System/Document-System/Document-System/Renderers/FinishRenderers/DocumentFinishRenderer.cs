namespace Document_System.Renderers.FinishRenderers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Elements.CompositeElements;

    public class DocumentFinishRenderer : FinishRenderer
    {
        private Document document;

        public DocumentFinishRenderer(Document document)
        {
            this.document = document;
        }
        public override void Render(TextWriter writer)
        {
            writer.WriteLine("</body>");
            writer.WriteLine("</html>");
        }
    }
}