using System;

public class Startup
{
    public static void Main()
    {
        Shape circle = new Circle(5);
        Shape rectangle = new Rectangle(5, 5);

        Shape[] arr = {circle, rectangle};

        foreach (var shape in arr)
        {
            Console.WriteLine(shape.CalculateArea());
            Console.WriteLine(shape.CalculatePerimeter());
            Console.WriteLine(shape.Draw());
        }
    }
}