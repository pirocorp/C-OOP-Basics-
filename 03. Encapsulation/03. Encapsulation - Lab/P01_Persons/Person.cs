    public class Person
    {
        private string firstName;
        private string lastName;
        private int age;
        private decimal salary;

        public string FirstName => this.firstName;
        public int Age => this.age;

        public Person(string firstName, string lastName, int age, decimal salary)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
            this.salary = salary;
        }

        public override string ToString()
        {
            return $"{this.FirstName} {this.lastName} receives {this.salary:F2} leva.";
        }

        public void IncreaseSalary(decimal percentage)
        {
            var ratio = percentage / 100;
            var rise = this.salary * ratio;

            if (this.Age < 30)
            {
                rise = rise / 2;
            }

            this.salary += rise;
        }
    }