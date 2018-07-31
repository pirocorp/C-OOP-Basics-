using System;
using System.Linq;

public class Student : Human
{
    private const int MIN_LENGTH_FACULTY_NUMBER = 5;
    private const int MAX_LENGTH_FACULTY_NUMBER = 10;

    private string facultyNumber;

    public Student(string firstName, string lastName, string facultyNumber)
        : base(firstName, lastName)
    {
        this.FacultyNumber = facultyNumber;
    }

    public string FacultyNumber
    {
        get => this.facultyNumber;
        private set
        {
            if (value == null || 
                value.Length < MIN_LENGTH_FACULTY_NUMBER || 
                value.Length > MAX_LENGTH_FACULTY_NUMBER || 
                !value.ToCharArray().All(char.IsLetterOrDigit))
            {
                throw new ArgumentException($"Invalid faculty number!");
            }

            this.facultyNumber = value;
        }
    }

    public override string ToString()
    {
        return base.ToString() +
               $"Faculty number: {this.FacultyNumber}" + Environment.NewLine;
    }

    public static Student Parse(string inputLine)
    {
        var tokens = inputLine.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

        var firstName = tokens[0];
        var lastName = tokens[1];
        var facultyNumber = tokens[2];

        return new Student(firstName, lastName, facultyNumber);
    }
}