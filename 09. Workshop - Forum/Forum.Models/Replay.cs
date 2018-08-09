﻿namespace Forum.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    
    public class Replay
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public int AuthorId { get; set; }

        public int PostId { get; set; }

        public Replay(int id, string content, int authorId, int postId)
        {
            this.Id = id;
            this.Content = content;
            this.AuthorId = authorId;
            this.PostId = postId;
        }
    }
}