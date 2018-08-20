namespace DungeonsAndCodeWizards.Entities.DungeonMasterCommands
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Factories;

    public class JoinParty : DungeonMasterCommand
    {
        private readonly CharacterFactory charactersFactory;

        public JoinParty(string[] args, Dictionary<string, Character> party, Stack<Item> itemPool, CharacterFactory charactersFactory) 
            : base(args, party, itemPool)
        {
            this.charactersFactory = charactersFactory;
        }

        public override string Execute()
        {
            var faction = this.args[0];
            var type = this.args[1];
            var name = this.args[2];
            var newCharacter = this.charactersFactory.CreateCharacter(faction, type, name);

            this.party[name] = newCharacter;
            return $"{name} joined the party!";
        }
    }
}