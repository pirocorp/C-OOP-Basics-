using System;
using System.Collections.Generic;
using System.Linq;
using P05_BorderControl.Interfaces;

namespace P05_BorderControl
{
    public class Startup
    {
        public static void Main()
        {
            var inputLine = string.Empty;

            var inhabitans = new List<IInhabitants>();
            var birthdaters = new List<IBornable>();

            while ((inputLine = Console.ReadLine())!= "End")
            {
                var tokens = inputLine.Split(new[] {' '});

                if (tokens.Length == 5)
                {
                    var name = tokens[1];
                    var age = int.Parse(tokens[2]);
                    var id = tokens[3];
                    var birthdate = tokens[4];

                    var currentCitizen = new Citizen(name, age, id, birthdate);
                    inhabitans.Add(currentCitizen);
                    birthdaters.Add(currentCitizen);
                }
                else if(tokens.Length == 3)
                {
                    var command = tokens[0];

                    if (command == "Robot")
                    {
                        var model = tokens[1];
                        var id = tokens[2];

                        var currentRobot = new Robot(model, id);
                        inhabitans.Add(currentRobot);
                    }
                    else if (command == "Pet")
                    {
                        var name = tokens[1];
                        var birthdate = tokens[2];

                        var currentPet = new Pet(name, birthdate);
                        birthdaters.Add(currentPet);
                    }
                }
            }

            //var fakeIds = Console.ReadLine();

            //var result = inhabitans
            //    .Where(x => x.Id.EndsWith(fakeIds))
            //    .Select(x => x.Id)
            //    .ToArray();

            //Console.WriteLine(string.Join(Environment.NewLine, result));

            var birthYear = Console.ReadLine();

            var result = birthdaters
                .Where(x => x.Birthdate.EndsWith(birthYear))
                .Select(x => x.Birthdate)
                .ToArray();

            if (result.Length > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, result));
            }
            else
            {
                Console.WriteLine();
            }
        }
    }
}