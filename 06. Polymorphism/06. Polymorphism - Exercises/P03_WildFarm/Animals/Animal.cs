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

        public string Name
        {
            get => this.name;
            protected set => this.name = value;
        }

        public double Weight
        {
            get => this.weight;
            protected set => this.weight = value;
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