namespace DungeonsAndCodeWizards.Entities.DungeonMasterCommands
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class UseItem : DungeonMasterCommand
    {
        public UseItem(string[] args, Dictionary<string, Character> party, Stack<Item> itemPool) 
            : base(args, party, itemPool)
        {
        }

        public override string Execute()
        {
            var characterName = args[0];
            var itemName = args[1];

            var character = this.CheckCharacter(characterName);

            var currentItem = character.Bag.GetItem(itemName);
            character.UseItem(currentItem);

            return $"{character.Name} used {itemName}.";
        }
    }
}