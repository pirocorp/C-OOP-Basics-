namespace DecoratorPattern
{
    public class PlainPizza : Pizza
    {
        private static readonly decimal BASE_PRICE = 4.0m;

        public override string GetDescription()
        {
            return "Thin Dough";
        }

        public override decimal GetPrice()
        {
            return BASE_PRICE;
        }
    }
}
