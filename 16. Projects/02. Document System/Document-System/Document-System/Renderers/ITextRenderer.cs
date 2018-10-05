namespace Document_System.Renderers
{
    using System.IO;

    public interface ITextRenderer
    {
        void RenderText(TextWriter writer);
    }
}
