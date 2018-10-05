namespace Document_System.Elements.CompositeElements
{
    using System.IO;
    using Enums;
    using RendersFactories;
    using TextElements;
    using Utils;

    public class Hyperlink : CompositeElement
    {
        public Hyperlink(string url)
        {
            this.Url = url;
        }

        public Hyperlink(string url, string text)
            :this(url)
        {
            this.Add(new TextElement(text));
        }
        
        public string Url { get; set; }

        public override void Render(TextWriter writer, RenderTypes renderTypes)
        {
            var renderer = RenderFactory.Create(renderTypes, ElementTypes.Hyperlink, this);
            renderer.Render(writer);

            if (renderTypes == RenderTypes.Html)
            {
                if (this.ChildElements.Count > 0)
                {
                    base.Render(writer, renderTypes);
                }
                else
                {
                    writer.Write(this.Url.HtmlEncode());
                }

                renderer = FinishRenderersFactory.Create(FinishTypes.Hyperlink, renderTypes, this);
                renderer.Render(writer);
            }

            if (renderTypes == RenderTypes.Text)
            {
                base.Render(writer, renderTypes);
                renderer = FinishRenderersFactory.Create(FinishTypes.Hyperlink, renderTypes, this);
                renderer.Render(writer);
            }
        }
    }
}