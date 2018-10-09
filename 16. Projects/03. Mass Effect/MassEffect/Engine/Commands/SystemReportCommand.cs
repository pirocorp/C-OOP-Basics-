namespace MassEffect.Engine.Commands
{
    using System;
    using System.Linq;
    using Interfaces;

    public class SystemReportCommand : Command
    {
        public SystemReportCommand(IGameEngine gameEngine) 
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            //system-report {starSystem} 
            var locationName = commandArgs[1];

            var starships = this.GameEngine.Starships
                .Where(s => s.Location.Name == locationName)
                .ToList();

            var intactShips = starships
                .Where(x => x.Health > 0)
                .OrderByDescending(x => x.Health)
                .ThenByDescending(x => x.Shields)
                .ToList();

            Console.WriteLine($"Intact ships:");

            var intactShipsAsString = intactShips.Count > 0 ? $"{string.Join(Environment.NewLine, intactShips)}" : "N/A";

            Console.WriteLine(intactShipsAsString);

            var destroyedShips = starships
                .Where(x => x.Health <= 0)
                .OrderBy(x => x.Name)
                .ToList();

            Console.WriteLine($"Destroyed ships:");

            var destroyedShipsAsString = destroyedShips.Count > 0 ? $"{string.Join(Environment.NewLine, destroyedShips)}" : "N/A";

            Console.WriteLine(destroyedShipsAsString);
        }
    }
}