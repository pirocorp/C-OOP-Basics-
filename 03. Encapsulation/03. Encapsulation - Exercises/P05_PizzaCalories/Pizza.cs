using System;
using System.Collections.Generic;
using System.Linq;

public class Pizza
{
    private string name;
    private Dough dough;
    private List<Topping> toppings;

    public string Name
    {
        get => this.name;
        private set
        {
            if (value == null || value.Length <= 0 || value.Length > 15)
            {
                throw new ArgumentException($"Pizza name should be between 1 and 15 symbols.");
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
        if (NumberOftoppings >= 10)
        {
            throw new ArgumentException($"Number of toppings should be in range [0..10].");
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