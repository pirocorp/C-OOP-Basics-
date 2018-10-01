using System;

class BoxingUnboxing
{
    static void Main(string[] args)
    {
        var value1 = 1;
        object obj = value1; // boxing performed

        value1 = 12345; // only stack value is changed

        var value2 = (int)obj;  // unboxing performed
        Console.WriteLine(value2); // prints 1

        var value3 = (long)(int)obj; // unboxing
        var value4 = (long)obj; // InvalidCastException
    }
}
 