using System.Collections.Generic;

public class Person : ParentTest
{
    private List<Product> bagOfProducts;

    public IReadOnlyCollection<Product> Bag => bagOfProducts.AsReadOnly();

    public Person(string name, decimal money) : base(name, money)
    {
        this.bagOfProducts = new List<Product>();
    }

    public string BuyItem(Product product)
    {
        var pricOfProduct = product.Money;

        if (pricOfProduct > this.Money)
        {
            return $"{this.name} can\'t afford {product.Name}";
        }

        bagOfProducts.Add(product);
        this.Money -= pricOfProduct;
        return $"{this.Name} bought {product.Name}";
    }

    public static Person ParsePerson(string inputLine)
    {
        var item = Parse(inputLine);

        return new Person(item.Name, item.Money);
    }
}