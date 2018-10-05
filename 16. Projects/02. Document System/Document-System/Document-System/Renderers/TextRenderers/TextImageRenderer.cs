namespace Document_System.Renderers.TextRenderers
{
    using System.IO;
    using Elements.ImageElements;

    public class TextImageRenderer : TextRenderer
    {
        private Image image;

        public TextImageRenderer(Image image)
        {
            this.image = image;
        }

        public override void Render(TextWriter writer)
        {
            writer.WriteLine();
            writer.WriteLine("[image]");
            writer.WriteLine();
        }
    }
}