namespace StorageMaster.Factories
{
    using System;
    using Entities;
    using Entities.Products;
    using Utilities;

    public class ProductFactory
    {
        public Product CreateProduct(string type, double price)
        {
            Product newProduct = null;

            switch (type)
            {
                case "Gpu":
                    newProduct = new Gpu(price);
                    break;
                case "HardDrive":
                    newProduct = new HardDrive(price);
                    break;
                case "Ram":
                    newProduct = new Ram(price);
                    break;
                case "SolidStateDrive":
                    newProduct = new SolidStateDrive(price);
                    break;
                default:
                    throw new InvalidOperationException(ExceptionMessages.InvalidProductType);
            }

            return newProduct;
        }
    }
}