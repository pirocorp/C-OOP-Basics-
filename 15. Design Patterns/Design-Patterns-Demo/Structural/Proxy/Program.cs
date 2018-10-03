namespace Proxy
{
    using System;

    internal class Program
    {
        internal static void Main()
        {
            var proxy = new MathProxy();

            Console.WriteLine("4 + 2 = " + proxy.Add(4, 2));
            Console.WriteLine("4 - 2 = " + proxy.Sub(4, 2));
            Console.WriteLine("4 * 2 = " + proxy.Multiply(4, 2));
            Console.WriteLine("4 / 2 = " + proxy.Divide(4, 2));

            // Wait for user
            Console.ReadKey();
        }
    }
}
