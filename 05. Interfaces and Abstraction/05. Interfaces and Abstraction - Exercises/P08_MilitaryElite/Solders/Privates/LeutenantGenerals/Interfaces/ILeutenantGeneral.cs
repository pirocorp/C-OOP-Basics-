using System.Collections.Generic;

namespace P08_MilitaryElite.Solders.Privates.Interfaces
{
    public interface ILeutenantGeneral
    {
        IReadOnlyCollection<Private> Privates { get; }
    }
}
