using System;

public class Worker : Human
{
    private const int WORKING_DAYS_PER_WEEK = 5;
    private const int MIN_WEEKLY_SALARY = 10;
    private const int MIN_WORKING_HOURS = 1;
    private const int MAX_WORKING_HOURS = 12;

    private double weekSalary;
    private double workHoursPerDay;

    public Worker(string firstName, string lastName, double weekSalary, double workHoursPerDay)
        : base(firstName, lastName)
    {
        this.WeekSalary = weekSalary;
        this.WorkHoursPerDay = workHoursPerDay;
    }

    public double WeekSalary
    {
        get => this.weekSalary;
        private set
        {
            if (value <= MIN_WEEKLY_SALARY)
            {
                throw new ArgumentException($"Expected value mismatch! Argument: {nameof(weekSalary)}");
            }

            this.weekSalary = value;
        }
    }

    public double WorkHoursPerDay
    {
        get => this.workHoursPerDay;
        private set
        {
            if (value < MIN_WORKING_HOURS || value > MAX_WORKING_HOURS)
            {
                throw new ArgumentException($"Expected value mismatch! Argument: {nameof(workHoursPerDay)}");
            }

            this.workHoursPerDay = value;
        }
    }

    public override string ToString()
    {
        var salaryByHour = WeekSalary / (WORKING_DAYS_PER_WEEK * WorkHoursPerDay);

        return base.ToString() +
               $"Week Salary: {this.WeekSalary:F2}" + Environment.NewLine +
               $"Hours per day: {this.WorkHoursPerDay:F2}" + Environment.NewLine +
               $"Salary per hour: {salaryByHour:F2}" + Environment.NewLine;
    }

    public static Worker Parse(string inputLine)
    {
        var tokens = inputLine.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

        var firstName = tokens[0];
        var lastName = tokens[1];
        var weekSalary = double.Parse(tokens[2]);
        var workHoursPerDay = double.Parse(tokens[3]);

        return new Worker(firstName, lastName, weekSalary, workHoursPerDay);
    }
}