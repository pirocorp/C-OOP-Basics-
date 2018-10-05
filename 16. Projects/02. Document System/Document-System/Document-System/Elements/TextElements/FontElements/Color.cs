namespace Document_System.Elements.TextElements.FontElements
{
    using System.IO;

    public class Color
    {
        public Color(byte red, byte green, byte blue)
        {
            this.RedValue = red;
            this.GreenValue = green;
            this.BlueValue = blue;
        }

        public static Color Red => new Color(255, 50, 50);

        public static Color Green => new Color(50, 255, 50);

        public static Color Blue => new Color(50, 50, 255);

        public static Color Black => new Color(0, 0, 0);

        public static Color White => new Color(255, 255, 255);

        public byte RedValue { get; set; }

        public byte GreenValue { get; set; }

        public byte BlueValue { get; set; }

        public void RenderHtml(TextWriter writer)
        {
            writer.Write("#" + 
                         this.RedValue.ToString("X2") + 
                         this.GreenValue.ToString("X2") + 
                         this.BlueValue.ToString("X2"));
        }
    }
}