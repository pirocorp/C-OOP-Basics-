namespace P03_WildFarm.Foods
{
    public abstract class Food
    {
        private int quantity;

        protected Food(int quantity)
        {
            this.quantity = quantity;
        }

        public int Quantity
        {
            get => this.quantity;
            protected set => this.quantity = value;
        }
    }
}