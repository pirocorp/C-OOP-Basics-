namespace Document_System.Renderers.HtmlRenderers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public abstract class HtmlRenderer : IRenderer
    {
        public abstract void Render(TextWriter writer);
    }
}