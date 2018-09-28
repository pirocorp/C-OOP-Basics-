namespace P02_Func
{
    using System;

    public class Functions
    {
        static void Main()
        {
            int[] nums = {1, 2, 3, 6, 4, 11};
            var result = nums.TakeWhile(x => x < 5);
            Console.WriteLine(string.Join(", ", result));
        }
    }
}
