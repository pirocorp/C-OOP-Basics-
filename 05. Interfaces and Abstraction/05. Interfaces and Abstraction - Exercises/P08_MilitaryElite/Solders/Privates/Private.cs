﻿namespace P08_MilitaryElite
{
    using Solders.Privates.Interfaces;

    public class Private : Soldier, IPrivate
    {
        private decimal salary;

        public Private(int id, string firstname, string lastname, decimal salary) 
            : base(id, firstname, lastname)
        {
            this.Salary = salary;
        }

        public decimal Salary
        {
            get => this.salary;
            protected set
            {
                Validator.ValidateSalary(value, nameof(this.Salary));
                this.salary = value;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()} Salary: {this.Salary:F2}";
        }
    }
}
