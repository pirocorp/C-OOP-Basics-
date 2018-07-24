namespace _10._Family_Tree
{
    public class Birthdate
    {
        public Birthdate(string birthDate)
        {
            this.birthDate = birthDate;
        }

        private string birthDate;

        public string BirthDate
        {
            get => birthDate;
            set => birthDate = value;
        }

        public override string ToString()
        {
            return $"{this.BirthDate}";
        }
    }
}
