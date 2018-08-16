using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NationsBuilder
{
    private BenderFactory benderFactory;
    private MonumentFactory monumentFactory;
    private Dictionary<string, Nation> nations;
    private List<string> warsList;

    public NationsBuilder()
    {
        this.benderFactory = new BenderFactory();
        this.monumentFactory = new MonumentFactory();
        this.nations = new Dictionary<string, Nation>();
        this.warsList = new List<string>();
    }

    public void AssignBender(List<string> benderArgs)
    {
        var type = benderArgs[0];

        var currentBender = this.benderFactory.CreateBender(benderArgs);

        var currentNation = this.ReturnCurrentNation(type);

        currentNation.AddBender(currentBender);
    }

    public void AssignMonument(List<string> monumentArgs)
    {
        var type = monumentArgs[0];

        var currentMonument = this.monumentFactory.CreateMonument(monumentArgs);

        var currentNation = this.ReturnCurrentNation(type);

        currentNation.AddMonument(currentMonument);
    }

    public string GetStatus(string nationsType)
    {
        var currentNation = this.nations[nationsType];
        var stringBuilder = new StringBuilder();

        var benders = currentNation.Benders;
        var monuments = currentNation.Monuments;

        stringBuilder.AppendLine($"{nationsType} Nation");
        stringBuilder.Append($"Benders:");

        AppendCollection(benders, stringBuilder);

        stringBuilder.Append($"Monuments:");

        AppendCollection(monuments, stringBuilder);

        return stringBuilder.ToString().TrimEnd();
    }

    private static void AppendCollection<T>(IReadOnlyCollection<T> benders, StringBuilder stringBuilder)
    {
        if (benders.Count != 0)
        {
            stringBuilder.AppendLine();

            foreach (var bender in benders)
            {
                stringBuilder.AppendLine($"###{bender}");
            }
        }
        else
        {
            stringBuilder.Append($" None");
            stringBuilder.AppendLine();
        }
    }

    public void IssueWar(string nationsType)
    {
        var losers = this.nations
            .OrderByDescending(x => x.Value.TotalPower())
            .Skip(1)
            .Select(x => x.Value)
            .ToArray();

        foreach (var nation in losers)
        {
            nation.Defeated();
        }

        this.warsList.Add(nationsType);
    }

    public string GetWarsRecord()
    {
        var stringBuilder = new StringBuilder();

        var warIndex = 1;

        foreach (var nation in this.warsList)
        {
            stringBuilder.AppendLine($"War {warIndex++} issued by {nation}");
        }

        return stringBuilder.ToString().TrimEnd();
    }

    private Nation ReturnCurrentNation(string type)
    {
        if (!this.nations.ContainsKey(type))
        {
            var newNation = new Nation();
            this.nations[type] = newNation;
        }

        var currentNation = this.nations[type];
        return currentNation;
    }
}