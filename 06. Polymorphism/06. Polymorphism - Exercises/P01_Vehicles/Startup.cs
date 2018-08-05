namespace P01_Vehicles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Interfaces;
    using Vehicles;

    public class Startup
    {
        private const double CAR_AIR_COND_CONSUMPTION = 0.9;
        private const double TRUCK_AIR_COND_CONSUMPTION = 1.6;

        public static void Main()
        {
            var vehicles = new Dictionary<string, IVehicle>();

            for (var i = 0; i < 2; i++)
            {
                var currentVehicle = VehicleFactory(Console.ReadLine());
                var vehicleType = currentVehicle.GetType().Name;
                vehicles[vehicleType] = currentVehicle;
            }

            var numberOfCommands = int.Parse(Console.ReadLine());

            for (var i = 0; i < numberOfCommands; i++)
            {
                var command = Console.ReadLine().Split();
                var action = command[0];
                var vehicleType = command[1];
                var value = double.Parse(command[2]);

                switch (action)
                {
                    case "Drive":
                        Console.WriteLine(vehicles[vehicleType].Drive(value));
                        break;
                    case "Refuel":
                        vehicles[vehicleType].Refuel(value);
                        break;
                }
            }

            vehicles.ToList().ForEach(x => Console.WriteLine(x.Value));
        }

        private static IVehicle VehicleFactory(string readLine)
        {
            var vehicleDetails = readLine.Split();
            var vehicleType = vehicleDetails[0];

            switch (vehicleType)
            {
                case "Car":
                    return new Car(double.Parse(vehicleDetails[1]), double.Parse(vehicleDetails[2]), CAR_AIR_COND_CONSUMPTION); ;
                case "Truck":
                    return new Truck(double.Parse(vehicleDetails[1]), double.Parse(vehicleDetails[2]), TRUCK_AIR_COND_CONSUMPTION);
                default:
                    throw new NotSupportedException();
            }
        }
    }
}