namespace P03_StudentSystem
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var studentSystem = new StudentSystem();
            var inputLine = string.Empty;

            while ((inputLine = Console.ReadLine()) != "Exit")
            {
                studentSystem.ParseCommand(inputLine, Console.WriteLine);
            }
        }
    }
}