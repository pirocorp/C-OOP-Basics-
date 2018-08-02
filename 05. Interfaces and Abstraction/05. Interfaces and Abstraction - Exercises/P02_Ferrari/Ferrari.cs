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
            get => driver;
            set
            {
                //Validator.ValidateString(value, nameof(Driver));
                driver = value;
            }
        }

        public override string ToString()
        {
            return $"{base.Model}/{Stop()}/{Start()}/{this.Driver}";
        }
    }
}