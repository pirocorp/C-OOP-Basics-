namespace Document_System.Elements.ImageElements
{
    using System;
    using System.IO;
    using Enums;
    using RendersFactories;

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

        public override void Render(TextWriter writer, RenderTypes renderTypes)
        {
            var renderer = RenderFactory.Create(renderTypes, ElementTypes.Image, this);
            renderer.Render(writer);
        }
    }
}