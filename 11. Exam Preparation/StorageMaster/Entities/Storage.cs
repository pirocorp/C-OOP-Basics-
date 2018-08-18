namespace StorageMaster.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Utilities;

    public abstract class Storage
    {
        private List<Product> products;
        private Vehicle[] vehicles;

        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.GarageSlots = garageSlots;

            this.vehicles = new Vehicle[garageSlots];
            this.products = new List<Product>();

            this.InitializeGarage(vehicles);
        }

        public string Name { get; private set; }

        public int Capacity { get; private set; }

        public int GarageSlots { get; private set; }

        public bool IsFull => this.products.Sum(x => x.Weight) >= this.Capacity;

        public IReadOnlyCollection<Vehicle> Garage => Array.AsReadOnly(this.vehicles);

        public IReadOnlyCollection<Product> Products => this.products;

        public Vehicle GetVehicle(int garageSlot)
        {
            var currentGarageSlots = this.GarageSlots;

            if (garageSlot >= currentGarageSlots)
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGarageSlot);
            }

            var currentVehicle = this.vehicles[garageSlot];

            if (currentVehicle == null)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyGarageSlot);
            }

            return currentVehicle;
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            var currentVehicle = this.GetVehicle(garageSlot);

            var firstFreeGarageSlot = deliveryLocation.ReturnFirstFreeGarageSlot();

            if (firstFreeGarageSlot < 0)
            {
                throw new InvalidOperationException(ExceptionMessages.GarageIsFull);
            }

            this.vehicles[garageSlot] = null;

            deliveryLocation.vehicles[firstFreeGarageSlot] = currentVehicle;

            return firstFreeGarageSlot;
        }

        private int ReturnFirstFreeGarageSlot()
        {
            for (var currentGarageSlot = 0; currentGarageSlot < this.GarageSlots; currentGarageSlot++)
            {
                if (this.vehicles[currentGarageSlot] == null)
                {
                    return currentGarageSlot;
                }
            }

            return -1;
        }

        public int UnloadVehicle(int garageSlot)
        {
            if (this.IsFull)
            {
                throw new InvalidOperationException(ExceptionMessages.StorageIsFull);
            }

            var numberOfUnloadedProducts = 0;

            var currentVehicle = this.GetVehicle(garageSlot);

            while (currentVehicle.Trunk.Count > 0 || !this.IsFull)
            {
                try
                {
                    var currentProduct = currentVehicle.Unload();

                    if (this.Capacity < this.products.Sum(x => x.Weight))
                    {
                        break;
                    }

                    numberOfUnloadedProducts++;
                    this.products.Add(currentProduct);
                }
                catch (InvalidOperationException e)
                {
                    return numberOfUnloadedProducts;
                }
            }

            return numberOfUnloadedProducts;
        }

        public string DrawGarageSlots()
        {
            var result = new List<string>();

            for (var i = 0; i < this.GarageSlots; i++)
            {
                if (this.vehicles[i] == null)
                {
                    result.Add($"empty");
                }
                else
                {
                    var vehicleType = this.vehicles[i].GetType().Name;
                    result.Add(vehicleType);
                }
            }

            return $"Garage: [{string.Join("|", result)}]";
        }

        private void InitializeGarage(IEnumerable<Vehicle> vehicles)
        {
            var garageSlot = 0;
            foreach (var vehicle in vehicles)
            {
                this.vehicles[garageSlot++] = vehicle;
            }
        }
    }
}