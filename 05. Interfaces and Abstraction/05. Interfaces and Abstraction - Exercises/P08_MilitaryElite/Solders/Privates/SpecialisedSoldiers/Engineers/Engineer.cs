using System;
using System.Collections.Generic;
using System.Linq;
using P08_MilitaryElite.Enums;
using P08_MilitaryElite.Solders.Privates.SpecialisedSoldiers.Interfaces;

namespace P08_MilitaryElite
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private List<Repair> repairs;

        public Engineer(int id, string firstname, string lastname, decimal salary, Corps corps, List<Repair> repairs) 
            : base(id, firstname, lastname, salary, corps)
        {
            this.repairs = repairs;
        }

        public Engineer(int id, string firstname, string lastname, decimal salary, Corps corps)
            : base(id, firstname, lastname, salary, corps)
        {
            repairs = new List<Repair>();
        }

        public IReadOnlyCollection<Repair> Repairs
        {
            get => this.repairs;
        }

        public override string ToString()
        {
            var result = Repairs
                .Select(x => x.ToString())
                .Select(x => $"  {x}")
                .ToArray();

            if (result.Length == 0)
            {
                return $"{base.ToString()}" + Environment.NewLine +
                       "Repairs:";
            }

            return $"{base.ToString()}" + Environment.NewLine + 
                    "Repairs:" + Environment.NewLine + 
                   $"{string.Join(Environment.NewLine, result)}";
        }
    }
}
