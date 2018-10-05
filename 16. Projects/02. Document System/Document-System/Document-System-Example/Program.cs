namespace Document_System_Example
{
    using System;
    using System.IO;
    using Document_System.Elements;
    using Document_System.Elements.CompositeElements;
    using Document_System.Elements.ImageElements;
    using Document_System.Elements.TextElements;
    using Document_System.Elements.TextElements.FontElements;
    using Document_System.Renderers.TextRenderers;

    public class Program
    {
        public static void Main()
        {
            var doc = new Document();
            doc.Title = "My First Document";
            doc.Author = "Zdravko Zdravkov";
            doc.Add(new Paragraph("I am a paragraph"));
            doc.Add(new Hyperlink("http://dir.bg"));
            doc.Add(new Paragraph("I am another paragraph"));
            doc.Add(new Heading("Heading 1"));
            var paragraph = new Paragraph();
            paragraph.Add(new TextElement("Default Font ", Font.DefaultFont));
            paragraph.Add(new TextElement("Second Red ", new Font(color: Color.Red)));
            paragraph.Add(new TextElement("Green Italic ", 
                new Font(
                    color: Color.Green, 
                    style: FontStyle.Italic)));
            paragraph.Add(new Paragraph());
            paragraph.Add(new TextElement("Consolas Bold Blue Italic ",
                new Font(
                    color: Color.Blue,
                    style: FontStyle.BoldItalic,
                    name: "Consolas")));
            doc.Add(paragraph);

            doc.Add(new Heading("Heading 2<br>", 2));

            var hyperlink = new Hyperlink("http://softuni.bg");
            hyperlink.Add(new TextElement("Some text"));
            hyperlink.Add(Image.CreateFromFile("../../../logo.png"));
            hyperlink.Add(new TextElement("Other text"));
            doc.Add(hyperlink);
            doc.Add(paragraph);

            File.WriteAllText("document.html", doc.AsHtml);
            File.WriteAllText("document.txt", doc.AsText);

            Console.WriteLine(doc.AsText);
        }
    }
}
