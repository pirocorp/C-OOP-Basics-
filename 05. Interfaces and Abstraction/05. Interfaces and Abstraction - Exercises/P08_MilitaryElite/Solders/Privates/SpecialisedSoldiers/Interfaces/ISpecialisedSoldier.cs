using P08_MilitaryElite.Enums;

namespace P08_MilitaryElite.Solders.Privates.Interfaces
{
    public interface ISpecialisedSoldier
    {
        Corps Corps { get; }
        string ToString();
    }
}