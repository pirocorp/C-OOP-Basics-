namespace StorageMaster
{
    using System;
    using System.Linq;
    using Controllers;

    public class Engine
    {
        public void Run()
        {
            var storageMaster = new StorageMaster();

            var inputLine = string.Empty;

            while ((inputLine = Console.ReadLine()) != "END")
            {
                try
                {
                    ProcessCommand(inputLine, storageMaster);
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine($"Error: {e.Message}");
                }
            }

            Console.WriteLine(storageMaster.GetSummary());
        }

        private static void ProcessCommand(string inputLine, StorageMaster storageMaster)
        {
            var tokens = inputLine.Split();
            var command = tokens[0];

            switch (command)
            {
                case "AddProduct":
                    var type = tokens[1];
                    var price = double.Parse(tokens[2]);
                    Console.WriteLine(storageMaster.AddProduct(type, price));
                    break;
                case "RegisterStorage":
                    type = tokens[1];
                    var name = tokens[2];
                    Console.WriteLine(storageMaster.RegisterStorage(type, name));
                    break;
                case "SelectVehicle":
                    var storageName = tokens[1];
                    var garageSlot = int.Parse(tokens[2]);
                    Console.WriteLine(storageMaster.SelectVehicle(storageName, garageSlot));
                    break;
                case "LoadVehicle":
                    var args = tokens.Skip(1).ToArray();
                    Console.WriteLine(storageMaster.LoadVehicle(args));
                    break;
                case "SendVehicleTo":
                    var sourceName = tokens[1];
                    var sourceGarageSlot = int.Parse(tokens[2]);
                    var destinationName = tokens[3];
                    Console.WriteLine(storageMaster.SendVehicleTo(sourceName, sourceGarageSlot, destinationName));
                    break;
                case "UnloadVehicle":
                    storageName = tokens[1];
                    garageSlot = int.Parse(tokens[2]);
                    Console.WriteLine(storageMaster.UnloadVehicle(storageName, garageSlot));
                    break;
                case "GetStorageStatus":
                    storageName = tokens[1];
                    Console.WriteLine(storageMaster.GetStorageStatus(storageName));
                    break;
            }
        }
    }
}