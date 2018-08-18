namespace StorageMaster.Entities.Storages
{
    using System.Collections.Generic;

    public class Warehouse : Storage
    {
        private const int DEFAULT_CAPACITY = 10;
        private const int DEFAULT_GARAGE_SLOTS = 10;
        private const string DEFAULT_VEHICLE_TYPE = "Semi";
        private const int DEFAULT_VEHICLE_QUANTATY = 3;

        public Warehouse(string name)
            : base(name, DEFAULT_CAPACITY, DEFAULT_GARAGE_SLOTS, InitializeVehicles())
        {
        }

        private static IEnumerable<Vehicle> InitializeVehicles()
        {
            return Vehicle.CreateVehiclesByType(DEFAULT_VEHICLE_TYPE, DEFAULT_VEHICLE_QUANTATY);
        }
    }
}