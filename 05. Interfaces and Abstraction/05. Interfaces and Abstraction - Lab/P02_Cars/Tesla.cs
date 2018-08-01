public class Tesla : Car, IElectricCar
{
    private int battery;

    public int Battery
    {
        get => battery;
        protected set
        {
            Validator.ValidateBatteryCount(value, nameof(Battery));
            battery = value;
        }
    }

    public Tesla(string model, string color, int battery) 
        : base(model, color)
    {
        this.Battery = battery;
    }

    public override string ToString()
    {
        return $"{base.ToString()} with {this.Battery} Batteries";
    }
}