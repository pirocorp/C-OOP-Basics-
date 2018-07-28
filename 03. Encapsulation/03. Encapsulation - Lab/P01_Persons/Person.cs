using System;

public class Person
{
    private const int NameMinLenght = 3;
    private const decimal MinimalSalary = 460;

    private string firstName;
    private string lastName;
    private int age;
    private decimal salary;

    public string FirstName
    {
        get => this.firstName;
        private set
        {
            ValidateFieldLenght(value, nameof(FirstName));
            firstName = value;
        }
    }

    public string LastName
    {
        get => this.lastName;
        private set
        {
            ValidateFieldLenght(value, nameof(LastName));
            lastName = value;
        }
    }

    public int Age
    {
        get => age;

        private set
        {
            if (value < 0 || value > 120)
            {
                throw new ArgumentException($"{nameof(Age)} cannot be less than 0 or more than 120");
            }

            age = value;
        }
    }

    public decimal Salary
    {
        get => salary;

        private set
        {
            if (value < MinimalSalary)
            {
                throw new ArgumentException($"{nameof(Salary)} cannot be less than {MinimalSalary:F2}");
            }

            salary = value;
        }
    }

    public Person(string firstName, string lastName, int age, decimal salary)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
        this.Salary = salary;
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
}