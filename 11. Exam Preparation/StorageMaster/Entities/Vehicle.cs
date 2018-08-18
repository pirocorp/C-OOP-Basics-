namespace StorageMaster.Entities
{
    using Factories;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Utilities;

    public abstract class Vehicle
    {
        private Stack<Product> products;

        protected Vehicle(int capacity)
        {
            this.Capacity = capacity;
            this.products = new Stack<Product>();
        }

        public int Capacity { get; private set; }

        public IReadOnlyCollection<Product> Trunk => this.products;

        public bool IsFull => this.products.Sum(x => x.Weight) >= this.Capacity;

        public bool IsEmpty => this.products.Count == 0;

        public void LoadProduct(Product product)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException(ExceptionMessages.FullVehicle);
            }

            this.products.Push(product);
        }

        public Product Unload()
        {
            if (this.IsEmpty)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyVehicle);
            }

            var lastProduct = this.products.Pop();

            return lastProduct;
        }

        public static IEnumerable<Vehicle> CreateVehiclesByType(string vehicleType, int quantaty)
        {
            var vehicleFactory = new VehicleFactory();

            var vehicles = new List<Vehicle>();

            for (var i = 0; i < quantaty; i++)
            {
                var currentVehicle = vehicleFactory.CreateVehicle(vehicleType);

                vehicles.Add(currentVehicle);
            }

            return vehicles;
        }
    }
}