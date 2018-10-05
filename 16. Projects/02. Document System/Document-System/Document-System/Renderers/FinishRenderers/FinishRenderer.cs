namespace Document_System.Renderers.FinishRenderers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public abstract class FinishRenderer : IRenderer
    {
        public abstract void Render(TextWriter writer);
    }
}