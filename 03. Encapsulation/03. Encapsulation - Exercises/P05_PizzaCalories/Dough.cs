using System;

public class Dough
{
    private const int BaseCaloriesPerGram = 2;

    private int weightInGrams;
    private FlourType flourType;
    private BakingTechnique bakingTechnique;

    public int WeightInGrams
    {
        get => this.weightInGrams;
        private set
        {
            if (value <= 0 || value > 200)
            {
                throw new ArgumentException($"Dough weight should be in the range [1..200].");
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
        var baseCalories = BaseCaloriesPerGram * WeightInGrams;
        var totalCalories = baseCalories * ((int) bakingTechnique / 10.0) * ((int) flourType / 10.0);
        return totalCalories;
    }
}