using System;

public class ParentTest
{
    protected string name;
    protected decimal money;

    public string Name
    {
        get => this.name;
        protected set
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException($"{nameof(Name)} cannot be empty");
            }

            this.name = value;
        }
    }

    public decimal Money
    {
        get => this.money;
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException($"{nameof(Money)} cannot be negative");
            }

            this.money = value;
        }
    }

    protected ParentTest(string name, decimal money)
    {
        this.Name = name;
        this.Money = money;
    }

    protected static ParentTest Parse(string inputLine)
    {
        var initializationDataTokens = inputLine.Split(new[] { "=" }, StringSplitOptions.RemoveEmptyEntries);

        var currentName = initializationDataTokens[0];
        var personInitialMOney = decimal.Parse(initializationDataTokens[1]);

        var currentItem = new ParentTest(currentName, personInitialMOney);

        return currentItem;
    }
}