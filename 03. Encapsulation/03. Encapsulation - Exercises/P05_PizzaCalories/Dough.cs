using System;

public class Dough
{
    private const int BASE_CALORIES_PER_GRAM = 2;
    private const int MIN_VALUE = 1;
    private const int MAX_VALUE = 200;

    private int weightInGrams;
    private FlourType flourType;
    private BakingTechnique bakingTechnique;

    public int WeightInGrams
    {
        get => this.weightInGrams;
        private set
        {
            if (value < MIN_VALUE || value > MAX_VALUE)
            {
                throw new ArgumentException($"Dough weight should be in the range [{MIN_VALUE}..{MAX_VALUE}].");
            }

            this.weightInGrams = value;
        }
    }

    public Dough(int weightInGrams, string flourType, string bakingTechnique)
    {
        this.WeightInGrams = weightInGrams;
        var validFlourType = Enum.TryParse<FlourType>(flourType, true, out this.flourType);
        var validBakingTechnique = Enum.TryParse<BakingTechnique>(bakingTechnique, true, out this.bakingTechnique);

        if (!validBakingTechnique || !validFlourType)
        {
            throw new ArgumentException("Invalid type of dough.");
        }
    }

    public double CalculateCalories()
    {
        var baseCalories = BASE_CALORIES_PER_GRAM * WeightInGrams;
        var totalCalories = baseCalories * ((int) bakingTechnique / 10.0) * ((int) flourType / 10.0);
        return totalCalories;
    }
}