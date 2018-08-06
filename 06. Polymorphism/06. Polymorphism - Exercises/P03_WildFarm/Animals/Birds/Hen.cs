namespace P03_WildFarm.Animals.Birds
{
    using Foods;

    public class Hen : Bird
    {
        private const double WEIGHT_INCREASE_FOR_PIECE_OF_FOOD = 0.35;

        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        public override void EatFood(Food inputFood)
        {
            var weightIncrease = inputFood.Quantity * WEIGHT_INCREASE_FOR_PIECE_OF_FOOD;
            this.Weight += weightIncrease;
            this.FoodEaten += inputFood.Quantity;
        }

        public override string ProducingSound()
        {
            return $"Cluck";
        }
    }
}