namespace MassEffect.Engine.Commands
{
    using System;
    using Exceptions;
    using Interfaces;

    public class PlotJumpCommand : Command
    {
        public PlotJumpCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            //plot-jump {shipName} {starSystem}
            var shipName = commandArgs[1];
            var starSystemName = commandArgs[2];

            var ship = this.GetStarshipByName(shipName);
            this.ValidateAlive(ship);

            var previousLocation = ship.Location;
            var destination = this.GameEngine.Galaxy.GetStarSystemByName(starSystemName);

            if (previousLocation.Name == destination.Name)
            {
                throw new ShipException(string.Format(Messages.ShipAlreadyInStarSystem, destination.Name));
            }

            this.GameEngine.Galaxy.TravelTo(ship, destination);
            Console.WriteLine(Messages.ShipTraveled, shipName, previousLocation.Name, destination.Name);
        }
    }
}
