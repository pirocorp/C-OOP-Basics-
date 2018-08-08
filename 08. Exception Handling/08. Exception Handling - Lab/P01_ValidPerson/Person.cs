namespace P01_ValidPerson
{
    public class Person
    {
        private string firstname;
        private string lastname;
        private int age;

        public Person(string firstname, string lastname, int age)
        {
            this.Firstname = firstname;
            this.Lastname = lastname;
            this.Age = age;
        }

        public string Firstname
        {
            get => this.firstname;
            private set
            {
                Validator.StringIsNullOrEmpty(value, nameof(this.Firstname));
                this.firstname = value;
            }
        }

        public string Lastname
        {
            get => this.lastname;
            private set
            {
                Validator.StringIsNullOrEmpty(value, nameof(this.Lastname));
                this.lastname = value;
            }
        }

        public int Age
        {
            get => this.age;
            private set
            {
                Validator.ValidateAge(value, nameof(this.Age));
                this.age = value;
            }
        }
    }
}