using System;

namespace DecoratorPattern
{
    public class TomatoSaucePizza : BasePizzaDecorator
    {
        public TomatoSaucePizza(Pizza pizza)
            : base(pizza)
        {
            Console.WriteLine("Adding Tomato sauce");
        }

        public override string GetDescription()
        {
            return basePizza.GetDescription() + " + Tomato Sauce";
        }

        public override decimal GetPrice()
        {
            return basePizza.GetPrice() + 0.60m;
        }
    }
}
