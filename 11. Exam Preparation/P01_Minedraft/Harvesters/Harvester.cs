using System;

public abstract class Harvester : IHarvester
{
    private const double MAX_ENERGY_REQUIREMENT = 20000;
    private string id;
    private double oreOutput;
    private double energyRequirement;

    protected Harvester(string id, double oreOutput, double energyRequirement)
    {
        this.Id = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public string Id
    {
        get => this.id;
        protected set => this.id = value;
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

    public string Check()
    {
        return this.ToString() + Environment.NewLine +
               $"Ore Output: {this.OreOutput}" + Environment.NewLine +
               $"Energy Requirement: {this.EnergyRequirement}";
    }
}