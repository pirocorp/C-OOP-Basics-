using System;

public abstract class Provider : Unit
{
    private const double MAX_ENERGY_OUTPUT = 10000;
    private double energyOutput;

    protected Provider(string id, double energyOutput) 
        : base(id)
    {
        this.EnergyOutput = energyOutput;
    }

    public double EnergyOutput
    {
        get => this.energyOutput;
        protected set
        {
            Validator.EnergyOutput(value, nameof(this.EnergyOutput), MAX_ENERGY_OUTPUT);
            this.energyOutput = value;
        }
    }

    public override string ToString()
    {
        return $"Provider - {this.Id}";
    }

    public override string Check()
    {
        return this.ToString() + Environment.NewLine +
               $"Energy Output: {this.EnergyOutput}";
    }
}