using System;
using System.Collections.Generic;
using System.Linq;
using P01_Minedraft.Enums;

public class DraftManager
{
    private Dictionary<string, IHarvester> harvesters;
    private Dictionary<string, IProvider> providers;
    private Dictionary<string, ICheckable> iCheckable;
    private Mode mode;
    private double totalEnergyStored;
    private double totalMinedPlumbusOre;
    private HarvesterFactory harvesterFactory;
    private ProviderFactory providerFactory;

    public DraftManager()
    {
        this.harvesters = new Dictionary<string, IHarvester>();
        this.providers = new Dictionary<string, IProvider>();
        this.iCheckable = new Dictionary<string, ICheckable>();
        this.mode = P01_Minedraft.Enums.Mode.Full;
        this.totalEnergyStored = 0;
        this.totalMinedPlumbusOre = 0;
        this.harvesterFactory = new HarvesterFactory();
        this.providerFactory = new ProviderFactory();
    }

    public string RegisterHarvester(List<string> arguments)
    {
        var id = arguments[1];

        IHarvester currentHarvester = null;

        try
        {
            currentHarvester = this.harvesterFactory.MakeHarvester(arguments);
        }
        catch (ArgumentException ae)
        {
            return $"Harvester is not registered, because of it's {ae.ParamName}";
        }
        catch (NotSupportedException nse)
        {
            return "Unknown type of harvester";
        }

        this.harvesters.Add(id, currentHarvester);
        this.iCheckable.Add(id, currentHarvester);
        return $"Successfully registered {currentHarvester.ToString()}";
    }

    public string RegisterProvider(List<string> arguments)
    {
        var id = arguments[1];

        IProvider currentProvider = null;

        try
        {
            currentProvider = this.providerFactory.MakeProvider(arguments);
        }
        catch (ArgumentException ae)
        {
            return $"Provider is not registered, because of it's {ae.ParamName}";
        }
        catch (NotSupportedException nse)
        {
            return $"Unknown type of provider";
        }

        this.providers.Add(id, currentProvider);
        this.iCheckable.Add(id, currentProvider);
        return $"Successfully registered {currentProvider.ToString()}";
    }

    public string Day()
    {
        var energyProduced = this.providers.Sum(x => x.Value.EnergyOutput);
        this.totalEnergyStored += energyProduced;

        var energyNeededToProduceOre = 0D;
        var oreProduced = 0D;

        if (this.mode == P01_Minedraft.Enums.Mode.Full)
        {
            energyNeededToProduceOre = this.harvesters.Sum(x => x.Value.EnergyRequirement);

            if (energyNeededToProduceOre <= this.totalEnergyStored)
            {
                oreProduced = this.harvesters.Sum(x => x.Value.OreOutput);

                this.totalEnergyStored -= energyNeededToProduceOre;
                this.totalMinedPlumbusOre += oreProduced;
            }
        }

        if (this.mode == P01_Minedraft.Enums.Mode.Half)
        {
            energyNeededToProduceOre = this.harvesters.Sum(x => x.Value.EnergyRequirement) * 0.6;

            if (energyNeededToProduceOre <= this.totalEnergyStored)
            {
                oreProduced = this.harvesters.Sum(x => x.Value.OreOutput) * 0.5;

                this.totalEnergyStored -= energyNeededToProduceOre;
                this.totalMinedPlumbusOre += oreProduced;
            }
        }

        return $"A day has passed." + Environment.NewLine +
               $"Energy Provided: {energyProduced}" + Environment.NewLine +
               $"Plumbus Ore Mined: {oreProduced}";
    }

    public string Mode(List<string> arguments)
    {
        var modeAsString = arguments[0];

        var isParsed = Enum.TryParse<Mode>(modeAsString, out var parsedMode);

        if (isParsed)
        {
            this.mode = parsedMode;
            return $"Successfully changed working mode to {this.mode} Mode";
        }

        return $"Unknown mode";
    }

    public string Check(List<string> arguments)
    {
        var result = string.Empty;
        var id = arguments[0];

        if (this.iCheckable.ContainsKey(id))
        {
            return this.iCheckable[id].Check();
        }

        return $"No element found with id - {id}";
    }

    public string ShutDown()
    {
        return $"System Shutdown" + Environment.NewLine +
               $"Total Energy Stored: {this.totalEnergyStored}" + Environment.NewLine +
               $"Total Mined Plumbus Ore: {this.totalMinedPlumbusOre}";

    }
}