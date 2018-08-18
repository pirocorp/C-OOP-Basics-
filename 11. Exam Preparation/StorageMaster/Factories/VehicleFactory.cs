namespace StorageMaster.Factories
{
    using Entities;
    using Entities.Vehicles;
    using System;
    using Utilities;

    public class VehicleFactory
    {
        public Vehicle CreateVehicle(string type)
        {
            Vehicle newVehicle = null;

            switch (type)
            {
                case "Semi":
                    newVehicle = new Semi();
                    break;

                case "Truck":
                    newVehicle = new Truck();
                    break;

                case "Van":
                    newVehicle = new Van();
                    break;

                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidVehicleType);
            }

            return newVehicle;
        }
    }
}