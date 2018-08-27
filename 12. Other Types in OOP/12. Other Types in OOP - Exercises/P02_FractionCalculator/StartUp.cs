using System;

namespace P02_FractionCalculator
{
    public class StartUp
    {
        public static void Main()
        {
            var fraction1 = new Fraction(22, 7);
            var fraction2 = new Fraction(40, 4);
            var result = fraction1 + fraction2;
            Console.WriteLine(result.Numerator);
            Console.WriteLine(result.Denominator);
            Console.WriteLine(result);

        }
    }
}
