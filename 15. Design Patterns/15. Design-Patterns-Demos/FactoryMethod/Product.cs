namespace FactoryMethod
{
    public abstract class Product
    {
        protected Product(string description)
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
