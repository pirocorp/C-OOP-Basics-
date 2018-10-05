namespace Document_System.RendersFactories
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Elements;
    using Elements.CompositeElements;
    using Elements.ImageElements;
    using Elements.TextElements;
    using Elements.TextElements.FontElements;
    using Enums;
    using Renderers;
    using Renderers.HtmlRenderers;
    using Renderers.HtmlRenderers.HtmlCompositeRenders;
    using Renderers.HtmlRenderers.HtmlTextElementRenderers;

    public class HtmlRenderFactory
    {
        public static IRenderer Create(ElementTypes elementTypes, object element)
        {
            switch (elementTypes)
            {
                case ElementTypes.Heading:

                    if (element is Heading heading)
                    {
                        var renderer = new HtmlHeadingRenderer(heading);
                        return renderer;
                    }
                    else
                    {
                        throw new InvalidCastException("Invalid element type");
                    }

                case ElementTypes.Document:

                    if (element is Document document)
                    {
                        var renderer = new HtmlDocumentRenderer(document);
                        return renderer;
                    }
                    else
                    {
                        throw new InvalidCastException("Invalid element type");
                    }

                case ElementTypes.Hyperlink:

                    if (element is Hyperlink hyperlink)
                    {
                        var renderer = new HtmlHyperlinkRenderer(hyperlink);
                        return renderer;
                    }
                    else
                    {
                        throw new InvalidCastException("Invalid element type");
                    }

                case ElementTypes.Paragraph:

                    if (element is Paragraph paragraph)
                    {
                        var renderer = new HtmlParagraphRenderer(paragraph);
                        return renderer;
                    }
                    else
                    {
                        throw new InvalidCastException("Invalid element type");
                    }

                case ElementTypes.Image:

                    if (element is Image image)
                    {
                        var renderer = new HtmlImageRenderer(image);
                        return renderer;
                    }
                    else
                    {
                        throw new InvalidCastException("Invalid element type");
                    }

                case ElementTypes.TextElement:

                    if (element is TextElement textElement)
                    {
                        var renderer = new HtmlTextElementRenderer(textElement);
                        return renderer;
                    }
                    else
                    {
                        throw new InvalidCastException("Invalid element type");
                    }

                case ElementTypes.Font:

                    if (element is Font font)
                    {
                        var renderer = new HtmlFontRenderer(font);
                        return renderer;
                    }
                    else
                    {
                        throw new InvalidCastException("Invalid element type");
                    }

                default:
                    throw new NotSupportedException("Not suportet Element Type");
            }
        }
    }
}