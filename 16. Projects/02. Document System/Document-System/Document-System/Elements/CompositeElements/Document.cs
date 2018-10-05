namespace Document_System.Elements.CompositeElements
{
    using System.IO;
    using Enums;
    using RendersFactories;
    using Utils;

    public class Document : CompositeElement
    {
        public string Title { get; set; }

        public string Author { get; set; }

        public override void Render(TextWriter writer, RenderTypes renderTypes)
        {
            var renderer = RenderFactory.Create(renderTypes, ElementTypes.Document, this);
            renderer.Render(writer);
            base.Render(writer, renderTypes);

            if (renderTypes == RenderTypes.Html)
            {
                renderer = FinishRenderersFactory.Create(FinishTypes.DocumentHtmlFinish, renderTypes, this);
                renderer.Render(writer);
            }
        }
    }
}