using System;

public abstract class Harvester : Unit
{
    private const double MAX_ENERGY_REQUIREMENT = 20000;
    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement)
        : base(id)
    {
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public double OreOutput
    {
        get => this.oreOutput;
        protected set
        {
            Validator.NotNegativeNumber(value, nameof(this.OreOutput));
            this.oreOutput = value;
        }
    }

    public double EnergyRequirement
    {
        get => this.energyRequirement;
        protected set
        {
            Validator.EnergyRequirement(value, nameof(this.EnergyRequirement), MAX_ENERGY_REQUIREMENT);
            this.energyRequirement = value;
        }
    }

    public override string ToString()
    {
        return $"Harvester - {this.Id}";
    }

    public override string Check()
    {
        return this.ToString() + Environment.NewLine +
               $"Ore Output: {this.OreOutput}" + Environment.NewLine +
               $"Energy Requirement: {this.EnergyRequirement}";
    }
}