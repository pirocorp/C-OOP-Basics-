using System;
using System.Collections.Generic;

public class Team
{
    private string name;
    private List<Person> firstTeam;
    private List<Person> reserveTeam;

    public IReadOnlyCollection<Person> FirstTeam => firstTeam.AsReadOnly();

    public IReadOnlyCollection<Person> ReserveTeam => reserveTeam.AsReadOnly();

    public Team(string name)
    {
        ValidateFieldNotNull(name, nameof(name));
        this.name = name;
        this.firstTeam = new List<Person>();
        this.reserveTeam = new List<Person>();
    }

    private static void ValidateFieldNotNull(object fieldValue, string fieldName)
    {
        if (fieldValue == null)
        {
            throw new ArgumentNullException($"{fieldName}");
        }
    }

    public void AddPlayer(Person person)
    {
        ValidateFieldNotNull(person, nameof(person));

        if (person.Age < 40)
        {
            firstTeam.Add(person);
        }
        else
        {
            reserveTeam.Add(person);
        }
    }

    public override string ToString()
    {
        return $"{this.name}:{Environment.NewLine}{nameof(FirstTeam)}:{Environment.NewLine}{string.Join(Environment.NewLine, FirstTeam)}{Environment.NewLine}{nameof(ReserveTeam)}:{Environment.NewLine}{string.Join(Environment.NewLine, ReserveTeam)}";
    }
}