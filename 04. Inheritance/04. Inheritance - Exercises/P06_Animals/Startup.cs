using System;
using System.Collections.Generic;

public class Startup
{
    public static void Main()
    {
        var animals = new List<Animal>();

        var animalType = string.Empty;

        while ((animalType = Console.ReadLine()) != "Beast!")
        {
            try
            {
                ReadAndCreateAnimal(animalType, animals);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        animals.ForEach(Console.Write);
    }

    private static void ReadAndCreateAnimal(string animalType, List<Animal> animals)
    {
        var tokens = Console.ReadLine().Split();

        var name = tokens[0];
        var age = int.Parse(tokens[1]);
        string gender = null;

        if (tokens.Length == 3)
        {
            gender = tokens[2];
        }

        switch (animalType)
        {
            case "Cat":
                var cat = new Cat(name, age, gender);
                animals.Add(cat);
                break;
            case "Dog":
                var dog = new Dog(name, age, gender);
                animals.Add(dog);
                break;
            case "Frog":
                var frog = new Frog(name, age, gender);
                animals.Add(frog);
                break;
            case "Tomcat":
                var tomcat = new Tomcat(name, age);
                animals.Add(tomcat);
                break;
            case "Kitten":
                var kitten = new Kitten(name, age);
                animals.Add(kitten);
                break;
            default:
                throw new ArgumentException("Invalid input!");
        }
    }
}