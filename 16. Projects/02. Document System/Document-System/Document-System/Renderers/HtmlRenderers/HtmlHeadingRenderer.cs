namespace Document_System.Renderers.HtmlRenderers
{
    using System.IO;
    using Elements;
    using Utils;

    public class HtmlHeadingRenderer : HtmlRenderer
    {
        private readonly Heading headingElement;

        public HtmlHeadingRenderer(Heading heading)
        {
            this.headingElement = heading;
        }

        public override void Render(TextWriter writer)
        {
            writer.WriteLine();
            writer.WriteLine($"<h{this.headingElement.HeadingSize}>{this.headingElement.Text.HtmlEncode()}</h{this.headingElement.HeadingSize}>");
        }
    }
}