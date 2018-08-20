namespace DungeonsAndCodeWizards.Entities.DungeonMasterCommands
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;

    public class Heal : DungeonMasterCommand
    {
        public Heal(string[] args, Dictionary<string, Character> party, Stack<Item> itemPool) 
            : base(args, party, itemPool)
        {
        }

        public override string Execute()
        {
            var healerName = args[0];
            var healingReceiverName = args[1];

            var healerCharacter = this.CheckCharacter(healerName);
            var healingReceiverCharacter = this.CheckCharacter(healingReceiverName);

            if (!(healerCharacter is IHealable healer))
            {
                throw new ArgumentException($"{healerCharacter.Name} cannot heal!");
            }

            healer.Heal(healingReceiverCharacter);

            var result = $"{healerCharacter.Name} heals {healingReceiverCharacter.Name} for {healerCharacter.AbilityPoints}! {healingReceiverCharacter.Name} has {healingReceiverCharacter.Health} health now!";
            return result;
        }
    }
}