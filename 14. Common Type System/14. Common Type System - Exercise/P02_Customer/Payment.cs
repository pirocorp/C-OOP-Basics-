namespace P02_Customer
{
    using System;
    public class Payment : ICloneable
    {
        private string name;
        private decimal price;

        public Payment(string name, decimal price)
        {
            this.ProductName = name;
            this.Price = price;
        }
        
        public string ProductName
        {
            get => this.name;
            private set
            {
                Validator.EmptyString(nameof(this.ProductName), value);
                this.name = value;
            }
        }

        public decimal Price
        {
            get => this.price;
            private set
            {
                Validator.NegativeValue(nameof(this.Price), value);
                this.price = value;
            }
        }


        object ICloneable.Clone()
        {
            return this.Clone();
        }

        public Payment Clone()
        {
            var clone = new Payment(this.ProductName, this.Price);
            return clone;
        }

        public override string ToString()
        {
            return $"Product: {this.ProductName.PadRight(20)} {string.Format($"{this.Price:F2}").PadLeft(8)}";
        }
    }
}