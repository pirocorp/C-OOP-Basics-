namespace DungeonsAndCodeWizards.Entities.DungeonMasterCommands
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Utilities;

    public class PickUpItem : DungeonMasterCommand
    {
        public PickUpItem(string[] args, Dictionary<string, Character> party, Stack<Item> itemPool) 
            : base(args, party, itemPool)
        {
        }

        public override string Execute()
        {
            var characterName = args[0];

            var character = this.CheckCharacter(characterName);

            if (this.itemPool.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.PoolIsEmpty);
            }

            var lastItemInPool = this.itemPool.Pop();
            character.ReceiveItem(lastItemInPool);

            return $"{characterName} picked up {lastItemInPool.GetType().Name}!";
        }
    }
}