using System;

public class Topping
{
    private const int BASE_CALORIES_PER_GRAM = 2;
    private const int MIN_VALUE = 1;
    private const int MAX_VALUE = 50;

    private int weightInGrams;
    private TypeOfTopping typeOfTopping;

    public int WeightInGrams
    {
        get => this.weightInGrams;
        private set
        {
            if (value < MIN_VALUE || value > MAX_VALUE)
            {
                throw new ArgumentException($"{TypeOfTopping} weight should be in the range [{MIN_VALUE}..{MAX_VALUE}].");
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
        var baseCalories = BASE_CALORIES_PER_GRAM * WeightInGrams;
        var totalCalories = baseCalories * ((int)typeOfTopping / 10.0);
        return totalCalories;
    }
}