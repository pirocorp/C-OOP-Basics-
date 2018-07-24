namespace Google
{
    using System;

    public class Car
    {
        public Car(string carModel, int carSpeed)
        {
            this.carModel = carModel;
            this.carSpeed = carSpeed;
        }

        private string carModel;
        private int carSpeed;
        
        public string CarModel
        {
            get => carModel;
            set => carModel = value;
        }

        public int CarSpeed
        {
            get => carSpeed;
            set => carSpeed = value;
        }

        public static Car Parse(string input)
        {
            var tokens = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            return Parse(tokens);
        }

        public static Car Parse(string[] input)
        {
            var carModel = input[0];
            var carSpeed = int.Parse(input[1]);

            return new Car(carModel, carSpeed);
        }

        public override string ToString()
        {
            return $"{this.CarModel} {this.CarSpeed}" + Environment.NewLine;
        }
    }
}
