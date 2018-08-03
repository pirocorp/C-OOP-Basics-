namespace P02_Ferrari
{
    public class Ferrari : Car
    {
        private const string MakeConstant = "Ferrari";
        private const string ModelConstant = "488-Spider";

        private string driver;
        
        public Ferrari(string driver) 
            : base(MakeConstant, ModelConstant)
        {
            this.Driver = driver;
        }

        public string Driver
        {
            get => this.driver;
            set
            {
                //Validator.ValidateString(value, nameof(Driver));
                this.driver = value;
            }
        }

        public override string ToString()
        {
            return $"{this.Model}/{this.Stop()}/{this.Start()}/{this.Driver}";
        }
    }
}