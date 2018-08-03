namespace P08_MilitaryElite
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Solders.Privates.Interfaces;

    public class LeutenantGeneral : Private, ILeutenantGeneral
    {
        private List<Private> privates;

        public LeutenantGeneral(int id, string firstname, string lastname, decimal salary, List<Private> inputList)
            : base(id, firstname, lastname, salary)
        {
            this.privates = inputList;
        }

        public LeutenantGeneral(int id, string firstname, string lastname, decimal salary) 
            : base(id, firstname, lastname, salary)
        {
            privates = new List<Private>();
        }

        public IReadOnlyCollection<Private> Privates
        {
            get => this.privates;
        }

        public override string ToString()
        {
            if (privates.Count == 0)
            {
                return $"{base.ToString()}" + Environment.NewLine +
                       $"Privates:";
            }

            return $"{base.ToString()}" + Environment.NewLine + 
                   $"Privates:" + Environment.NewLine +
                   $"{string.Join(Environment.NewLine, Privates.Select(x => $"  {x}"))}";
        }
    }
}
