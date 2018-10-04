namespace MultimediaStore.Core
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Models.Items;

    public class StoreEngine
    {
        private const string DATE_TIME_FORMAT = "dd-MM-yyyy";

        private IDictionary<IItem, int> supplies;

        public StoreEngine()
        {
            this.supplies = new Dictionary<IItem, int>();
        }

        public void Run()
        {
            while (true)
            {
                var inputData = Console.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var command = inputData[0].ToLower();
                var commandArgs = inputData.Skip(1).ToArray();

                switch (command)
                {
                    case "supply":
                        var type = commandArgs[0];
                        var quantity = int.Parse(commandArgs[1]);
                        var paramsString = commandArgs[2];

                        this.ExecuteSupplyCommand(type, paramsString, quantity);
                        break;
                    case "sell":
                        break;
                    case "rent":
                        break;
                    case "report":
                        break;
                    case "exit":
                        return;
                    default:
                        throw new InvalidOperationException("Invalid command.");
                }
            }
        }

        private void ExecuteSupplyCommand(string itemType, string paramsString, int quantity)
        {
            switch (itemType)
            {
                case "book":
                {
                    var book = Book.Parse(paramsString);
                    this.AddToSupplies(book, quantity);
                    break;
                }
                case "movie":
                {
                    var movie = Movie.Parse(paramsString);
                    this.AddToSupplies(movie, quantity);
                    break;
                }
                case "game":
                {
                    var game = Game.Parse(paramsString);
                    this.AddToSupplies(game, quantity);
                    break;
                }
                default:
                    throw new ArgumentException("Invalid item type.");
            }
        }

        private void AddToSupplies(IItem item, int quantity)
        {
            if (!this.supplies.ContainsKey(item))
            {
                this.supplies[item] = 0;
            }

            this.supplies[item] += quantity;
        }
    }
}