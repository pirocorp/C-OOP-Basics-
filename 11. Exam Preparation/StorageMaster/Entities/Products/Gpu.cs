namespace StorageMaster.Entities.Products
{
    public class Gpu : Product
    {
        private const double GPU_WEIGHT = 0.7;
        private const string NAME = "Gpu";

        public Gpu(double price)
            : base(price, GPU_WEIGHT, NAME)
        {
        }
    }
}