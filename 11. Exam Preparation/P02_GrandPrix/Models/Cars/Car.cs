using System;

public class Car
{
    private const double MAX_FUEL = 160;
    private double fuelAmount;

    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.Hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp { get;}

    public double FuelAmount
    {
        get => this.fuelAmount;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Out of fuel");
            }

            this.fuelAmount = Math.Min(value, MAX_FUEL);
        }
    }

    public Tyre Tyre { get; private set; }

    public void Refuel(double fuel)
    {
        this.FuelAmount += fuel;
    }

    public void ChangeTyres(Tyre newTyre)
    {
        this.Tyre = newTyre;
    }

    public void CompleteLap(int trackLength, double fuelConsumption)
    {
        this.FuelAmount -= trackLength * fuelConsumption;

        this.Tyre.CompleteLap();
    }
}