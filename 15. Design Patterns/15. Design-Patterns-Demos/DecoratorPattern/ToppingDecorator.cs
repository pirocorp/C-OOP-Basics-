namespace DecoratorPattern
{
    public class BasePizzaDecorator : Pizza
    {
        protected Pizza basePizza;

        public BasePizzaDecorator(Pizza pizza)
        {
            basePizza = pizza;
        }

        public override string GetDescription()
        {
            return basePizza.GetDescription();
        }

        public override decimal GetPrice()
        {
            return basePizza.GetPrice();
        }
    }
}