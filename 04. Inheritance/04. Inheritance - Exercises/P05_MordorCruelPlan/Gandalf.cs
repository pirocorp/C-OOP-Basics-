using System;
using System.ComponentModel.DataAnnotations;

public class Gandalf
{
    private int happinessPoints;

    public Gandalf()
    {
        happinessPoints = 0;
    }

    public int HppinessPoints => this.happinessPoints;

    public Mood Mood()
    {
        if (happinessPoints < -5)
        {
            return global::Mood.Angry;
        }
        else if (happinessPoints <= 0)
        {
            return global::Mood.Sad;
        }
        else if (happinessPoints < 15)
        {
            return global::Mood.Happy;
        }
        else
        {
            return global::Mood.JavaScript;
        }
    }

    public void Eat(string input)
    {
        if (input == null)
        {
            return;
        }

        var foodInput = input.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

        foreach (var food in foodInput)
        {
            var parsed = Enum.TryParse<FoodType>(food, true, out var currentFood);

            if (parsed)
            {
                happinessPoints += (int) currentFood;
            }
            else
            {
                happinessPoints += (int) FoodType.EverythingElse;
            }
        }
    }
}