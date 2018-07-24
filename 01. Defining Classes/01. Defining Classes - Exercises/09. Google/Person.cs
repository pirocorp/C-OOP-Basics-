using System;

namespace Google
{
    using System.Collections.Generic;

    public class Person
    {
        public Person(string name) : this(name, null, new List<Pokemon>(), new List<Parent>(), new List<Child>(), null)
        {
        }

        private Person(string name, Company company, List<Pokemon> pokemons, List<Parent> parents, List<Child> children, Car car)
        {
            this.name = name;
            this.company = company;
            this.pokemons = pokemons;
            this.parents = parents;
            this.children = children;
            this.car = car;
        }

        private string name;
        private Company company;
        private List<Pokemon> pokemons;
        private List<Parent> parents;
        private List<Child> children;
        private Car car;
        
        public string Name
        {
            get => name;
            set => name = value;
        }

        public Company Company
        {
            get => company;
            set => company = value;
        }
        
        public List<Pokemon> Pokemons
        {
            get => pokemons;
            set => pokemons = value;
        }

        public List<Parent> Parents
        {
            get => parents;
            set => parents = value;
        }

        public List<Child> Children
        {
            get => children;
            set => children = value;
        }

        public Car Car
        {
            get => car;
            set => car = value;
        }

        public override string ToString()
        {
            return $"{this.Name}" + Environment.NewLine + 
                   $"Company:" + Environment.NewLine +
                   $"{this.Company}" +
                   $"Car:" + Environment.NewLine +
                   $"{this.Car}" +
                   $"Pokemon:" + Environment.NewLine +
                   $"{string.Join("", this.Pokemons)}" +
                   $"Parents:" + Environment.NewLine +
                   $"{string.Join("", this.Parents)}" +
                   $"Children:" + Environment.NewLine +
                   $"{string.Join("", this.Children)}";
        }
    }
}
