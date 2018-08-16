using System.Collections.Generic;
using System.Linq;

public class Nation
{
    private List<Bender> benders;
    private List<Monument> monuments;
    private bool nationIsAtWar;

    public Nation()
    {
        this.benders = new List<Bender>();
        this.monuments = new List<Monument>();
    }

    private double GetAllBendersPower => this.benders.Sum(x => x.TotalPower);

    public IReadOnlyCollection<Bender> Benders => this.benders;

    public IReadOnlyCollection<Monument> Monuments => this.monuments;

    public double TotalPower()
    {
        var totalPower = this.GetAllBendersPower;

        var monumentsAffinity = this.monuments.Sum(x => x.GetAffinity);
        var monumentsPowerIncrease = (totalPower / 100) * monumentsAffinity;
        totalPower += monumentsPowerIncrease;

        return totalPower;
    }

    public void AddBender(Bender newBender)
    {
        this.benders.Add(newBender);
    }

    public void AddMonument(Monument newMonument)
    {
        this.monuments.Add(newMonument);
    }

    public void Defeated()
    {
        this.benders = new List<Bender>();
        this.monuments = new List<Monument>();
    }
}