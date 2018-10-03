namespace FactoryMethod
{
    public class TableCreator : ProductCreator
    {
        public override Product CreateProduct()
        {
            var table = new Table("A table created by the table creator.");
            return table;
        }
    }
}
