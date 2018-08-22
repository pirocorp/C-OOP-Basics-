namespace _9._Test
{
    using System;

    public class StartUp
    {
        static void Main()
        {
            var a = 5;
            Modify(ref a);
            Console.WriteLine(a);

            var test = new Test(ref a);
            test.Modify();
            Console.WriteLine(a);
        }

        private static void Modify(ref int a)
        {
            a++;
        }
    }
}
