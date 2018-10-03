namespace Factory
{
    using System;

    class FactoryExample
    {
        static void Main()
        {
            ComplexNumber complexNum = ComplexNumber.FromPolarFactory(1, Math.PI / 3);
            Console.WriteLine(complexNum);
        }
    }
}
