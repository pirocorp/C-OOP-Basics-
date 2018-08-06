namespace P03_WildFarm
{
    using System;
    using System.Collections.Generic;
    using Animals;
    using Animals.Birds;
    using Animals.Mammals;
    using Animals.Mammals.Felines;
    using Foods;

    public class Startup
    {
        public static void Main()
        {
            var animals = new List<Animal>();

            string inputAnimalData;

            while ((inputAnimalData = Console.ReadLine()) != "End")
            {
                var inputFoodData = Console.ReadLine();

                var currentAnimal = AnimalFactory(inputAnimalData);
                Console.WriteLine(currentAnimal.ProducingSound());

                var currentFood = FoodFactory(inputFoodData);

                try
                {
                    currentAnimal.EatFood(currentFood);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }

                animals.Add(currentAnimal);
            }

            animals.ForEach(Console.WriteLine);
        }

        private static Food FoodFactory(string inputFoodData)
        {
            var tokens = inputFoodData.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

            var foodType = tokens[0];
            var foodQuantaty = int.Parse(tokens[1]);

            switch (foodType)
            {
                case "Fruit":
                    return new Fruit(foodQuantaty);
                case "Vegetable":
                    return new Vegetable(foodQuantaty);
                case "Meat":
                    return new Meat(foodQuantaty);
                case "Seeds":
                    return new Seeds(foodQuantaty);
                default:
                    throw new NotSupportedException();
            }
        }

        private static Animal AnimalFactory(string inputLine)
        {
            var tokens = inputLine.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

            var animalType = tokens[0];
            var name = tokens[1];
            var weight = double.Parse(tokens[2]);

            switch (animalType)
            {
                case "Cat":
                    var livingRegion = tokens[3];
                    var breed = tokens[4];
                    return new Cat(name, weight, livingRegion, breed);
                case "Tiger":
                    livingRegion = tokens[3];
                    breed = tokens[4];
                    return new Tiger(name, weight, livingRegion, breed);
                case "Owl":
                    var wingSize = double.Parse(tokens[3]);
                    return new Owl(name, weight, wingSize);
                case "Hen":
                    wingSize = double.Parse(tokens[3]);
                    return new Hen(name, weight, wingSize);
                case "Mouse":
                    livingRegion = tokens[3];
                    return new Mouse(name, weight, livingRegion);
                case "Dog":
                    livingRegion = tokens[3];
                    return new Dog(name, weight, livingRegion);
                default:
                    throw new NotSupportedException();
            }
        }
    }
}