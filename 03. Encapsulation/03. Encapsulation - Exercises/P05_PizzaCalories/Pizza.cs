using System;
using System.Collections.Generic;
using System.Linq;

public class Pizza
{
    private const int NAME_MIN_LENGTH = 1;
    private const int NAME_MAX_LENGTH = 15;
    private const int MIN_NUMBER_OF_TOPPINGS = 0;
    private const int MAX_NUMBER_OF_TOPPINGS = 10;

    private string name;
    private Dough dough;
    private List<Topping> toppings;

    public string Name
    {
        get => this.name;
        private set
        {
            if (value == null || value.Length < NAME_MIN_LENGTH || value.Length > NAME_MAX_LENGTH)
            {
                throw new ArgumentException($"Pizza name should be between {NAME_MIN_LENGTH} and {NAME_MAX_LENGTH} symbols.");
            }

            this.name = value;
        }
    }

    public int NumberOftoppings => toppings.Count;

    public Dough Dough
    {
        get => this.dough;
        set
        {
            if (value == null)
            {
                throw new ArgumentNullException($"{nameof(Dough)} cannot be null");
            }

            this.dough = value;
        }
    }

    public Pizza(string name)
    {
        this.Name = name;
        this.toppings = new List<Topping>();
    }

    public void AddTopping(Topping newTopping)
    {
        if (NumberOftoppings >= MAX_NUMBER_OF_TOPPINGS)
        {
            throw new ArgumentException($"Number of toppings should be in range [{MIN_NUMBER_OF_TOPPINGS}..{MAX_NUMBER_OF_TOPPINGS}].");
        }

        toppings.Add(newTopping);
    }

    public double TotalCalories()
    {
        var doughCalories = this.dough.CalculateCalories();
        var topingCalories = toppings.Select(x => x.CalculateCalories()).Sum();

        return doughCalories + topingCalories;
    }
}