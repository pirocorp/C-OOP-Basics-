namespace P05_HTMLDispatcher
{
    public class Atribut
    {
        private string name;
        private string value;

        public Atribut(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }

        public string Name
        {
            get => this.name;
            private set
            {
                Validator.ValidateStringNullEmptyOrWhite(value, nameof(this.Name));
                this.name = value;
            }
        }

        public string Value
        {
            get => this.value;
            private set
            {
                Validator.ValidateStringNullEmptyOrWhite(value, nameof(this.Value));
                this.value = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Name}=\"{this.Value}\"";
        }
    }
}