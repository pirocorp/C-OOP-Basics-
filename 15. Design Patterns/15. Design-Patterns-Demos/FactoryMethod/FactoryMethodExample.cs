namespace FactoryMethod
{
    using System;

    class FactoryMethodExample
    {
        static void Main()
        {
            ProductCreator tableFactory = new TableCreator();
            Product table = tableFactory.CreateProduct();
            Console.WriteLine(table);

            ProductCreator chairFactory = new ChairCreator();
            Product chair = chairFactory.CreateProduct();
            Console.WriteLine(chair);
        }
    }
}
