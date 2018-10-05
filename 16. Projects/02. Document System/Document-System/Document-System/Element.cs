namespace Document_System
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public abstract class Element : IHtmlRenderer, ITextRenderer
    {
        public abstract void RenderHtml(TextWriter writer);

        public abstract void RenderText(TextWriter writer);

        public string AsHtml
        {
            get
            {
                var writer = new StringWriter();
                this.RenderHtml(writer);
                return writer.ToString();
            }
        }

        public string AsText
        {
            get
            {
                var writer = new StringWriter();
                this.RenderText(writer);
                return writer.ToString();
            }
        }

        public override string ToString()
        {
            return this.AsText;
        }
    }
}