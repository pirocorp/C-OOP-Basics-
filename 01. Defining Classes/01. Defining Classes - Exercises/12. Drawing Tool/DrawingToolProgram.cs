namespace _12._Drawing_Tool
{
    using System;

    public class DrawingToolProgram
    {
        public static void Main()
        {
            var name = Console.ReadLine();

            var width = int.Parse(Console.ReadLine());
            var height = 0;

            height = name == "Square" ? width : int.Parse(Console.ReadLine());

            var figure = new DrawingTool(width, height, name);
            Console.WriteLine(figure.Draw());
        }
    }
}