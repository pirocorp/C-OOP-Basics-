using P05_BorderControl.Interfaces;

namespace P05_BorderControl
{
    public class Citizen : IInhabitants
    {
        private string name;
        private int age;
        private string id;

        public Citizen(string name, int age, string id)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
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
    }
}