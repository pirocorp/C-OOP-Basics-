namespace P05_BorderControl
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;

    public class Startup
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var buyers = new Dictionary<string, IBuyer>();

            for (var i = 0; i < n; i++)
            {
                var inputLine = Console.ReadLine();

                var tokens = inputLine.Split(new[] {' '});

                if (tokens.Length == 4)
                {
                    var name = tokens[0];
                    var age = int.Parse(tokens[1]);
                    var id = tokens[2];
                    var birthdate = tokens[3];

                    var currentCitizen = new Citizen(name, age, id, birthdate);
                    buyers.Add(name, currentCitizen);
                }
                else if(tokens.Length == 3)
                {
                    var name = tokens[0];
                    var age = int.Parse(tokens[1]);
                    var group = tokens[2];

                    var currentRebel = new Rebel(name, age, group);
                    buyers.Add(name, currentRebel);
                }
            }

            var currentBuyer = string.Empty;

            while ((currentBuyer = Console.ReadLine()) != "End")
            {
                if (buyers.ContainsKey(currentBuyer))
                {
                    buyers[currentBuyer].BuyFood();
                }
            }

            var result = buyers.Select(x => x.Value.Food).Sum();

            Console.WriteLine(result);

            //var inputLine = string.Empty;

            //var inhabitans = new List<IInhabitants>();
            //var birthdaters = new List<IBornable>();

            //while ((inputLine = Console.ReadLine())!= "End")
            //{
            //    var tokens = inputLine.Split(new[] {' '});

            //    if (tokens.Length == 5)
            //    {
            //        var name = tokens[1];
            //        var age = int.Parse(tokens[2]);
            //        var id = tokens[3];
            //        var birthdate = tokens[4];

            //        var currentCitizen = new Citizen(name, age, id, birthdate);
            //        inhabitans.Add(currentCitizen);
            //        birthdaters.Add(currentCitizen);
            //    }
            //    else if(tokens.Length == 3)
            //    {
            //        var command = tokens[0];

            //        if (command == "Robot")
            //        {
            //            var model = tokens[1];
            //            var id = tokens[2];

            //            var currentRobot = new Robot(model, id);
            //            inhabitans.Add(currentRobot);
            //        }
            //        else if (command == "Pet")
            //        {
            //            var name = tokens[1];
            //            var birthdate = tokens[2];

            //            var currentPet = new Pet(name, birthdate);
            //            birthdaters.Add(currentPet);
            //        }
            //    }
            //}

            ////var fakeIds = Console.ReadLine();

            ////var result = inhabitans
            ////    .Where(x => x.Id.EndsWith(fakeIds))
            ////    .Select(x => x.Id)
            ////    .ToArray();

            ////Console.WriteLine(string.Join(Environment.NewLine, result));

            //var birthYear = Console.ReadLine();

            //var result = birthdaters
            //    .Where(x => x.Birthdate.EndsWith(birthYear))
            //    .Select(x => x.Birthdate)
            //    .ToArray();

            //if (result.Length > 0)
            //{
            //    Console.WriteLine(string.Join(Environment.NewLine, result));
            //}
            //else
            //{
            //    Console.WriteLine();
            //}
        }
    }
}