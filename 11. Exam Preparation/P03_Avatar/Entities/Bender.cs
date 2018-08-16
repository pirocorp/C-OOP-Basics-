public abstract class Bender
{
    protected Bender(string name, int power)
    {
        this.Name = name;
        this.Power = power;
    }

    public string Name { get; private set; }
    public int Power { get; private set; }

    public abstract double TotalPower { get; }

    public override string ToString()
    {
        return $"{this.Name}, Power: {this.Power}";
    }
}