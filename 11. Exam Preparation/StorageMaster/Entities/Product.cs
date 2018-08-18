namespace StorageMaster.Entities
{
    using Utilities;

    public abstract class Product
    {
        private double price;
        private string name;

        protected Product(double price, double weight, string name)
        {
            this.Price = price;
            this.Weight = weight;
            this.Name = name;
        }

        public double Price
        {
            get => this.price;
            private set
            {
                Validator.ValidatePrice(value);
                this.price = value;
            }
        }

        public string Name { get; private set; }

        public double Weight { get; private set; }
    }
}