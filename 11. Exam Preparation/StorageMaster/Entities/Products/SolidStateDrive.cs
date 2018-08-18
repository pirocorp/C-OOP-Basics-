namespace StorageMaster.Entities.Products
{
    public class SolidStateDrive : Product
    {
        private const double SOLID_STATE_DRIVE_WEIGHT = 0.2;
        private const string NAME = "SolidStateDrive";

        public SolidStateDrive(double price)
            : base(price, SOLID_STATE_DRIVE_WEIGHT, NAME)
        {
        }
    }
}