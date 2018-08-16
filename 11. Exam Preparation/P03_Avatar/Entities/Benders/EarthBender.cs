public class EarthBender : Bender
{
    public EarthBender(string name, int power, double groundSaturation) 
        : base(name, power)
    {
        this.GroundSaturation = groundSaturation;
    }

    public double GroundSaturation { get; private set; }

    public override double TotalPower => this.Power * this.GroundSaturation;

    public override string ToString()
    {
        return $"Earth Bender: {base.ToString()}, Ground Saturation: {this.GroundSaturation:F2}";
    
    }
}