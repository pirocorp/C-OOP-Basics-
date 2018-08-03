namespace P08_MilitaryElite.Solders.Privates.SpecialisedSoldiers.Interfaces
{
    using System.Collections.Generic;

    public interface IEngineer
    {
        IReadOnlyCollection<Repair> Repairs { get; }
        string ToString();
    }
}
