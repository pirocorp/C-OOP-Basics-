using System;

namespace DecoratorPattern
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Pizza basePizza = new TomatoSaucePizza(new PepperoniPizza(new PlainPizza()));

            PrintSeparator();

            Console.WriteLine("Ingredients: {0}", basePizza.GetDescription());
            Console.WriteLine("Price: {0:C}", basePizza.GetPrice());
        }

        private static void PrintSeparator()
        {
            Console.WriteLine();
            Console.WriteLine("".PadLeft(30, '='));
            Console.WriteLine();
        }
    }
}