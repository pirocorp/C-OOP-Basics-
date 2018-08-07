using System;

public class ClassCounter
{
    public static void Main()
    {
        var p = new Person("Pesho");
        Console.WriteLine("Person name: {0}", p.Name);

        var g = new Person("Gosho");
        Console.WriteLine("Person name: {0}", g.Name);

        Console.WriteLine("Persons count: {0}", Person.PersonCounter);
    }
}
