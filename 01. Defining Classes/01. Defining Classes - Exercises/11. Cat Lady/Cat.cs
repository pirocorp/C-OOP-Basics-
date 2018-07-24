namespace _11._Cat_Lady
{
    using System;

    public class Cat
    {
        public Cat(string breed, string name, decimal specificCharacteristic)
        {
            this.breed = breed;
            this.name = name;
            this.specificCharacteristic = specificCharacteristic;
        }

        private string breed;
        private string name;
        private decimal specificCharacteristic;
        
        public string Breed
        {
            get => breed;
            set => breed = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public decimal SpecificCharacteristic
        {
            get => specificCharacteristic;
            set => specificCharacteristic = value;
        }

        public static Cat Parse(string inputLine)
        {
            var tokens = inputLine.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

            return Parse(tokens);
        }

        public static Cat Parse(string[] input)
        {
            var breed = input[0];
            var name = input[1];
            var specificCharacteristic = decimal.Parse(input[2]);

            return new Cat(breed, name, specificCharacteristic);
        }

        public override string ToString()
        {
            var specificCharacteristicString =
                breed == "Cymric" ? $"{this.specificCharacteristic:F2}" : $"{this.specificCharacteristic}";
            return $"{this.breed} {this.name} {specificCharacteristicString}";
        }
    }
}
