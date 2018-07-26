namespace _01._Raw_Data
{
    using System;

    public class Engine
    {
        private int engineSpeed;
        private int enginePower;

        public int EngineSpeed => engineSpeed;
        public int EnginePower => enginePower;

        public Engine(int engineSpeed, int enginePower)
        {
            this.engineSpeed = engineSpeed;
            this.enginePower = enginePower;
        }

        public static Engine Parse(string inputLine)
        {
            var tokens = inputLine.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            return Parse(tokens);
        }

        public static Engine Parse(string[] input)
        {
            var EngineSpeed = int.Parse(input[0]);
            var EnginePower = int.Parse(input[1]);

            return new Engine(EngineSpeed, EnginePower);
        }

        public override string ToString()
        {
            return $"{engineSpeed} {enginePower}";
        }
    }
}