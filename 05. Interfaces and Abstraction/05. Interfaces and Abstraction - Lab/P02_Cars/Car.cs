    public abstract class Car : ICar
    {
        private string model;
        private string color;

        protected Car(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }

        public string Model
        {
            get => this.model;
            protected set
            {
                Validator.ValidateString(value, nameof(Model));
                this.model = value;
            }
        }

        public string Color
        {
            get => color;
            protected set
            {
                Validator.ValidateString(value, nameof(Color));
                this.color = value;
            }
        }

        public string Start()
        {
            return $"Engine start";
        }

        public string Stop()
        {
            return $"Breaaak!";
        }

        public override string ToString()
        {
            return $"{this.Color} {this.GetType().Name} {this.Model}";
        }
    }