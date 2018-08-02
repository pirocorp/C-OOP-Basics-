using System;

namespace P02_Ferrari
{
    public class Startup
    {
        public static void Main()
        {
            var driver = Console.ReadLine();
            Console.WriteLine(new Ferrari(driver));
        }
    }
}