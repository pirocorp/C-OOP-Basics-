namespace WallStreet
{
    /// <summary>
    /// The 'ConcreteSubject' class
    /// </summary>
    public class IBM : Stock
    {
        private const string SYMBOL = "IBM";

        public IBM(double price)
            : base(SYMBOL, price)
        {
        }
    }
}
