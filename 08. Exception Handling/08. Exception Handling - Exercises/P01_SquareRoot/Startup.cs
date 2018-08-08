namespace P01_SquareRoot
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            try
            {
                var number = int.Parse(Console.ReadLine());
                Console.WriteLine(Sqrt(number));
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (System.FormatException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine($"Good bye");
            }
        }

        private static double Sqrt(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException($"Number must be positive");
            }

            return Math.Pow(number, 0.5);
        }
    }
}
