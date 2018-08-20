namespace DungeonsAndCodeWizards.Entities.DungeonMasterCommands
{
    using System;
    using System.Collections.Generic;
    using Utilities;

    public abstract class DungeonMasterCommand
    {
        protected string[] args;

        protected Dictionary<string, Character> party;
        protected Stack<Item> itemPool;

        protected DungeonMasterCommand(string[] args, Dictionary<string, Character> party, Stack<Item> itemPool)
        {
            this.args = args;
            this.party = party;
            this.itemPool = itemPool;
        }

        public abstract string Execute();

        protected Character CheckCharacter(string characterName)
        {
            if (!this.party.ContainsKey(characterName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotFound, characterName));
            }

            return this.party[characterName];
        }
    }
}