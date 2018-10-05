namespace Document_System
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class Paragraph : CompositeElement
    {
        public Paragraph()
            :base()
        {
            
        }

        public Paragraph(string text, Font font = null)
            : this()
        {
            this.Add(new TextElement(text, font));
        }

        public override void RenderHtml(TextWriter writer)
        {
            writer.Write("<p>");
            base.RenderHtml(writer);
            writer.WriteLine("</p>");
        }

        public override void RenderText(TextWriter writer)
        {
            writer.WriteLine();
            base.RenderText(writer);
            writer.WriteLine();
        }
    }
}