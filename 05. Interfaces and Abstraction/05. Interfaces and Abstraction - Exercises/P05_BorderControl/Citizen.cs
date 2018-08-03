namespace P05_BorderControl
{
    using Interfaces;

    public class Citizen : IInhabitants, IBornable, IBuyer
    {
        private string name;
        private int age;
        private string id;
        private string birthdate;
        private int food;

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
            this.food = 0;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                //Validator.ValidateString(value, nameof(Name));
                this.name = value;
            }
        }

        public int Age
        {
            get => this.age;
            private set
            {
                //Validator.ValidateAge(value, nameof(Age));
                this.age = value;
            }
        }

        public string Id
        {
            get => this.id;
            private set
            {
                //Validator.ValidateString(value, nameof(Id));
                this.id = value;
            }
        }

        public string Birthdate
        {
            get => this.birthdate;
            private set
            {
                this.birthdate = value;
            }
        }

        public int Food
        {
            get => this.food;
            private set => this.food = value;
        }

        public void BuyFood()
        {
            this.Food += 10;
        }
    }
}