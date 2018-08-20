namespace DungeonsAndCodeWizards.Entities.DungeonMasterCommands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class GetStats : DungeonMasterCommand
    {
        public GetStats(string[] args, Dictionary<string, Character> party, Stack<Item> itemPool) 
            : base(args, party, itemPool)
        {
        }

        public override string Execute()
        {
            var result = this.party
                .OrderByDescending(x => x.Value.IsAlive)
                .ThenByDescending(x => x.Value.Health)
                .Select(x => x.Value)
                .ToList();

            return string.Join(Environment.NewLine, result);
        }
    }
}