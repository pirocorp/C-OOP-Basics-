using System;
using System.Collections.Generic;
using System.Linq;
using P08_MilitaryElite.Enums;
using P08_MilitaryElite.Solders.Privates.SpecialisedSoldiers.Interfaces;

namespace P08_MilitaryElite.Solders.SpecialisedSoldiers.Commandos
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        private List<Mission> missions;

        public Commando(int id, string firstname, string lastname, decimal salary, Corps corps, List<Mission> missions) 
            : base(id, firstname, lastname, salary, corps)
        {
            this.missions = missions;
        }

        public Commando(int id, string firstname, string lastname, decimal salary, Corps corps) 
            : base(id, firstname, lastname, salary, corps)
        {
            this.missions = new List<Mission>();
        }

        public IReadOnlyCollection<Mission> Missions => this.missions;

        public override string ToString()
        {
            var result = this.Missions
                .Select(x => x.ToString())
                .Select(x => $"  {x}")
                .ToArray();

            if (result.Length == 0)
            {
                return $"{base.ToString()}" + Environment.NewLine +
                       $"Missions:";
            }

            return $"{base.ToString()}" + Environment.NewLine + 
                   $"Missions:" + Environment.NewLine + 
                   $"{string.Join(Environment.NewLine, result)}";
        }
    }
}