namespace P02_FractionCalculator
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public struct Fraction
    {
        private long numerator;
        private long denominator;

        public Fraction(long numerator, long denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public long Numerator
        {
            get => this.numerator;
            set => this.numerator = value;
        }

        public long Denominator
        {
            get => this.denominator;
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException($"Denominator cannot be zero!");
                }

                this.denominator = value;
            }
        }

        public static Fraction operator+ (Fraction firstFraction, Fraction secondFraction)
        {
            long Func(long a, long b) => a + b;
            var result = Operation(firstFraction, secondFraction, Func);
            return result;
        }

        public static Fraction operator -(Fraction firstFraction, Fraction secondFraction)
        {
            {
                long Func(long a, long b) => a - b;
                var result = Operation(firstFraction, secondFraction, Func);
                return result;
            }
        }

        private static Fraction Operation(Fraction firstFraction, Fraction secondFraction, Func<long, long, long> operation)
        {
            if (firstFraction.Denominator == secondFraction.Denominator)
            {
                var numeratorResult = operation(firstFraction.Numerator, secondFraction.Numerator);
                var denominatorResult = firstFraction.Denominator;

                return new Fraction(numeratorResult, denominatorResult);
            }

            var resultDenominator = firstFraction.Denominator * secondFraction.Denominator;

            var resultNumerator = operation(firstFraction.Numerator * secondFraction.Denominator,
                                  secondFraction.Numerator * firstFraction.Denominator);

            return new Fraction(resultNumerator, resultDenominator);
        }

        public override string ToString()
        {
            var result = this.Numerator /(double) this.Denominator;
            return $"{result}";
        }
    }
}