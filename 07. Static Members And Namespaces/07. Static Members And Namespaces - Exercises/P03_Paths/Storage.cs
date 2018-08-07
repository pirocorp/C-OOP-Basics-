namespace P03_Paths
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public static class Storage
    {
        private static List<Path3D> Paths = new List<Path3D>();

        public static List<Path3D> GetPaths => Paths;

        public static void ReadPathsFromFile(string filepath)
        {
            try
            {
                var inputPathsData = File.ReadAllLines(filepath).Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();

                foreach (var path in inputPathsData)
                {
                    var currentPath = Path3D.Parse(path);
                    Paths.Add(currentPath);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}