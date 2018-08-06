namespace P01_Vehicles.Vehicles
{
    public class Truck : Vehicle
    {
        private const double TAKEN_FUEL_IN_CHARGING = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double airConditioningConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, airConditioningConsumption, tankCapacity)
        {
        }

        public override void Refuel(double fuel)
        {
            base.Refuel(fuel);
            this.FuelQuantity -= (1 - TAKEN_FUEL_IN_CHARGING) * fuel;
        }
    }
}