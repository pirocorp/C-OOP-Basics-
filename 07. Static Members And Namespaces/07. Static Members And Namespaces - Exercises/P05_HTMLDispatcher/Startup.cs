namespace P05_HTMLDispatcher
{
    using System;

    public class Startup
    {
        static void Main(string[] args)
        {
            var div = new ElementBuilder("div");

            div.AddAttribute("id", "page");
            div.AddAttribute("class", "big");
            div.AddContent("<p>Hello</p>");

            Console.WriteLine(div);
            Console.WriteLine(div * 2);
            Console.WriteLine(2 * div);

            var image = HtmlDispatcher.CreateImage("smiley.gif", "Smiley face", "Emoji");
            var url = HtmlDispatcher.CreateURL("https://www.w3schools.com", "Test title", "Visit W3Schools.com!");
            var input = HtmlDispatcher.CreateInput("text", "firstname", "John");

            Console.WriteLine();
            Console.WriteLine(image);
            Console.WriteLine(url);
            Console.WriteLine(input);
        }
    }
}