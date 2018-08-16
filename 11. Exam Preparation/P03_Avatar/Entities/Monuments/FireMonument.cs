public class FireMonument : Monument
{
    public FireMonument(string name, int fireAffinity) 
        : base(name)
    {
        this.FireAffinity = fireAffinity;
    }

    public int FireAffinity { get; private set; }

    public override int GetAffinity => this.FireAffinity;

    public override string ToString()
    {
        return $"Fire {base.ToString()}, Fire Affinity: {this.FireAffinity}";
    }
}