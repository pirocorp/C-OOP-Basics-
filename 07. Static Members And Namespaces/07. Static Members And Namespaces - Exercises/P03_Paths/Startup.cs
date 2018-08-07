namespace P03_Paths
{
    public class Startup
    {
        public static void Main()
        {
            Storage.ReadPathsFromFile("../../../test.txt");

            var paths = Storage.GetPaths;
        }
    }
}
