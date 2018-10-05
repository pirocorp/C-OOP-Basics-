namespace Document_System
{
    using System.IO;

    public interface IHtmlRenderer
    {
        void RenderHtml(TextWriter writer);
    }
}
