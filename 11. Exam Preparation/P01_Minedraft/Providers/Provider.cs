using System;

public abstract class Provider : IProvider
{
    private const double MAX_ENERGY_OUTPUT = 10000;
    private string id;
    private double energyOutput;

    protected Provider(string id, double energyOutput)
    {
        this.id = id;
        this.EnergyOutput = energyOutput;
    }

    public string Id
    {
        get => this.id;
        protected set => this.id = value;
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

    public string Check()
    {
        return this.ToString() + Environment.NewLine +
               $"Energy Output: {this.EnergyOutput}";
    }
}