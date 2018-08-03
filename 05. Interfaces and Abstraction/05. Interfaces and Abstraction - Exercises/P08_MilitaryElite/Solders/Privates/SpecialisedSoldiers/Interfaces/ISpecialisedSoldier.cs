namespace P08_MilitaryElite.Solders.Privates.Interfaces
{
    using Enums;

    public interface ISpecialisedSoldier
    {
        Corps Corps { get; }
        string ToString();
    }
}