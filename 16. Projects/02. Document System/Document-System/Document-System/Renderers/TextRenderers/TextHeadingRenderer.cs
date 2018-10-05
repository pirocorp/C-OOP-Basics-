namespace Document_System.Renderers.TextRenderers
{
    using System.IO;
    using Elements;

    public class TextHeadingRenderer : TextRenderer
    {
        private readonly Heading headingElement;

        public TextHeadingRenderer(Heading heading)
        {
            this.headingElement = heading;
        }

        public override void Render(TextWriter writer)
        {
            writer.WriteLine();
            writer.WriteLine(this.headingElement.Text.ToUpper());
        }
    }
}