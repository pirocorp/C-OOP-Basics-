using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        //OldestFamilyMember();
        OpinionPoll();
    }

    private static void OpinionPoll()
    {
        var n = int.Parse(Console.ReadLine());

        var listOfPeople = new List<Person>();

        for (var i = 0; i < n; i++)
        {
            var tokens = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            var name = tokens[0];
            var age = int.Parse(tokens[1]);

            var currentPerson = new Person(name, age);

            listOfPeople.Add(currentPerson);
        }

        listOfPeople
            .Where(x => x.Age > 30)
            .OrderBy(x => x.Name)
            .ToList()
            .ForEach(x => Console.WriteLine($"{x.Name} - {x.Age}"));
    }

    private static void OldestFamilyMember()
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