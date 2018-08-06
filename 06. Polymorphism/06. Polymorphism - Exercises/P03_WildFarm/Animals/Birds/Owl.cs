namespace P03_WildFarm.Animals.Birds
{
    using System;
    using Foods;

    public class Owl : Bird
    {
        private const double WEIGHT_INCREASE_FOR_PIECE_OF_FOOD = 0.25;

        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override void EatFood(Food inputFood)
        {
            var foodType = inputFood.GetType().Name;

            if (foodType == "Meat")
            {
                var weightIncrease = inputFood.Quantity * WEIGHT_INCREASE_FOR_PIECE_OF_FOOD;
                this.Weight += weightIncrease;
                this.FoodEaten += inputFood.Quantity;
            }
            else
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {inputFood.GetType().Name}!");
            }
        }

        public override string ProducingSound()
        {
            return $"Hoot Hoot";
        }
    }
}