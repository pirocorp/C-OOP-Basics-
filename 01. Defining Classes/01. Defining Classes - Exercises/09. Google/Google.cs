namespace Google
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Google
    {
        public static void Main()
        {
            var inputLine = string.Empty;

            var persons = new Dictionary<string, Person>();

            while ((inputLine = Console.ReadLine()) != "End")
            {
                var tokens = inputLine.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

                var personName = tokens[0];

                if (!persons.ContainsKey(personName))
                {
                    persons[personName] = new Person(personName);
                }

                var subClass = tokens[1];

                var args = tokens.Skip(2).ToArray();

                switch (subClass)
                {
                    case "company":
                        var currentCompany = Company.Parse(args);
                        persons[personName].Company = currentCompany;
                        break;
                    case "pokemon":
                        var currentPokemon = Pokemon.Parse(args);
                        persons[personName].Pokemons.Add(currentPokemon);
                        break;
                    case "parents":
                        var currentParent = Parent.Parse(args);
                        persons[personName].Parents.Add(currentParent);
                        break;
                    case "children":
                        var currentChild = Child.Parse(args);
                        persons[personName].Children.Add(currentChild);
                        break;
                    case "car":
                        var currentCar = Car.Parse(args);
                        persons[personName].Car = currentCar;
                        break;
                }
            }

            var searchedPersonName = Console.ReadLine();
            Console.WriteLine(persons[searchedPersonName]);
        }
    }
}
