namespace Document_System.Renderers
{
    using System.IO;

    public interface IHtmlRenderer
    {
        void RenderHtml(TextWriter writer);
    }
}
