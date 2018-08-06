namespace P03_WildFarm.Animals.Mammals
{
    using System;
    using Foods;

    public class Mouse : Mammal
    {
        private const double WEIGHT_INCREASE_FOR_PIECE_OF_FOOD = 0.10;

        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }
        
        public override void EatFood(Food inputFood)
        {
            var foodType = inputFood.GetType().Name;

            if (foodType == "Vegetable" || foodType == "Fruit")
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
            return $"Squeak";
        }
    }
}