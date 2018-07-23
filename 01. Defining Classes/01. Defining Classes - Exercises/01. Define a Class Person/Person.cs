public class Person
{
    public Person():this(1)
    {
    }

    public Person(int age):this("No name", age)
    {
    }

    public Person(string name, int age)
    {
        this.name = name;
        this.age = age;
    }

    private string name;
    private int age;

    public string Name
    {
        get => this.name;
        set => this.name = value;
    }

    public int Age
    {
        get => this.age;
        set => this.age = value;
    }

    public override string ToString()
    {
        //return $"Name: {this.Name}, Age: {this.Age}";
        return $"{this.Name} {this.Age}";
    }
}
