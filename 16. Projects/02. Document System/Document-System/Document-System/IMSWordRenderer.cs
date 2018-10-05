namespace Document_System
{
    using System.IO;

    public interface IMSWordRenderer
    {
        void RenderMsWord(Stream stream);
    }
}
