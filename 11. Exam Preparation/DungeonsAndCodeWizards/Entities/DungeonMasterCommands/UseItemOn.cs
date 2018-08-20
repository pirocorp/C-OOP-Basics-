namespace DungeonsAndCodeWizards.Entities.DungeonMasterCommands
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class UseItemOn : DungeonMasterCommand
    {
        public UseItemOn(string[] args, Dictionary<string, Character> party, Stack<Item> itemPool) 
            : base(args, party, itemPool)
        {
        }

        public override string Execute()
        {
            var giverName = args[0];
            var receiverName = args[1];
            var itemName = args[2];

            var giverCharavter = this.CheckCharacter(giverName);
            var reciverCharacter = this.CheckCharacter(receiverName);

            var currentItem = giverCharavter.Bag.GetItem(itemName);
            giverCharavter.UseItemOn(currentItem, reciverCharacter);

            return $"{giverName} used {itemName} on {receiverName}.";
        }
    }
}