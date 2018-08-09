namespace Forum.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int CategoryId { get; set; }

        public int AuthorId { get; set; }

        public ICollection<int> ReplayIds { get; set; }

        public Post(int id, string title, string content, int categoryId, int authorId, ICollection<int> replayIds)
        {
            this.Id = id;
            this.Title = title;
            this.Content = content;
            this.CategoryId = categoryId;
            this.AuthorId = authorId;
            this.ReplayIds = new List<int>(replayIds);
        }
    }
}