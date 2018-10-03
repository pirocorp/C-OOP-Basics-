namespace FactoryMethod
{
    public class ChairCreator : ProductCreator
    {
        public override Product CreateProduct()
        {
            var chair = new Chair("A chair created by the chair creator.");
            return chair;
        }
    }
}
