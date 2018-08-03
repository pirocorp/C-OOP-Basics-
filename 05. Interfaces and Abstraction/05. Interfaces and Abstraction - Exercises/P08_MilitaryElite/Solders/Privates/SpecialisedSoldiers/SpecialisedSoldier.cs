namespace P08_MilitaryElite
{
    using System;
    using Enums;
    using Solders.Privates.Interfaces;

    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private Corps corps;

        protected SpecialisedSoldier(int id, string firstname, string lastname, decimal salary, Corps corps) 
            : base(id, firstname, lastname, salary)
        {
            this.corps = corps;
        }

        public Corps Corps
        {
            get => this.corps;
            protected set => this.corps = value;
        }

        public override string ToString()
        {
            return $"{base.ToString()}" + Environment.NewLine + 
                   $"Corps: {this.Corps.ToString()}";
        }
    }
}