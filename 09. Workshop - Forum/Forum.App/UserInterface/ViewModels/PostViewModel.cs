namespace Forum.App.UserInterface.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PostViewModel
    {
        private const int LINE_LENGHT = 37;

        public PostViewModel()
        {
            throw new NotImplementedException();
        }

        private IList<string> GetLines(string content)
        {
            var contentChars = content.ToCharArray();

            var lines = new List<string>();

            for (var i = 0; i < content.Length; i += LINE_LENGHT)
            {
                var rowChars = contentChars.Skip(i).Take(LINE_LENGHT).ToArray();
                var row = new string(rowChars);
                lines.Add(row);
            }

            return lines;
        }

        public int PostId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Category { get; set; }

        public IList<string> Content { get; set; }

        public IList<ReplyViewModel> Replies { get; set; }
    }
}
