namespace MultimediaStore.Core
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using Interfaces;
    using Models.Items;
    using MultimediaShop.Exceptions;

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
                        var id = commandArgs[0];
                        var item = this.GetItemById(id);
                        var saleDate = ToDateTime(commandArgs[1]);

                        this.ExecuteSellCommand(item, saleDate);
                        break;
                    case "rent":
                        id = commandArgs[0];
                        item = this.GetItemById(id);
                        var rentDate = ToDateTime(commandArgs[1]);
                        var deadline = ToDateTime(commandArgs[2]);

                        this.ExecuteRentCommand(item, rentDate, deadline);
                        break;
                    case "report":
                        this.ExecuteReportCommand(commandArgs);
                        break;
                    case "exit":
                        return;
                    default:
                        throw new InvalidOperationException("Invalid command.");
                }
            }
        }

        private void ExecuteReportCommand(string[] commandArgs)
        {
            var reportType = commandArgs[0];
            switch (reportType)
            {
                case "sales":
                    var startDate = ToDateTime(commandArgs[1]);
                    var salesIncome = SaleManager.ReportSalesIncome(startDate);

                    Console.WriteLine($"{salesIncome:F2}");
                    break;
                case "rents":
                    var overdueRents = RentManager.ReportOverdueRents();

                    Console.WriteLine(string.Join(Environment.NewLine, overdueRents));
                    break;
                default:
                    throw new ArgumentException("Invalid report type.");
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

        private IItem GetItemById(string id)
        {
            return this.supplies
                .First(x => x.Key.Id == id)
                .Key;
        }

        private static DateTime ToDateTime(string dateString)
        {
            return DateTime.ParseExact(dateString, DATE_TIME_FORMAT, CultureInfo.InvariantCulture);
        }

        private void ExecuteSellCommand(IItem item, DateTime saleDate)
        {
            if (this.supplies[item] == 0)
            {
                throw new InsufficientSuppliesException("There are not enough supplies to sell this item.");
            }

            SaleManager.AddSale(item, saleDate);
            this.supplies[item]--;
        }

        private void ExecuteRentCommand(IItem item, DateTime rentDate, DateTime deadline)
        {
            if (this.supplies[item] == 0)
            {
                throw new InsufficientSuppliesException("There are not enough supplies to sell this item.");
            }

            RentManager.AddRent(item, rentDate, deadline);
            this.supplies[item]--;
        }
    }
}