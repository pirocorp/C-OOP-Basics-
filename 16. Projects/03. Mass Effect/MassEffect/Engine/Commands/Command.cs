namespace MassEffect.Engine.Commands
{
    using System.Linq;
    using Exceptions;
    using Interfaces;

    public abstract class Command
    {
        protected Command(IGameEngine gameEngine)
        {
            this.GameEngine = gameEngine;
        }

        public IGameEngine GameEngine { get; set; }

        public abstract void Execute(string[] commandArgs);

        protected IStarship GetStarshipByName(string name)
        {
            return this.GameEngine.Starships
                .First(s => s.Name == name);
        }

        protected void ValidateAlive(IStarship starship)
        {
            if (starship.Health <= 0)
            {
                throw new ShipException(Messages.ShipAlreadyDestroyed);
            }
        }
    }
}
