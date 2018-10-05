namespace Document_System.Renderers
{
    using System.IO;

    public interface IRenderer
    {
        void Render(TextWriter writer);
    }
}
