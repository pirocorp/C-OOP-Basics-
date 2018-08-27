using System;

namespace P00_CustomList
{
    public class StartUp
    {
        public static void Main()
        {
            var list = new CustomList<int>();

            list.Add(10);
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Remove(3);
            list.Add(4);
            list.Add(5);
            list.Add(6);
            list.Add(7);
            list.Remove(7);
            Console.WriteLine(list);
            Console.WriteLine(list.Max());
            Console.WriteLine(list.Min());
            Console.WriteLine(list[5]);
            list.Add(12);
            list.Add(13);
            list.Add(14);
            list.Add(15);
            Console.WriteLine(list);
        }
    }
}
