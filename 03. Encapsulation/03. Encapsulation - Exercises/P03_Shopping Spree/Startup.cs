using System;
using System.Collections.Generic;
using System.Linq;

public class Startup
{
    public static void Main()
    {
        Dictionary<string, Person> persons = null;
        Dictionary<string, Product> products = null;

        try
        {
            persons = Console.ReadLine()
                .Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(Person.ParsePerson)
                .Where(x => x != null)
                .ToDictionary(x => x.Name, x => x);

            products = Console.ReadLine()
                .Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries)
                .Select(Product.ParseProduct)
                .Where(x => x != null)
                .ToDictionary(x => x.Name, x => x);
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
            return;
        }

        //persons = Console.ReadLine()
        //    .Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries)
        //    .Select(x => {
        //        try
        //        {
        //            return Person.ParsePerson(x);
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e.Message);
        //        }

        //        return null;
        //    })
        //    .Where(x => x != null)
        //    .ToDictionary(x => x.Name, x => x);

        //products = Console.ReadLine()
        //    .Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries)
        //    .Select(x =>
        //    {
        //        try
        //        {
        //            return Product.ParseProduct(x);
        //        }
        //        catch (Exception e)
        //        {
        //            Console.WriteLine(e.Message);
        //        }

        //        return null;
        //    })
        //    .Where(x => x != null)
        //    .ToDictionary(x => x.Name, x => x);

        var inputLine = string.Empty;

        while ((inputLine = Console.ReadLine()) != "END")
        {
            var tokens = inputLine.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

            var currentPersonString = tokens[0];
            var currentProductString = tokens[1];

            if (persons != null && products != null && persons.ContainsKey(currentPersonString) && products.ContainsKey(currentProductString))
            {
                Console.WriteLine(persons[currentPersonString].BuyItem(products[currentProductString]));
            }
        }

        foreach (var person in persons)
        {
            var currentPerson = person.Value;

            if (currentPerson.Bag.Count > 0)
            {
                Console.WriteLine($"{currentPerson.Name} - {string.Join(", ", currentPerson.Bag)}");
            }
            else
            {
                Console.WriteLine($"{currentPerson.Name} - Nothing bought");
            }
        }
    }
}