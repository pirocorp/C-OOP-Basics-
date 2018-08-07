public class Person
{
    private static int instanceCounter = 0;

    public Person(string name = null)
    {
        instanceCounter++;
        this.Name = name;
    }

    public static int PersonCounter
    {
        get
        {
            return instanceCounter;
        }
    }

    public string Name { get; set; }
}