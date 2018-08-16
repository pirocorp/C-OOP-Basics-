public class AirMonument : Monument
{
    public AirMonument(string name, int airAffinity) 
        : base(name)
    {
        this.AirAffinity = airAffinity;
    }

    public int AirAffinity  { get; private set; }

    public override int GetAffinity => this.AirAffinity;

    public override string ToString()
    {
        return $"Air {base.ToString()}, Air Affinity: {this.AirAffinity}";
    }
}