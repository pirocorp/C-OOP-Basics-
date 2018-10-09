namespace MassEffect.Engine.Commands
{
    using System;
    using System.Linq;
    using GameObjects.Enhancements;
    using GameObjects.Ships;
    using Interfaces;

    public class CreateCommand : Command
    {
        public CreateCommand(IGameEngine gameEngine) 
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            //create {shipType} {shipName} {starSystem} {enhancement1 enhancements2 ...} 
            var type = commandArgs[1];
            var shipName = commandArgs[2];
            var locationName = commandArgs[3];

            var shipAllreadyExists = this.GameEngine.Starships.Any(x => x.Name == shipName);

            if (shipAllreadyExists)
            {
                throw new ArgumentException(Messages.DuplicateShipName);
            }

            var location = this.GameEngine.Galaxy.GetStarSystemByName(locationName);
            var shipType = (StarshipType)Enum.Parse(typeof(StarshipType), type);

            var newShip = this.GameEngine.ShipFactory.CreateShip(shipType, shipName, location);
            this.GameEngine.Starships.Add(newShip);

            for (int i = 4; i < commandArgs.Length; i++)
            {
                var enhancementType = (EnhancementType)
                    Enum.Parse(typeof(EnhancementType), commandArgs[i]);

                var enhancement = this.GameEngine.EnhancementFactory.Create(enhancementType);
                newShip.AddEnhancement(enhancement);
            }

            Console.WriteLine(Messages.CreatedShip, shipType, shipName);
        }
    }
}
