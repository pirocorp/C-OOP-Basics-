namespace StorageMaster.Entities.Vehicles
{
    public class Semi : Vehicle
    {
        private const int SEMI_CAPACITY = 10;

        public Semi()
            : base(SEMI_CAPACITY)
        {
        }
    }
}