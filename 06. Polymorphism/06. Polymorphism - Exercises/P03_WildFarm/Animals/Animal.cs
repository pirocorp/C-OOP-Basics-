namespace P03_WildFarm.Animals
{
    using Foods;

    public abstract class Animal
    {
        private string name;
        private double weight;
        private int foodEaten;

        protected Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }

        protected string Name
        {
            get => this.name;
            set => this.name = value;
        }

        protected double Weight
        {
            get => this.weight;
            set => this.weight = value;
        }

        protected int FoodEaten
        {
            get => this.foodEaten;
            set => this.foodEaten = value;
        }

        public abstract void EatFood(Food inputFood);

        public abstract string ProducingSound();
    }
}