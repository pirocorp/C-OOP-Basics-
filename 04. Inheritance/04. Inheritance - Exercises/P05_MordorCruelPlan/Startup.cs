using System;

public class Startup
{
    public static void Main()
    {
        var gandalf = new Gandalf();
        gandalf.Eat(Console.ReadLine());
        Console.WriteLine(gandalf.HppinessPoints);
        Console.WriteLine(gandalf.Mood());
    }
}