namespace Forum.App.UserInterface.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using Services;

    public class ReplyViewModel
    {
        private const int LINE_LENGHT = 37;

        public ReplyViewModel()
        {
            this.Content = new List<string>();
        }

        public ReplyViewModel(Reply replay)
        {
            this.Author = UserService.GetUser(replay.AuthorId).Username;
            this.Content = this.GetLines(replay.Content);
        }

        public string Author { get; set; }

        public IList<string> Content { get; set; }

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
    }
}