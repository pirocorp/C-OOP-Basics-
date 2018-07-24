namespace Google
{
    using System;

    public class Company
    {
        public Company(string companyName, string department, decimal salary)
        {
            this.companyName = companyName;
            this.department = department;
            this.salary = salary;
        }

        private string companyName;
        private string department;
        private decimal salary;

        public string CompanyName
        {
            get => companyName;
            set => companyName = value;
        }

        public string Department
        {
            get => department;
            set => department = value;
        }

        public decimal Salary
        {
            get => salary;
            set => salary = value;
        }

        public static Company Parse(string input)
        {
            var tokens = input.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

            return Parse(tokens);
        }

        public static Company Parse(string[] input)
        {
            var companyName = input[0];
            var department = input[1];
            var salary = decimal.Parse(input[2]);

            return new Company(companyName, department, salary);
        }

        public override string ToString()
        {
            return $"{this.CompanyName} {this.Department} {this.Salary:F2}" + Environment.NewLine;
        }
    }
}
