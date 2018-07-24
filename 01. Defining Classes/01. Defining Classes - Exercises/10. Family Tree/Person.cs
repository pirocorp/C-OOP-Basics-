namespace _10._Family_Tree
{
    using System.Collections.Generic;

    public class Person
    {
        public Person(string name, Birthdate birthDate):this(name, birthDate, new List<Person>(), new List<Person>())
        {
        }

        public Person(Birthdate birthDate):this(null, birthDate, new List<Person>(), new List<Person>())
        {
        }

        public Person(string name):this(name, null, new List<Person>(), new List<Person>())
        {
        }

        public Person(string name, Birthdate birthDate, List<Person> parents, List<Person> children)
        {
            this.name = name;
            this.birthDate = birthDate;
            this.parents = parents;
            this.children = children;
        }

        private string name;
        private Birthdate birthDate;
        private List<Person> parents;
        private List<Person> children;
        
        public string Name
        {
            get => name;
            set => name = value;
        }

        public Birthdate BirthDate
        {
            get => birthDate;
            set => birthDate = value;
        }

        public List<Person> Parents
        {
            get => parents;
            set => parents = value;
        }
        
        public List<Person> Children
        {
            get => children;
            set => children = value;
        }

        public override string ToString()
        {
            return $"{this.Name} {this.BirthDate}";
        }
    }
}
