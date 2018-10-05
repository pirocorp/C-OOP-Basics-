namespace Document_System.Elements
{
    using System.IO;
    using Enums;

    public abstract class Element 
    {
        public string AsHtml
        {
            get
            {
                var writer = new StringWriter();
                this.Render(writer, RenderTypes.Html);
                return writer.ToString();
            }
        }

        public string AsText
        {
            get
            {
                var writer = new StringWriter();
                this.Render(writer, RenderTypes.Text);
                return writer.ToString();
            }
        }

        public override string ToString()
        {
            return this.AsText;
        }

        public abstract void Render(TextWriter writer, RenderTypes renderTypes);
    }
}