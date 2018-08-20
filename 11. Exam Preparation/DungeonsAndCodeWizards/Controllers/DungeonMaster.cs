namespace DungeonsAndCodeWizards.Controllers
{
    using Entities;
    using Factories;
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Entities.DungeonMasterCommands;
    using Utilities;

    public class DungeonMaster
    {
        private int lastSurvivorRounds;

        private Dictionary<string, Character> party;
        private Stack<Item> itemPool;

        private CharacterFactory charactersFactory;
        private ItemFactory itemFactory;

        public DungeonMaster()
        {
            this.lastSurvivorRounds = 0;

            this.party = new Dictionary<string, Character>();
            this.itemPool = new Stack<Item>();

            this.charactersFactory = new CharacterFactory();
            this.itemFactory = new ItemFactory();
        }

        public string JoinParty(string[] args)
        {
            var joinParty = new JoinParty(args, this.party, this.itemPool, this.charactersFactory);

            return joinParty.Execute();
        }

        public string AddItemToPool(string[] args)
        {
            var addItemToPool = new AddItemToPool(args, this.party, this.itemPool, this.itemFactory);

            return addItemToPool.Execute();
        }

        public string PickUpItem(string[] args)
        {
            var pickUpItem = new PickUpItem(args, this.party, this.itemPool);

            return pickUpItem.Execute();
        }

        public string UseItem(string[] args)
        {
            var useItem = new UseItem(args, this.party, this.itemPool);

            return useItem.Execute();
        }

        public string UseItemOn(string[] args)
        {
            var useItemOn = new UseItemOn(args, this.party, this.itemPool);

            return useItemOn.Execute();
        }

        public string GiveCharacterItem(string[] args)
        {
            var giveCharacterItem = new GiveCharacterItem(args, this.party, this.itemPool);

            return giveCharacterItem.Execute();
        }

        public string GetStats()
        {
            var getStats = new GetStats(null, this.party, this.itemPool);

            return getStats.Execute();
        }

        public string Attack(string[] args)
        {
            var attack = new Attack(args, this.party, this.itemPool);

            return attack.Execute();
        }

        public string Heal(string[] args)
        {
            var heal = new Heal(args, this.party, this.itemPool);

            return heal.Execute();
        }

        public string EndTurn(string[] args)
        {
            var allAliveCharacters = this.party
                .Where(x => x.Value.IsAlive)
                .Select(x => x.Value)
                .ToList();

            var result = new StringBuilder();

            foreach (var character in allAliveCharacters)
            {
                var healthBeforeRest = character.Health;
                character.Rest();

                result.AppendLine($"{character.Name} rests ({healthBeforeRest} => {character.Health})");
            }

            if (allAliveCharacters.Count <= 1)
            {
                this.lastSurvivorRounds++;
            }

            return result.ToString().TrimEnd();
        }

        public bool IsGameOver()
        {
            var lastOrNonSurvived = this.party.Count(x => x.Value.IsAlive) <= 1;
            var survivedTooLong = this.lastSurvivorRounds > 1;

            return lastOrNonSurvived && survivedTooLong;
        }
    }
}