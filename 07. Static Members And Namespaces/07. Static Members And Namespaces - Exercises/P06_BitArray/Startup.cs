namespace P06_BitArray
{
    using System;
    using System.Numerics;

    public class Startup
    {
        public static void Main()
        {
            var bitArray = new BitArray(100000);
            Console.WriteLine(bitArray[99999]);
            bitArray[99999] = 1;
            Console.WriteLine(bitArray[99999]);
            Console.WriteLine(bitArray);
        }
    }
}