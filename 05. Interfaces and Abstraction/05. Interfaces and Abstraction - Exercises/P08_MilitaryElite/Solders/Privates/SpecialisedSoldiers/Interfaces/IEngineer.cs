using System.Collections.Generic;

namespace P08_MilitaryElite.Solders.Privates.SpecialisedSoldiers.Interfaces
{
    public interface IEngineer
    {
        IReadOnlyCollection<Repair> Repairs { get; }
        string ToString();
    }
}
