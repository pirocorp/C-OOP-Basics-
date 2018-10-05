namespace Document_System.RendersFactories
{
    using System;
    using Elements.CompositeElements;
    using Enums;
    using Renderers;
    using Renderers.FinishRenderers;

    public static class FinishRenderersFactory
    {
        public static IRenderer Create(FinishTypes finishTypes, RenderTypes type, object element)
        {
            switch (finishTypes)
            {
                case FinishTypes.DocumentHtmlFinish:

                    if (element is Document documentHtmlFinish)
                    {
                        var renderer = new DocumentFinishRenderer(documentHtmlFinish);
                        return renderer;
                    }
                    else
                    {
                        throw new InvalidCastException("Invalid element type");
                    }

                case FinishTypes.Hyperlink:

                    if (element is Hyperlink hyperlink)
                    {
                        IRenderer renderer = null;

                        switch (type)
                        {
                            case RenderTypes.Text:
                                renderer = new HyperlinkTextFinishRenderer(hyperlink);
                                return renderer;
                            case RenderTypes.Html:
                                renderer = new HyperlinkHtmlFinishRenderer(hyperlink);
                                return renderer;
                            default:
                                throw new NotSupportedException("Not suportet Render Type");
                        }
                    }
                    else
                    {
                        throw new InvalidCastException("Invalid element type");
                    }

                case FinishTypes.Paragraph:
                    if (element is Paragraph paragraph)
                    {
                        IRenderer renderer = null;

                        switch (type)
                        {
                            case RenderTypes.Text:
                                renderer = new ParagraphTextFinish(paragraph);
                                return renderer;
                            case RenderTypes.Html:
                                renderer = new ParagraphHtmlFinish(paragraph);
                                return renderer;
                            default:
                                throw new NotSupportedException("Not suportet Render Type");
                        }
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