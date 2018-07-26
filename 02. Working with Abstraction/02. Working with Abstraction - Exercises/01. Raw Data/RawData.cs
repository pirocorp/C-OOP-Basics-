namespace _01._Raw_Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RawData
    {
        public static void Main()
        {
            var cars = new List<Car>();
            var lines = int.Parse(Console.ReadLine());

            for (var i = 0; i < lines; i++)
            {
                var currentCar = Car.Parse(Console.ReadLine());
                cars.Add(currentCar);
            }

            var command = Console.ReadLine();

            if (command == "fragile")
            {
                var fragile = cars
                    .Where(x => x.Cargo.CargoType == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }
            else
            {
                var flamable = cars
                    .Where(x => x.Cargo.CargoType == "flamable" && x.Engine.EnginePower > 250)
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }
    }
}