namespace P08_MilitaryElite
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Enums;
    using Solders.Privates.SpecialisedSoldiers.Interfaces;

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
            this.repairs = new List<Repair>();
        }

        public IReadOnlyCollection<Repair> Repairs
        {
            get => this.repairs;
        }

        public override string ToString()
        {
            var result = this.Repairs
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
