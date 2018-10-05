namespace Document_System.RendersFactories
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Elements;
    using Enums;
    using Renderers;

    public static class RenderFactory
    {
        public static IRenderer Create(RenderTypes renderTypes, ElementTypes elementTypes, object element)
        {
            IRenderer renderer = null;

            switch (renderTypes)
            {
                case RenderTypes.Text:
                     renderer = TextRenderFactory.Create(elementTypes, element);
                     return renderer;
                case RenderTypes.Html:
                    renderer = HtmlRenderFactory.Create(elementTypes, element);
                    return renderer;
                default:
                    throw new NotSupportedException("Not suportet Render Type");
            }
        }
    }
}