namespace P01_Vehicles.Vehicles
{
    public class Truck : Vehicle
    {
        private const double TAKEN_FUEL_IN_CHARGING = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption, double airConditioningConsumption)
            : base(fuelQuantity, fuelConsumption, airConditioningConsumption)
        {
        }

        public override void Refuel(double fuel)
        {
            fuel *= TAKEN_FUEL_IN_CHARGING;
            base.Refuel(fuel);
        }
    }
}