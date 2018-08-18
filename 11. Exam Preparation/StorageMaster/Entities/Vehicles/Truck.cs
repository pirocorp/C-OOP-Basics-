namespace StorageMaster.Entities.Vehicles
{
    public class Truck : Vehicle
    {
        private const int TRUCK_CAPACITY = 5;

        public Truck()
            : base(TRUCK_CAPACITY)
        {
        }
    }
}