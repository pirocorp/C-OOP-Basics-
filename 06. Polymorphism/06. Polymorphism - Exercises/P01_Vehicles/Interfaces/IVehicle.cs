namespace P01_Vehicles.Interfaces
{
    public interface IVehicle
    {
        void Refuel(double fuel);

        string Drive(double distance);

        string ToString();
    }
}