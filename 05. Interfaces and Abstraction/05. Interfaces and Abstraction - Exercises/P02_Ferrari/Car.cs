using P02_Ferrari.Interfaces;

namespace P02_Ferrari
{
    public abstract class Car : ICar
    {
        private string make;
        private string model;

        protected Car(string make, string model)
        {
            this.Make = make;
            this.Model = model;
        }

        public string Make
        {
            get => this.make;
            protected set
            {
                Validator.ValidateString(value, nameof(this.Make));
                this.make = value;
            }
        }

        public string Model
        {
            get => this.model;
            protected set
            {
                Validator.ValidateString(value, nameof(this.Model));
                this.model = value;
            }
        }

        public virtual string Start()
        {
            return $"Zadu6avam sA!";
        }

        public virtual string Stop()
        {
            return $"Brakes!";
        }

        public override string ToString()
        {
            return $"{this.Make}/{this.Model}/{this.Stop()}/{this.Start()}";
        }
    }
}