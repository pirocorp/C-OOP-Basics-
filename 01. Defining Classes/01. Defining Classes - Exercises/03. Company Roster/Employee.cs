namespace _03._Company_Roster
{
    using System;

    public class Employee
    {
        public Employee(string name, decimal salary, string position, string department)
        : this(name, salary, position, department, "n/a")
        {
        }

        public Employee(string name, decimal salary, string position, string department, string email)
            : this(name, salary, position, department, email, -1)
        {
        }

        public Employee(string name, decimal salary, string position, string department, string email, int age)
        {
            Name = name;
            Salary = salary;
            Position = position;
            Department = department;
            Email = email;
            Age = age;
        }

        private string name;
        private decimal salary;
        private string position;
        private string department;
        private string email;
        private int age;

        public string Name
        {
            get => name;
            set => name = value;
        }

        public decimal Salary
        {
            get => salary;
            set => salary = value;
        }

        public string Position
        {
            get => position;
            set => position = value;
        }

        public string Department
        {
            get => department;
            set => department = value;
        }

        public string Email
        {
            get => email;
            set => email = value;
        }

        public int Age
        {
            get => age;
            set => age = value;
        }

        public static Employee Parse(string input)
        {
            var email = "n/a";
            var age = -1;
            var personData = input
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            if (personData.Length > 4)
            {
                int parsed;
                var isdigit = int.TryParse(personData[4], out parsed);

                if (isdigit)
                {
                    age = parsed;
                }
                else
                {
                    email = personData[4];
                }

                if (personData.Length > 5)
                {
                    if (isdigit)
                    {
                        email = personData[5];
                    }
                    else
                    {
                        age = int.Parse(personData[5]);
                    }
                }
            }

            return new Employee(personData[0], decimal.Parse(personData[1]), personData[2], personData[3], email, age);
        }
    }
}
