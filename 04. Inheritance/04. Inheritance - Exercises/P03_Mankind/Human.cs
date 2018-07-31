using System;

public class Human
{
    private string firstName;
    private string lastName;

    public Human(string firstName, string lastName)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
    }

    public string FirstName
    {
        get => this.firstName;
        protected set
        {
            ValidateName(value, nameof(firstName));
            this.firstName = value;
        }
    }

    public string LastName
    {
        get => this.lastName;
        protected set
        {
            ValidateName(value, nameof(lastName));
            this.lastName = value;
        }
    }

    private static void ValidateName(string value, string nameOfArgument)
    {
        var valueLength = 4;

        if (nameOfArgument == "lastName")
        {
            valueLength = 3;
        }

        if (value == null || value.Length < valueLength)
        {
            throw new ArgumentException($"Expected length at least {valueLength} symbols! Argument: {nameOfArgument}");
        }

        if (!char.IsUpper(value[0]))
        {
            throw new ArgumentException($"Expected upper case letter! Argument: {nameOfArgument}");
        }
    }

    public override string ToString()
    {
        return $"First Name: {FirstName}" + Environment.NewLine +
               $"Last Name: {LastName}" + Environment.NewLine;
    }
}