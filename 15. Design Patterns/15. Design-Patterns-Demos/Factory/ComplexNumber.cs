namespace Factory
{
    using System;

    public class ComplexNumber
    {
        public double Real { get; private set; }
        public double Imaginary { get; private set; }

        public static ComplexNumber FromPolarFactory(double modulus, double angle)
        {
            return new ComplexNumber(
                modulus * Math.Cos(angle), modulus * Math.Sin(angle));
        }

        public static ComplexNumber FromCartesianFactory(double real, double imaginary)
        {
            return new ComplexNumber(real, imaginary);
        }

        private ComplexNumber(double real, double imaginary)
        {
            this.Real = real;
            this.Imaginary = imaginary;
        }

        public override string ToString()
        {
            return String.Format("Complex({0:F2} + {1:F2}i)", this.Real, this.Imaginary);
        }
    }
}
