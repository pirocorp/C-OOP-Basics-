using P05_BorderControl.Interfaces;

namespace P05_BorderControl
{
    public class Citizen : IInhabitants, IBornable
    {
        private string name;
        private int age;
        private string id;
        private string birthdate;

        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
        }

        public string Name
        {
            get => name;
            private set
            {
                //Validator.ValidateString(value, nameof(Name));
                name = value;
            }
        }

        public int Age
        {
            get => age;
            private set
            {
                //Validator.ValidateAge(value, nameof(Age));
                age = value;
            }
        }

        public string Id
        {
            get => id;
            private set
            {
                //Validator.ValidateString(value, nameof(Id));
                id = value;
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
    }
}