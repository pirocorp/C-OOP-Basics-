namespace P02_EnterNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Startup
    {
        public static void Main()
        {
            var listOfNumbers = new List<int>();
            
            while (listOfNumbers.Count < 10)
            {
                try
                {
                    var number = int.Parse(Console.ReadLine());

                    ReadNumber(1, 100, listOfNumbers, number);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (OverflowException e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            var numbers = listOfNumbers.OrderBy(x => x).ToArray();
            Console.WriteLine($"[{string.Join(", ", numbers)}]");
        }

        private static void ReadNumber(int start, int end, List<int> listOfNumbers, int number)
        {
            if (number <= start || number >= end)
            {
                throw new ArgumentOutOfRangeException(nameof(number), $"Input number is out of range [{start}...{end}]");
            }

            listOfNumbers.Add(number);
        }
    }
}