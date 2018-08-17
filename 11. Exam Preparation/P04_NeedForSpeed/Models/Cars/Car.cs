using System;
using System.Collections.Generic;

public abstract class Car
{
    private Stack<bool> inRace;

    protected Car(string brand, string model, int yearOfProduction, int horsePower, int acceleration, int suspension, int durability)
    {
        this.Brand = brand;
        this.Model = model;
        this.YearOfProduction = yearOfProduction;
        this.HorsePower = horsePower;
        this.Acceleration = acceleration;
        this.Suspension = suspension;
        this.Durability = durability;
        this.inRace = new Stack<bool>();
        this.inRace.Push(false);
    }

    public string Brand{ get; private set; }

    public string Model { get; private set; }

    public int YearOfProduction { get; private set; }

    public int HorsePower { get; private set; }

    public int Acceleration { get; private set; }

    public int Suspension { get; private set; }

    public int Durability { get; private set; }

    public bool InRace => this.inRace.Peek();

    public int OverallPerformance => (this.HorsePower / this.Acceleration) + (this.Suspension + this.Durability);

    public int EnginePerformance => (this.HorsePower / this.Acceleration);

    public int SuspensionPerformance => (this.Suspension + this.Durability);

    public void StartRace()
    {
        this.inRace.Push(true);
    }

    public void EndRace()
    {
        this.inRace.Pop();
    }

    public virtual void Tune(int tuneIndex, string addOn)
    {
        var horsePowerIncrease = tuneIndex;
        var suspensionIncrease = tuneIndex / 2;

        this.HorsePower += horsePowerIncrease;
        this.Suspension += suspensionIncrease;
    }

    public override string ToString()
    {
        return $"{this.Brand} {this.Model} {this.YearOfProduction}" + Environment.NewLine +
               $"{this.HorsePower} HP, 100 m/h in {this.Acceleration} s" + Environment.NewLine +
               $"{this.Suspension} Suspension force, {this.Durability} Durability";
    }
}