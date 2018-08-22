namespace StructVsClass
{
    using System;

    public class StructClassComparison
    {
        private const long PixelsCount = 1920 * 1080;

        static void Main()
        {
            var initialStructMem = GC.GetTotalMemory(true);
            var structColors = new ColorStruct[PixelsCount];
            for (var i = 0; i < structColors.Length; i++)
            {
                structColors[i] = new ColorStruct();
            }

            var postStructMem = GC.GetTotalMemory(true);
            Console.WriteLine("{0} instances of struct: {1}KB",
                PixelsCount, (postStructMem - initialStructMem) / 1000);

            var initialClassMem = GC.GetTotalMemory(true);
            var classColors = new ColorClass[PixelsCount];
            for (var i = 0; i < classColors.Length; i++)
            {
                classColors[i] = new ColorClass();
            }

            var postClassMem = GC.GetTotalMemory(true);
            Console.WriteLine("{0} instances of class: {1}KB", 
                PixelsCount, (postClassMem - initialClassMem) / 1000);
        }
    }
}
