namespace StorageMaster.Entities.Products
{
    public class HardDrive : Product
    {
        private const double HARD_DRIVE_WEIGHT = 1.0;
        private const string NAME = "HardDrive";

        public HardDrive(double price)
            : base(price, HARD_DRIVE_WEIGHT, NAME)
        {
        }
    }
}