namespace StorageMaster.Entities.Vehicles
{
    public class Van : Vehicle
    {
        private const int VAN_CAPACITY = 2;

        public Van()
            : base(VAN_CAPACITY)
        {
        }
    }
}