namespace Document_System
{
    using System;
    using System.IO;

    public class Program
    {
        public static void Main()
        {
            var doc = new Document();
            doc.Title = "My First Document";
            doc.Author = "Zdravko Zdravkov";
            doc.Add(new Paragraph("I am a paragraph"));
            doc.Add(new Paragraph("I am another paragraph"));
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
            doc.Add(Image.CreateFromFile("../../../logo.png"));
            doc.Add(paragraph);


            File.WriteAllText("document.html", doc.AsHtml);
            File.WriteAllText("document.txt", doc.AsText);

            Console.WriteLine(doc.AsText);
        }
    }
}
