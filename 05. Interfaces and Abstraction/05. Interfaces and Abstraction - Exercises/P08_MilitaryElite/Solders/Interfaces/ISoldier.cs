namespace P08_MilitaryElite.Solders.Interfaces
{
    public interface ISoldier
    {
        int Id { get; }
        string Firstname { get; }
        string Lastname { get; }
        string ToString();
    }
}
