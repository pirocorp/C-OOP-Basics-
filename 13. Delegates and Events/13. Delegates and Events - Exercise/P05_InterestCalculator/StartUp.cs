namespace P05_InterestCalculator
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            var compoundInterestCalculator = new InterestCalculator(500M, 0.056M, 10, GetCompoundInterest);
            var simpleInterestCalculator = new InterestCalculator(2500M, 0.072M, 15, GetSimpleInterest);
            Console.WriteLine($"{compoundInterestCalculator.TotalPayout:F4}");
            Console.WriteLine($"{simpleInterestCalculator.TotalPayout:F4}");
        }

        private static decimal GetCompoundInterest(decimal sumOfMoney, decimal interest, int years)
        {
            var numberOfCompoundsPerYear = 12;
            var arg1 = (double)(1 + interest / numberOfCompoundsPerYear);
            var arg2 = numberOfCompoundsPerYear * years;
            var compoundInterest = Math.Pow(arg1, arg2);
            return sumOfMoney * (decimal)compoundInterest;
        }

        private static decimal GetSimpleInterest(decimal sumOfMoney, decimal interest, int years)
        {
            return sumOfMoney * (1 + interest * years);
        }
    }
}
