namespace P05_HTMLDispatcher
{
    public static class HtmlDispatcher
    {
        public static string CreateImage(string imageSource, string alt, string title)
        {
            var img = new ElementBuilder("img");

            img.AddAttribute("src", imageSource);
            img.AddAttribute("alt", alt);
            img.AddAttribute("title", title);

            return img.ToString();
        }

        public static string CreateURL(string url, string title, string text)
        {
            var link = new ElementBuilder("a");

            link.AddAttribute("href", url);
            link.AddAttribute("title", title);
            link.AddContent(text);

            return link.ToString();
        }

        public static string CreateInput(string inputType, string name, string value)
        {
            var input = new ElementBuilder("input");

            input.AddAttribute("type", inputType);
            input.AddAttribute("name", name);
            input.AddAttribute("value", value);

            return input.ToString();
        }
    }
}