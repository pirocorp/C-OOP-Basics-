namespace Forum.Data
{
    using Forum.Models;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    
    public static class DataMapper
    {
        private const string DATA_PATH = "../data";
        private const string CONFIG_PATH = "config.ini";
        private const string DEFAULT_CONFIG = "users=users.csv\r\ncategories=categories.csv\r\nposts=posts.csv\r\nreplies=replies.csv";
        private static readonly Dictionary<string, string> config;

        private static void EnsureConfigFile(string configFilePath)
        {
            if (!File.Exists(configFilePath))
            {
                File.WriteAllText(configFilePath, DEFAULT_CONFIG);
            }
        }

        private static void EnsureFile(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }

        private static Dictionary<string, string> LoadConfig(string configPath)
        {
            EnsureConfigFile(configPath);

            var contents = ReadLines(configPath);

            var config = contents
                .Select(x => x.Split('=', StringSplitOptions.RemoveEmptyEntries))
                .ToDictionary(x => x[0], x => DATA_PATH + x[1]);

            return config;
        }

        private static string[] ReadLines(string path)
        {
            EnsureFile(path);
            var lines = File.ReadAllLines(path);
            return lines;
        }

        private static void WriteLines(string path, string[] lines)
        {
            File.WriteAllLines(path, lines);
        }

        static DataMapper()
        {
            Directory.CreateDirectory(DATA_PATH);
            config = LoadConfig(DATA_PATH + CONFIG_PATH);
        }

        public static List<Category> LoadCategories()
        {
            var categories = new List<Category>();
            var dataLines = ReadLines(config["categories"]);

            foreach (var line in dataLines)
            {
                var args = line.Split(";");
                var id = int.Parse(args[0]);
                var name = args[1];
                var postIds = args[2]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var category = new Category(id, name, postIds);
                categories.Add(category);
            }

            return categories;
        }

        public static void SaveCategories(ICollection<Category> categories)
        {
            var lines = new List<string>();

            foreach (var category in categories)
            {
                const string categoryFormat = "{0};{1};{2}";

                var line = string.Format(categoryFormat, category.Id, category.Name, string.Join(",", category.PostsIds));

                lines.Add(line);
            }

            WriteLines(config["categories"], lines.ToArray());
        }

        public static List<User> LoadUsers()
        {
            var users = new List<User>();
            var dataLines = ReadLines(config["users"]);

            foreach (var line in dataLines)
            {
                var args = line.Split(";");
                var id = int.Parse(args[0]);
                var username = args[1];
                var password = args[2];
                var postIds = args[3]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var user = new User(id, username, password, postIds);
                users.Add(user);
            }

            return users;
        }

        public static void SaveUsers(ICollection<User> users)
        {
            var lines = new List<string>();

            foreach (var user in users)
            {
                const string categoryFormat = "{0};{1};{2};{3}";

                var line = string.Format(categoryFormat, user.Id, user.Username, user.Password, string.Join(",", user.PostIds));

                lines.Add(line);
            }

            WriteLines(config["users"], lines.ToArray());
        }

        public static List<Post> LoadPosts()
        {
            var posts = new List<Post>();
            var dataLines = ReadLines(config["posts"]);

            foreach (var line in dataLines)
            {
                var args = line.Split(";");
                var id = int.Parse(args[0]);
                var title = args[1];
                var content = args[2];
                var categoryId = int.Parse(args[3]);
                var authorId = int.Parse(args[4]);
                var replayIds = args[5]
                    .Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var post = new Post(id, title, content, categoryId, authorId, replayIds);
                posts.Add(post);
            }

            return posts;
        }

        public static void SavePosts(ICollection<Post> posts)
        {
            var lines = new List<string>();

            foreach (var post in posts)
            {
                const string categoryFormat = "{0};{1};{2};{3};{4};{5}";

                var line = string.Format(categoryFormat, post.Id, post.Title, post.Content, post.CategoryId, post.AuthorId, string.Join(",", post.ReplayIds));

                lines.Add(line);
            }

            WriteLines(config["posts"], lines.ToArray());
        }

        public static List<Replay> LoadReplies()
        {
            var replies = new List<Replay>();
            var dataLines = ReadLines(config["replies"]);

            foreach (var line in dataLines)
            {
                var args = line.Split(";", StringSplitOptions.RemoveEmptyEntries);
                var id = int.Parse(args[0]);
                var content = args[1];
                var authorId = int.Parse(args[2]);
                var postId = int.Parse(args[3]);

                var replay = new Replay(id, content, authorId, postId);
                replies.Add(replay);
            }

            return replies;
        }

        public static void SaveReplies(ICollection<Replay> replies)
        {
            var lines = new List<string>();

            foreach (var replay in replies)
            {
                const string categoryFormat = "{0};{1};{2};{3}";

                var line = string.Format(categoryFormat, replay.Id, replay.Content, replay.AuthorId, replay.PostId);

                lines.Add(line);
            }

            WriteLines(config["replies"], lines.ToArray());
        }
    }
}