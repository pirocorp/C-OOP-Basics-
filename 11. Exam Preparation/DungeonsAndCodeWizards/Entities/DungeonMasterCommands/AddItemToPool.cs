namespace DungeonsAndCodeWizards.Entities.DungeonMasterCommands
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Factories;

    public class AddItemToPool : DungeonMasterCommand
    {
        private readonly ItemFactory itemFactory;

        public AddItemToPool(string[] args, Dictionary<string, Character> party, Stack<Item> itemPool, ItemFactory itemFactory) 
            : base(args, party, itemPool)
        {
            this.itemFactory = itemFactory;
        }

        public override string Execute()
        {
            var itemName = args[0];
            var newItem = this.itemFactory.CreateItem(itemName);
            this.itemPool.Push(newItem);

            return $"{itemName} added to pool.";
        }
    }
}