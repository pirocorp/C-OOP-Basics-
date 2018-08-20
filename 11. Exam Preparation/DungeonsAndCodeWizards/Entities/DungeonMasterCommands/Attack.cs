namespace DungeonsAndCodeWizards.Entities.DungeonMasterCommands
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;

    public class Attack : DungeonMasterCommand
    {
        public Attack(string[] args, Dictionary<string, Character> party, Stack<Item> itemPool) 
            : base(args, party, itemPool)
        {
        }

        public override string Execute()
        {
            var attackerName = args[0];
            var receiverName = args[1];

            var attackerCharacter = this.CheckCharacter(attackerName);
            var reciverCharacter = this.CheckCharacter(receiverName);

            if (!(attackerCharacter is IAttackable attacker))
            {
                throw new ArgumentException($"{attackerCharacter.Name} cannot attack!");
            }

            attacker.Attack(reciverCharacter);

            var result =
                $"{attackerName} attacks {receiverName} for {attackerCharacter.AbilityPoints} hit points! {receiverName} has {reciverCharacter.Health}/{reciverCharacter.BaseHealth} HP and {reciverCharacter.Armor}/{reciverCharacter.BaseArmor} AP left!";

            if (!reciverCharacter.IsAlive)
            {
                result += $"{Environment.NewLine}{reciverCharacter.Name} is dead!";
            }

            return result;
        }
    }
}