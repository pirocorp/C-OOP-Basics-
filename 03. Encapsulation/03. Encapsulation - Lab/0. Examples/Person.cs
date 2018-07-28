namespace _0._Examples
{
    using System;

    public class Person
    {
        private const int NameMinLenght = 3;
        private const decimal MinSalary = 460M;

        private string _firstName;
        private string _lastName;
        private int _age;
        private decimal _salary;

        private string FirstName
        {
            get => _firstName;

            set
            {
                ValidateFieldLenght(value, nameof(FirstName));
                _firstName = value;
            }
        }

        private string LastName
        {
            get => _lastName;

            set
            {
                ValidateFieldLenght(value, nameof(LastName));
                _lastName = value;
            }
        }

        public string Name => $"{FirstName} {LastName}";

        public int Age
        {
            get => _age;

            private set
            {
                if (value < 0 || value > 120)
                {
                    throw new ArgumentException($"{nameof(Age)} cannot be less than 0 or more than 120");
                }

                _age = value;
            }
        }

        public decimal Salary
        {
            get => _salary;

            private set
            {
                if (value < MinSalary)
                {
                    throw new ArgumentException($"{nameof(Salary)} cannot be less than {MinSalary:F2}");
                }

                _salary = value;
            }
        }

        public Person(string firstName, string lastName, int age, decimal salary = 0)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }

        private static void ValidateFieldLenght(string fieldValue, string fieldName)
        {
            if (fieldValue == null)
            {
                throw new ArgumentNullException($"{fieldName}");
            }

            if (fieldValue.Length < NameMinLenght)
            {
                throw new ArgumentException($"{fieldName} cannot be less than {NameMinLenght} symbols");
            }
        }

        public void IncreaseSalary(int percent)
        {
            if (percent < 0)
            {
                throw new ArgumentException($"{nameof(percent)} cannot be negative");
            }

            var ratio = (100 + percent) / 100M;
            _salary *= ratio;
        }

        public override string ToString()
        {
            return $"{Name} {Age} - {Salary:F2}";
        }
    }
}