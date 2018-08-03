namespace P08_MilitaryElite.Solders.Privates.SpecialisedSoldiers.Interfaces
{
    using System.Collections.Generic;
    using Solders.SpecialisedSoldiers.Commandos;

    public interface ICommando
    {
        IReadOnlyCollection<Mission> Missions { get; }
        string ToString();
    }
}