namespace Document_System
{
    using System;
    using System.IO;

    public class ImageType
    {
        private ImageType(string name)
        {
            this.Name = name;
        }

        public string Name { get; private set; }

        public static ImageType Png => new ImageType("png");

        public static ImageType Gif => new ImageType("gif");

        public static ImageType Jpeg => new ImageType("jpeg");

        public string ContentType => "image/" + this.Name;

        public static ImageType CreateFromFilename(string filename)
        {
            var fileExtension = new FileInfo(filename).Extension;

            switch (fileExtension.ToLower())
            {
                case ".png":
                    return ImageType.Png;
                case ".gif":
                    return ImageType.Gif;
                case ".jpg":
                case "jpeg":
                    return ImageType.Jpeg;
                default:
                    throw new NotSupportedException($"Image type {fileExtension} is not supported.");
            }
        }
    }
}