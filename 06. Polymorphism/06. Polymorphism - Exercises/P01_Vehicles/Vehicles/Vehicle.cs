namespace P01_Vehicles.Vehicles
{
    using System;
    using Interfaces;

    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double airConditioningConsumption;
        private double tankCapacity;

        public Vehicle(double fuelQuantity, double fuelConsumption, double airConditioningConsumption, double tankCapacity)
        {
            this.fuelConsumption = fuelConsumption;
            this.airConditioningConsumption = airConditioningConsumption;
            this.tankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
        }

        public double FuelQuantity
        {
            get => this.fuelQuantity;
            set
            {
                if (value > this.tankCapacity)
                {
                    this.fuelQuantity += 0;
                }
                else
                {
                    this.fuelQuantity = value;
                }
            }
        }

        public virtual void Refuel(double fuel)
        {
            var freeSpace = this.tankCapacity - this.fuelQuantity;

            if (fuel <= 0)
            {
                throw new ArgumentException($"Fuel must be a positive number");
            }

            if (freeSpace < fuel)
            {
                throw new ArgumentException($"Cannot fit {fuel} fuel in the tank");
            }

            this.fuelQuantity += fuel;
        }

        public string Drive(double distance)
        {
            var neededFuel = (this.fuelConsumption + this.airConditioningConsumption) * distance;

            if (neededFuel > this.fuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.fuelQuantity -= neededFuel;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public string DriveEmpty(double distance)
        {
            var neededFuel = this.fuelConsumption * distance;

            if (neededFuel > this.fuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }

            this.fuelQuantity -= neededFuel;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.fuelQuantity:F2}";
        }
    }
}