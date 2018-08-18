namespace StorageMaster.Entities.Storages
{
    using System.Collections.Generic;

    public class AutomatedWarehouse : Storage
    {
        private const int DEFAULT_CAPACITY = 1;
        private const int DEFAULT_GARAGE_SLOTS = 2;
        private const string DEFAULT_VEHICLE_TYPE = "Truck";
        private const int DEFAULT_VEHICLE_QUANTATY = 1;

        public AutomatedWarehouse(string name)
            : base(name, DEFAULT_CAPACITY, DEFAULT_GARAGE_SLOTS, InitializeVehicles())
        {
        }

        private static IEnumerable<Vehicle> InitializeVehicles()
        {
            return Vehicle.CreateVehiclesByType(DEFAULT_VEHICLE_TYPE, DEFAULT_VEHICLE_QUANTATY);
        }
    }
}