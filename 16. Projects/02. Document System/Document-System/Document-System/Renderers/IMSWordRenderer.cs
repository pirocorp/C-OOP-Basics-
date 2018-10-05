namespace Document_System.Renderers
{
    using System.IO;

    public interface IMSWordRenderer
    {
        void RenderMsWord(Stream stream);
    }
}
