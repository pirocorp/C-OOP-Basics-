using System;

class Program
{
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        var family = new Family();

        for (var i = 0; i < n; i++)
        {
            var tokens = Console.ReadLine()
                .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

            var name = tokens[0];
            var age = int.Parse(tokens[1]);

            family.AddMember(new Person(name, age));
        }

        Console.WriteLine(family.GetOldestMember());
    }
}