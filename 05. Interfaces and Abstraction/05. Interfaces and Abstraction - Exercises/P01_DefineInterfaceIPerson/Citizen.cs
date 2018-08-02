public class Citizen : IPerson, IBirthable, IIdentifiable
{
    private string name;
    private int age;
    private string birthdate;
    private string id;

    public Citizen(string name, int age, string id, string birthdate)
    {
        this.Name = name;
        this.Age = age;
        this.Birthdate = birthdate;
        this.Id = id;
    }

    public string Name
    {
        get => this.name;
        set
        {
            Validator.ValidateString(value, nameof(Name));
            this.name = value;
        }
    }

    public int Age
    {
        get => this.age;
        set
        {
            Validator.ValidateAge(value, nameof(Age));
            this.age = value;
        }
    }

    public string Birthdate
    {
        get => this.birthdate;
        set
        {
            Validator.ValidateString(value, nameof(Birthdate));
            this.birthdate = value;
        }
    }

    public string Id
    {
        get => this.id;
        set
        {
            Validator.ValidateString(value, nameof(Id));
            this.id = value;
        }
    }
}