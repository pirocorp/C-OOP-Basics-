public interface IHarvester : ICheckable
{
    double OreOutput { get; }
    double EnergyRequirement { get; }
    string ToString();
}