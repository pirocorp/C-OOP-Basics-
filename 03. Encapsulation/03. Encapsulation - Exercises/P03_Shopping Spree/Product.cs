public class Product : ParentTest
{
    public Product(string name, decimal cost):base(name, cost)
    {
    }

    public static Product ParseProduct(string inputLine)
    {
        var item = Parse(inputLine);
        
        return new Product(item.Name, item.Money);
    }

    public override string ToString()
    {
        return $"{this.Name}";
    }
}