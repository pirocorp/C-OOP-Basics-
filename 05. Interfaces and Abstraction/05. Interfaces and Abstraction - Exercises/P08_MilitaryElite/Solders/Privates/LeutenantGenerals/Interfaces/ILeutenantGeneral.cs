namespace P08_MilitaryElite.Solders.Privates.Interfaces
{
    using System.Collections.Generic;

    public interface ILeutenantGeneral
    {
        IReadOnlyCollection<Private> Privates { get; }
    }
}
