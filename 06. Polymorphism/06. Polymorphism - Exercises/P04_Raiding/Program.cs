namespace P04_Raiding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public static class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var heroes = new List<BaseHero>();

            for (var i = 0; i < n; i++)
            {
                var name = Console.ReadLine();
                var type = Console.ReadLine();

                var currentHero = CreateHero(name, type);

                if (currentHero is null)
                {
                    Console.WriteLine("Invalid hero!");
                    i--;
                    continue;
                }

                heroes.Add(currentHero);
            }

            int.TryParse(Console.ReadLine(), out var bossPower);

            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
            }

            var totalPower = heroes.Sum(h => h.Power);

            if (totalPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }

        private static BaseHero CreateHero(string name, string typeName)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name.Equals(typeName));

            if (type is null)
            {
                return null;
            }

            var parameters = new object[] {name};
            var parameterTypes = parameters.Select(p => p.GetType()).ToArray();
            var constructor = type?.GetConstructor(parameterTypes);

            return constructor?.Invoke(parameters) as BaseHero;
        }
    }
}
