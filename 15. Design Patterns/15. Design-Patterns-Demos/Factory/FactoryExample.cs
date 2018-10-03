namespace Factory
{
    using System;

    class FactoryExample
    {
        static void Main()
        {
            var complexNum = ComplexNumber.FromPolarFactory(1, Math.PI / 3);
            Console.WriteLine(complexNum);
        }
    }
}
