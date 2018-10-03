namespace FactoryMethod
{
    public abstract class Product
    {
        public Product(string description)
        {
            this.Description = description;
        }

        public string Description { get; set; }

        public override string ToString()
        {
            return this.Description;
        }
    }
}
