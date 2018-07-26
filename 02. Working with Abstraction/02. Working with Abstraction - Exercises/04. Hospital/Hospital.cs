namespace P04_Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Hospital
    {
        public static void Main()
        {
            var doctors = new Dictionary<string, List<string>>();
            var departments = new Dictionary<string, List<List<string>>>();


            var command = Console.ReadLine();

            while (command != "Output")
            {
                var tokens = command.Split();
                var departament = tokens[0];
                var firstName = tokens[1];
                var lastName = tokens[2];
                var patient = tokens[3];
                var fullName = firstName + lastName;

                if (!doctors.ContainsKey(firstName + lastName))
                {
                    doctors[fullName] = new List<string>();
                }
                if (!departments.ContainsKey(departament))
                {
                    departments[departament] = new List<List<string>>();

                    for (var room = 0; room < 20; room++)
                    {
                        departments[departament].Add(new List<string>());
                    }
                }

                var notEmpty = departments[departament].SelectMany(x => x).Count() < 60;

                if (notEmpty)
                {
                    var room = 0;
                    doctors[fullName].Add(patient);

                    for (var roomIndex = 0; roomIndex < departments[departament].Count; roomIndex++)
                    {
                        if (departments[departament][roomIndex].Count < 3)
                        {
                            room = roomIndex;
                            break;
                        }
                    }

                    departments[departament][room].Add(patient);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();

            while (command != "End")
            {
                var args = command.Split();

                if (args.Length == 1)
                {
                    Console.WriteLine(string.Join("\n", departments[args[0]].Where(x => x.Count > 0).SelectMany(x => x)));
                }
                else if (args.Length == 2 && int.TryParse(args[1], out var room))
                {
                    Console.WriteLine(string.Join("\n", departments[args[0]][room - 1].OrderBy(x => x)));
                }
                else
                {
                    Console.WriteLine(string.Join("\n", doctors[args[0] + args[1]].OrderBy(x => x)));
                }
                command = Console.ReadLine();
            }
        }
    }
}