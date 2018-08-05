namespace P01_Vehicles.Vehicles
{
    using Interfaces;

    public abstract class Vehicle : IVehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double airConditioningConsumption;

        public Vehicle(double fuelQuantity, double fuelConsumption, double airConditioningConsumption)
        {
            this.fuelQuantity = fuelQuantity;
            this.fuelConsumption = fuelConsumption;
            this.airConditioningConsumption = airConditioningConsumption;
        }

        public virtual void Refuel(double fuel)
        {
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

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.fuelQuantity:F2}";
        }
    }
}