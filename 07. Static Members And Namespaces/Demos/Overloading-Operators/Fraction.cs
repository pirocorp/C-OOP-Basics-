using System;

public struct Fraction
{
    private long numerator;
    private long denominator;

    public Fraction(long numerator, long denominator)
    {
        // Cancel the fraction and make the denominator positive
        var gcd = GreatestCommonDivisor(numerator, denominator);
        this.numerator = numerator / gcd;
        this.denominator = denominator / gcd;

        if (this.denominator < 0)
        {
            this.numerator = -numerator;
            this.denominator = -denominator;
        }
    }

    private static long GreatestCommonDivisor(
        long firstNumber, long secondNumber)
    {
        firstNumber = Math.Abs(firstNumber);
        secondNumber = Math.Abs(secondNumber);

        while (firstNumber > 0)
        {
            var newNumber = secondNumber % firstNumber;
            secondNumber = firstNumber;
            firstNumber = newNumber;
        }

        return secondNumber;
    }

    public static Fraction operator +(Fraction f1, Fraction f2)
    {
        var num = f1.numerator * f2.denominator +
            f2.numerator * f1.denominator;
        var denom = f1.denominator * f2.denominator;

        return new Fraction(num, denom);
    }

    public static Fraction operator -(Fraction f1, Fraction f2)
    {
        var num = f1.numerator * f2.denominator -
            f2.numerator * f1.denominator;
        var denom = f1.denominator * f2.denominator;

        return new Fraction(num, denom);
    }

    public static Fraction operator *(Fraction f1, Fraction f2)
    {
        var num = f1.numerator * f2.numerator;
        var denom = f1.denominator * f2.denominator;

        return new Fraction(num, denom);
    }

    public static Fraction operator /(Fraction f1, Fraction f2)
    {
        var num = f1.numerator * f2.denominator;
        var denom = f1.denominator * f2.numerator;

        return new Fraction(num, denom);
    }

    // Unary minus operator
    public static Fraction operator -(Fraction fraction)
    {
        var num = -fraction.numerator;
        var denom = fraction.denominator;

        return new Fraction(num, denom);
    }

    // Operator ++ (the same for prefix and postfix form)
    public static Fraction operator ++(Fraction frac)
    {
        var num = frac.numerator + frac.denominator;
        var denom = frac.denominator;

        return new Fraction(num, denom);
    }

    // Operator -- (the same for prefix and postfix form)
    public static Fraction operator --(Fraction frac)
    {
        var num = frac.numerator - frac.denominator;
        var denom = frac.denominator;

        return new Fraction(num, denom);
    }

    public static bool operator true(Fraction fraction)
    {
        return fraction.numerator != 0;
    }

    public static bool operator false(Fraction fraction)
    {
        return fraction.numerator == 0;
    }

    // Explicit conversion to double operator 
    public static explicit operator double(Fraction fraction)
    {
        return (double)fraction.numerator / fraction.denominator;
    }

    public static implicit operator Fraction(double value)
    {
        var num = value;
        long denom = 1;

        while ((num - Math.Floor(num)) > 0)
        {
            num = num * 10;
            denom = denom * 10;
        }

        return new Fraction((long)num, denom);
    }

    public override string ToString()
    {
        return $"{this.numerator}/{this.denominator}";
    }
}
