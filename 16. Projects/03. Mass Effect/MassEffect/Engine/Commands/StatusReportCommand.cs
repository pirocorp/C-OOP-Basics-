namespace MassEffect.Engine.Commands
{
    using System;
    using Interfaces;

    public class StatusReportCommand : Command
    {
        public StatusReportCommand(IGameEngine gameEngine)
            : base(gameEngine)
        {
        }

        public override void Execute(string[] commandArgs)
        {
            //status-report {shipName}
            var shipName = commandArgs[1];
            var ship = this.GetStarshipByName(shipName);

            Console.WriteLine(ship);
        }
    }
}
