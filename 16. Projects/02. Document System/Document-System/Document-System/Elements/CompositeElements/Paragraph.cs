namespace Document_System.Elements.CompositeElements
{
    using System.IO;
    using Enums;
    using RendersFactories;
    using TextElements;
    using TextElements.FontElements;

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

        public override void Render(TextWriter writer, RenderTypes renderTypes)
        {
            var renderer = RenderFactory.Create(renderTypes, ElementTypes.Paragraph, this);
            renderer.Render(writer);
            base.Render(writer, renderTypes);

            renderer = FinishRenderersFactory.Create(FinishTypes.Paragraph, renderTypes, this);
            renderer.Render(writer);
        }
    }
}