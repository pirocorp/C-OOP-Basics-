using P08_MilitaryElite.Solders.Interfaces;

namespace P08_MilitaryElite
{
    public abstract class Soldier : ISoldier
    {
        private int id;
        private string firstname;
        private string lastname;

        protected Soldier(int id, string firstname, string lastname)
        {
            this.Id = id;
            this.Firstname = firstname;
            this.Lastname = lastname;
        }

        public int Id
        {
            get => this.id;
            private set => this.id = value;
        }

        public string Firstname
        {
            get => this.firstname;
            private set
            {
                Validator.ValidateString(value, nameof(Firstname));
                this.firstname = value;
            }
        }

        public string Lastname
        {
            get => this.lastname;
            private set
            {
                Validator.ValidateString(value, nameof(Lastname));
                this.lastname = value;
            }
        }

        public override string ToString()
        {
            return $"Name: {this.Firstname} {this.Lastname} Id: {this.Id}";
        }
    }
}