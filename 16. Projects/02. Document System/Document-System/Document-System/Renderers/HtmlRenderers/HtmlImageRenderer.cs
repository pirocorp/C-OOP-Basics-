namespace Document_System.Renderers.HtmlRenderers
{
    using System;
    using System.IO;
    using Elements.ImageElements;

    public class HtmlImageRenderer : HtmlRenderer
    {
        private Image image;

        public HtmlImageRenderer(Image image)
        {
            this.image = image;
        }

        public override void Render(TextWriter writer)
        {
            writer.Write($"<img src=\"data:{this.image.Type};base64,{Convert.ToBase64String(this.image.Data)}\">");
        }
    }
}