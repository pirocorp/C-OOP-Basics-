namespace MassEffect.Engine.Commands
{
    using System;
    using Exceptions;
    using Interfaces;

    public class AttackCommand : Command
    {
        public AttackCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            //attack {attackerShip} {targetShip} 
            var attackerShipName = commandArgs[1];
            var targetShipName = commandArgs[2];

            var attackerShip = this.GetStarshipByName(attackerShipName);
            var targetShip = this.GetStarshipByName(targetShipName);

            this.ProcessStarshipBattle(attackerShip, targetShip);
        }

        private void ProcessStarshipBattle(IStarship attackerShip, IStarship targetShip)
        {
            this.ValidateAlive(attackerShip);
            this.ValidateAlive(targetShip);

            var battleLocation = attackerShip.Location;

            if (targetShip.Location != battleLocation)
            {
                throw new ShipException(Messages.NoSuchShipInStarSystem);
            }

            var attack = attackerShip.ProduceAttack();
            targetShip.RespondToAttack(attack);
            Console.WriteLine(Messages.ShipAttacked, attackerShip.Name, targetShip.Name);

            if (targetShip.Shields < 0)
            {
                targetShip.Shields = 0;
            }

            if (targetShip.Health <= 0)
            {
                targetShip.Health = 0;
                Console.WriteLine(Messages.ShipDestroyed, targetShip.Name);
            }
        }
    }
}
