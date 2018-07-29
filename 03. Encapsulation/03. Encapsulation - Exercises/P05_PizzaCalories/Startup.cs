using System;
using System.Linq;

public class Startup
{
    static void Main()
    {
        var newPizza = PizzaParser();

        if (newPizza != null)
        {
            Console.WriteLine($"{newPizza.Name} - {newPizza.TotalCalories():F2} Calories.");
        }
    }

    private static Pizza PizzaParser()
    {
        try
        {
            var pizzaName = Console.ReadLine()
                .Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .FirstOrDefault();

            var newPizza = new Pizza(pizzaName);

            var doughTokens = Console.ReadLine().Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

            var flourType = doughTokens[1];
            var bakingTechnique = doughTokens[2];
            var weightInGrams = int.Parse(doughTokens[3]);

            var pizzaDough = new Dough(weightInGrams, flourType, bakingTechnique);
            newPizza.Dough = pizzaDough;

            var toppingInput = string.Empty;

            while ((toppingInput = Console.ReadLine()) != "END")
            {
                var toppingTokens = toppingInput.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);
                var toppingName = toppingTokens[1];
                var toppingWeight = int.Parse(toppingTokens[2]);

                var currentTopping = new Topping(toppingWeight, toppingName);
                newPizza.AddTopping(currentTopping);
            }

            return newPizza;
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }
}