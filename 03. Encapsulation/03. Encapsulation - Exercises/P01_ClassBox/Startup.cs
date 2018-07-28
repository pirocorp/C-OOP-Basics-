using System;

public class Startup
{
    public static void Main()
    {
        //length, width and height
        var length = double.Parse(Console.ReadLine());
        var width = double.Parse(Console.ReadLine());
        var height = double.Parse(Console.ReadLine());

        Box box = null;

        try
        {
            box = new Box(length, width, height);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }

        Console.WriteLine($"Surface Area - {box.SurfaceArea():F2}");
        Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea():F2}");
        Console.WriteLine($"Volume - {box.Volume():F2}");
    }
}
