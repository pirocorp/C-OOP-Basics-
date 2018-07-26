namespace _01._Raw_Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tire[] tires;

        public string Model => model;
        public Engine Engine => engine;
        public Cargo Cargo => cargo;
        public Tire[] Tires => tires;

        public Car(string model, Engine engine, Cargo cargo, Tire[] tires)
        {
            this.model = model;
            this.engine = engine;
            this.cargo = cargo;
            this.tires = tires;
        }

        public static Car Parse(string inputLine)
        {
            var tokens = inputLine.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            return Parse(tokens);
        }

        public static Car Parse(string[] input)
        {
            //<Model> <EngineSpeed> <EnginePower> <CargoWeight> <CargoType> <Tire1Pressure> <Tire1Age> <Tire2Pressure> <Tire2Age> <Tire3Pressure> <Tire3Age> <Tire4Pressure> <Tire4Age>
            var model = input[0];
            var engine = Engine.Parse(input.Skip(1).Take(2).ToArray());
            var cargo = Cargo.Parse(input.Skip(3).Take(2).ToArray());

            var tiresData = input.Skip(5).ToArray();
            var tires = new Tire[4];

            for (var i = 0; i < 4; i++)
            {
                var currentTireData = tiresData.Skip(2 * i).Take(2).ToArray();
                var curretnTire = Tire.Parse(currentTireData);
                tires[i] = curretnTire;
            }

            return new Car(model, engine, cargo, tires);
        }

        public override string ToString()
        {
            return $"{Model} {Engine} {Cargo} {Tires}";
        }
    }
}