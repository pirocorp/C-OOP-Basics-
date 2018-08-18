namespace StorageMaster.Entities.Products
{
    public class Ram : Product
    {
        private const double RAM_WEIGHT = 0.1;
        private const string NAME = "Ram";

        public Ram(double price)
            : base(price, RAM_WEIGHT, NAME)
        {
        }
    }
}