public interface IProvider : ICheckable
{
    double EnergyOutput { get; }
    string ToString();
}