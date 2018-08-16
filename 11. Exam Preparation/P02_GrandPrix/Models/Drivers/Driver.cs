public abstract class Driver
{
    private const double BOX_TIME = 20;

    protected Driver(string name, Car car, double fuelConsumptionPerKm)
    {
        this.Name = name;
        this.Car = car;
        this.FuelConsumptionPerKm = fuelConsumptionPerKm;
        this.TotalTime = 0;
        this.IsRacing = true;
    }

    public string Name { get;}

    public double TotalTime { get; set; }

    public Car Car { get; }

    public double FuelConsumptionPerKm { get; }

    public virtual double Speed => (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;

    public string FailureReason { get; set; }

    public bool IsRacing { get; private set; }

    private string Status => this.IsRacing ? $"{this.TotalTime:F3}" : $"{this.FailureReason}";

    private void Box()
    {
        this.TotalTime += BOX_TIME;
    }

    public void Refuel(string[] methodArgs)
    {
        this.Box();

        var fuelAmount = double.Parse(methodArgs[0]);

        this.Car.Refuel(fuelAmount);
    }

    public void ChangeTyres(Tyre tyre)
    {
        this.Box();

        this.Car.ChangeTyres(tyre);
    }
    
    public void CompleteLap(int trackLength)
    {
        this.TotalTime += 60 / (trackLength / this.Speed);

        this.Car.CompleteLap(trackLength, this.FuelConsumptionPerKm);
    }

    public void Fail(string reason)
    {
        this.IsRacing = false;
        this.FailureReason = reason;
    }

    public override string ToString()
    {
        return $"{this.Name} {this.Status}";
    }
}