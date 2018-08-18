namespace StorageMaster.Controllers
{
    using Entities;
    using Factories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Utilities;

    public class StorageMaster
    {
        private List<Product> productPool;
        private Dictionary<string, Storage> storageRegistry;

        private ProductFactory productFactory;
        private StorageFactory storageFactory;

        private Vehicle currentVehicle;

        public StorageMaster()
        {
            this.productPool = new List<Product>();
            this.storageRegistry = new Dictionary<string, Storage>();

            this.productFactory = new ProductFactory();
            this.storageFactory = new StorageFactory();
        }

        public string AddProduct(string type, double price)
        {
            var newProduct = this.productFactory.CreateProduct(type, price);
            this.productPool.Add(newProduct);

            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            var newStorage = this.storageFactory.CreateStorage(type, name);
            this.storageRegistry.Add(name, newStorage);

            return $"Registered {name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            var currentStorage = this.storageRegistry[storageName];

            this.currentVehicle = currentStorage.GetVehicle(garageSlot);

            var vehicleType = this.currentVehicle.GetType().Name;

            return $"Selected {vehicleType}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            var products = productNames.ToList();
            var productCount = products.Count();
            var loadedProductCount = 0;

            foreach (var name in products)
            {
                if (!this.currentVehicle.IsFull)
                {
                    var lastItemWithThisName = this.productPool.LastOrDefault(x => x.GetType().Name == name);

                    if (lastItemWithThisName == null)
                    {
                        throw new InvalidOperationException(string.Format(ExceptionMessages.ProductIsOutOfStock, name));
                    }

                    this.currentVehicle.LoadProduct(lastItemWithThisName);
                    var lastindex = this.productPool.LastIndexOf(lastItemWithThisName);
                    this.productPool.RemoveAt(lastindex);
                    loadedProductCount++;
                }
            }

            return $"Loaded {loadedProductCount}/{productCount} products into {this.currentVehicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            if (!this.storageRegistry.ContainsKey(sourceName))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidSourceStorage);
            }

            if (!this.storageRegistry.ContainsKey(destinationName))
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidDestinationStorage);
            }

            var sourceGarage = this.storageRegistry[sourceName];

            var destinationGarage = this.storageRegistry[destinationName];

            var vehicleType = sourceGarage.GetVehicle(sourceGarageSlot).GetType().Name;

            var destinationSlot = sourceGarage.SendVehicleTo(sourceGarageSlot, destinationGarage);

            return $"Sent {vehicleType} to {destinationName} (slot {destinationSlot})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            var storage = this.storageRegistry[storageName];

            var productsInVehicle = storage.GetVehicle(garageSlot).Trunk.Count;

            var unloadedProducts = storage.UnloadVehicle(garageSlot);

            return $"Unloaded {unloadedProducts}/{productsInVehicle} products at {storageName}";
        }

        public string GetStorageStatus(string storageName)
        {
            var storage = this.storageRegistry[storageName];

            var countProductsByType = storage.Products.ToList()
                .GroupBy(x => x.Name, (k, v) => new
                {
                    Name = k,
                    v.ToList().Count,
                })
                .OrderByDescending(x => x.Count)
                .ThenBy(x => x.Name)
                .Select(x => $"{x.Name} ({x.Count})")
                .ToArray();

            var sumOfProductsWeight = storage.Products.Sum(x => x.Weight);

            var storageCapacity = storage.Capacity;

            var garageSlots = storage.DrawGarageSlots();

            return $"Stock ({sumOfProductsWeight}/{storageCapacity}): [{string.Join(", ", countProductsByType)}]" + Environment.NewLine +
                   $"{garageSlots}";
        }

        public string GetSummary()
        {
            var summary = this.storageRegistry
                .OrderByDescending(x => x.Value.Products.Sum(p => p.Price))
                .Select(x => $"{x.Value.Name}:" + Environment.NewLine + $"Storage worth: ${x.Value.Products.Sum(p => p.Price):F2}")
                .ToArray();

            return string.Join(Environment.NewLine, summary);
            ;
        }
    }
}