using P08_MilitaryElite.Solders.Privates.Interfaces;

namespace P08_MilitaryElite
{
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
            get => salary;
            protected set
            {
                Validator.ValidateSalary(value, nameof(Salary));
                this.salary = value;
            }
        }

        public override string ToString()
        {
            return $"{base.ToString()} Salary: {this.Salary:F2}";
        }
    }
}
