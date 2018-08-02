using System.Collections.Generic;
using P08_MilitaryElite.Solders.SpecialisedSoldiers.Commandos;

namespace P08_MilitaryElite.Solders.Privates.SpecialisedSoldiers.Interfaces
{
    public interface ICommando
    {
        IReadOnlyCollection<Mission> Missions { get; }
        string ToString();
    }
}