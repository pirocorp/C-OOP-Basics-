namespace P06_AsynchronousTimer
{
    using System;

    public class StartUp
    {
        private static int _tick = 1;

        public static void Main()
        {
            var timer = new AsyncTimer(PrintToConsole, 100, 1000);
            timer.Run();
            var input = Console.ReadLine();
        }

        public static void PrintToConsole()
        {
            Console.WriteLine($"{_tick++}");
        }
    }
}
