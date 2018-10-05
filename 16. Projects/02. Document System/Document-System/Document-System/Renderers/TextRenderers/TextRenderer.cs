namespace Document_System.Renderers.TextRenderers
{
    using System.IO;

    public abstract class TextRenderer : IRenderer
    {
        public abstract void Render(TextWriter writer);
    }
}