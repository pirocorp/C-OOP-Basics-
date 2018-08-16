public class FireBender : Bender
{
    public FireBender(string name, int power, double heatAggression) 
        : base(name, power)
    {
        this.HeatAggression = heatAggression;
    }

    public double HeatAggression { get; private set; }

    public override double TotalPower => this.Power * this.HeatAggression;

    public override string ToString()
    {
        return $"Fire Bender: {base.ToString()}, Heat Aggression: {this.HeatAggression:F2}";
    }
}