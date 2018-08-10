namespace Forum.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public ICollection<int> PostIds { get; set; }

        public User(int id, string username, string password) 
            : this(id, username, password, new List<int>())
        {
        }

        public User(int id, string username, string password, ICollection<int> postIds)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
            this.PostIds = new List<int>(postIds);
        }
    }
}