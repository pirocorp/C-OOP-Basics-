using System;

public class Topping
{
    private const int BaseCaloriesPerGram = 2;

    private int weightInGrams;
    private TypeOfTopping typeOfTopping;

    public int WeightInGrams
    {
        get => this.weightInGrams;
        private set
        {
            if (value <= 0 || value > 50)
            {
                throw new ArgumentException($"{TypeOfTopping} weight should be in the range [1..50].");
            }

            this.weightInGrams = value;
        }
    }

    private string TypeOfTopping
    {
        get => Enum.GetName(typeof(TypeOfTopping), this.typeOfTopping);
        set
        {
            var validTypeOfTopping = Enum.TryParse<TypeOfTopping>(value, true, out this.typeOfTopping);

            if (!validTypeOfTopping)
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
        }
    }

    public Topping(int weightInGrams, string typeOfTopping)
    {
        this.TypeOfTopping = typeOfTopping;
        this.WeightInGrams = weightInGrams;
    }

    public double CalculateCalories()
    {
        var baseCalories = BaseCaloriesPerGram * WeightInGrams;
        var totalCalories = baseCalories * ((int)typeOfTopping / 10.0);
        return totalCalories;
    }
}