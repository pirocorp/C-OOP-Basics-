using System;

public class Animal : ISoundProducable
{
    private string name;
    private int age;
    private string gender;

    public Animal(string name, int age, string gender)
    {
        this.Name = name;
        this.Age = age;
        this.Gender = gender;
    }

    public string Name
    {
        get => this.name;
        set
        {
            ValidateStrings(value, nameof(Name));
            this.name = value;
        }
    }

    public int Age
    {
        get => this.age;
        set
        {
            if (value < 0)
            {
                throw new ArgumentException($"Invalid input!");
            }

            this.age = value;
        }
    }

    public string Gender
    {
        get => this.gender;
        set
        {
            ValidateStrings(value, nameof(Gender));
            this.gender = value;
        }
    }

    private static void ValidateStrings(string value, string nameOfProperty)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"Invalid input!");
        }
    }

    public virtual string ProduceSound()
    {
        return $"Animal";
    }

    public override string ToString()
    {
        return $"{this.GetType().Name}" + Environment.NewLine +
               $"{this.Name} {this.Age} {this.Gender}" + Environment.NewLine +
               $"{ProduceSound()}" + Environment.NewLine;
    }
}