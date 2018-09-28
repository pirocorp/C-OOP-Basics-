namespace P04_CustomLINQExtensionMethods
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CustomLinq
    {
        public static void Main()
        {
            var nums = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            var result = nums.WhereNot(x => x % 2 == 0).ToList();
            Console.WriteLine(string.Join(", ", result));
            Console.WriteLine(result.Max(x => x));
            Console.WriteLine();

            var students = new List<Student>
            {
                new Student("Pesho", 3),
                new Student("Gosho", 2),
                new Student("Mariika", 7),
                new Student("Stamat", 5)
            };

            Console.WriteLine(Extensions.Max(students, x => x.Grade));
        }
    }
}
