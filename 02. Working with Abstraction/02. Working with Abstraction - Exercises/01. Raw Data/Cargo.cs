namespace _01._Raw_Data
{
    using System;

    public class Cargo
    {
        private int cargoWeight;
        private string cargoType;

        public int CargoWeight => cargoWeight;
        public string CargoType => cargoType;

        public Cargo(int cargoWeight, string cargoType)
        {
            this.cargoWeight = cargoWeight;
            this.cargoType = cargoType;
        }

        public static Cargo Parse(string inputLine)
        {
            var tokens = inputLine.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            return Parse(tokens);
        }

        public static Cargo Parse(string[] input)
        {
            var cargoWeight = int.Parse(input[0]);
            var CargoType = input[1];

            return new Cargo(cargoWeight, CargoType);
        }

        public override string ToString()
        {
            return $"{cargoWeight} {cargoType}";
        }
    }
}