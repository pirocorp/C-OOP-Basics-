using System;

public class IndexerExample
{
    public static void Main()
    {
        var bits = new BitArray32();

        bits[0] = 1;
        Console.WriteLine($"bits = {bits}");
        bits[5] = 1;
        Console.WriteLine($"bits = {bits}");
        bits[5] = 0;
        Console.WriteLine($"bits = {bits}");
        bits[25] = 1;
        Console.WriteLine($"bits = {bits}");
        bits[31] = 1;
        Console.WriteLine($"bits = {bits}");

        for (var i = 0; i <= 31; i++)
        {
            Console.WriteLine("arr[{0}] = {1}", i, bits[i]);
        }

        Console.WriteLine($"bits = {bits}");
    }
}