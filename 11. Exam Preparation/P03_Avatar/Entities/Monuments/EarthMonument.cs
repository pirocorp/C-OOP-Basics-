public class EarthMonument : Monument
{
    public EarthMonument(string name, int earthAffinity) 
        : base(name)
    {
        this.EarthAffinity = earthAffinity;
    }

    public int EarthAffinity { get; private set; }

    public override int GetAffinity => this.EarthAffinity;

    public override string ToString()
    {
        return $"Earth {base.ToString()}, Earth Affinity: {this.EarthAffinity}";
    }
}