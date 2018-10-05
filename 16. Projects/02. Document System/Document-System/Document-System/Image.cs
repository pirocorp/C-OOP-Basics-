namespace Document_System
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class Image : Element
    {
        public Image(ImageType type, byte[] data)
        {
            this.Type = type;
            this.Data = data;
        }

        public static Image CreateFromFile(string filename)
        {
            var type = ImageType.CreateFromFilename(filename);
            var data = File.ReadAllBytes(filename);
            var image = new Image(type, data);
            return image;
        }

        public ImageType Type { get; set; }

        public byte[] Data { get; set; }

        public override void RenderHtml(TextWriter writer)
        {
            writer.Write($"<img src=\"data:{this.Type};base64,{Convert.ToBase64String(this.Data)}\">");
        }

        public override void RenderText(TextWriter writer)
        {
            writer.WriteLine();
            writer.WriteLine("[image]");
            writer.WriteLine();
        }
    }
}