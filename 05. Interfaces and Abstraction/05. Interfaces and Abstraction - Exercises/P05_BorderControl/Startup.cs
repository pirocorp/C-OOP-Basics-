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

            while ((inputLine = Console.ReadLine())!= "End")
            {
                var tokens = inputLine.Split(new[] {' '});

                if (tokens.Length == 3)
                {
                    var name = tokens[0];
                    var age = int.Parse(tokens[1]);
                    var id = tokens[2];

                    var currentCitizen = new Citizen(name, age, id);
                    inhabitans.Add(currentCitizen);
                }
                else if(tokens.Length == 2)
                {
                    var model = tokens[0];
                    var id = tokens[1];

                    var currentRobot = new Robot(model, id);
                    inhabitans.Add(currentRobot);
                }
            }

            var fakeIds = Console.ReadLine();

            var result = inhabitans
                .Where(x => x.Id.EndsWith(fakeIds))
                .Select(x => x.Id)
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}