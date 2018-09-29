namespace P05_InterestCalculator
{
    using System;

    public class InterestCalculator
    {
        public InterestCalculator(decimal intitialDeposit, decimal interest, int years, Func<decimal, decimal, int, decimal> calculateInterest)
        {
            this.IntitialDeposit = intitialDeposit;
            this.Interest = interest;
            this.Years = years;
            this.CalculateInterest = calculateInterest;
        }

        public decimal IntitialDeposit { get; }

        public decimal Interest { get; }

        public int Years { get; }

        public Func<decimal, decimal, int, decimal> CalculateInterest { get; }

        public decimal TotalPayout => this.CalculateInterest(this.IntitialDeposit, this.Interest, this.Years);
    }
}