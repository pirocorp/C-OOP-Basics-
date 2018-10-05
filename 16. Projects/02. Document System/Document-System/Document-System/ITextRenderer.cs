namespace Document_System
{
    using System.IO;

    public interface ITextRenderer
    {
        void RenderText(TextWriter writer);
    }
}
