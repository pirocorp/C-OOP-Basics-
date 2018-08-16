public class WaterMonument : Monument
{
    public WaterMonument(string name, int waterAffinity) 
        : base(name)
    {
        this.WaterAffinity = waterAffinity;
    }

    public int WaterAffinity  { get; private set; }

    public override int GetAffinity => this.WaterAffinity;

    public override string ToString()
    {
        return $"Water {base.ToString()}, Water Affinity: {this.WaterAffinity}";
    }
}