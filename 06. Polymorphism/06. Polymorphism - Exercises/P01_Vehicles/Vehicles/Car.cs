﻿namespace P01_Vehicles.Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption, double airConditioningConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, airConditioningConsumption, tankCapacity)
        {
        }
    }
}