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
                var args = line.Split(";", StringSplitOptions.RemoveEmptyEntries);
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
    }
}