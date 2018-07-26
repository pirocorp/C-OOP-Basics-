namespace _01._Raw_Data
{
    using System;

    public class Tire
    {
        private double pressure;
        private int age;

        public double Pressure => pressure;
        public int Age => age;

        public Tire(double pressure, int age)
        {
            this.pressure = pressure;
            this.age = age;
        }

        public static Tire Parse(string inputLine)
        {
            var tokens = inputLine.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

            return Parse(tokens);
        }

        public static Tire Parse(string[] input)
        {
            var pressure = double.Parse(input[0]);
            var age = int.Parse(input[1]);

            return new Tire(pressure, age);
        }

        public override string ToString()
        {
            return $"{pressure} {age}";
        }
    }
}