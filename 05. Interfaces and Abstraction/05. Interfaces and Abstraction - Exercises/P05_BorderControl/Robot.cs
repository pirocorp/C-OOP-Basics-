using P05_BorderControl.Interfaces;

namespace P05_BorderControl
{
    public class Robot : IInhabitants
    {
        private string model;
        private string id;

        public Robot(string model, string id)
        {
            this.Model = model;
            this.Id = id;
        }

        public string Model
        {
            get => this.model;
            private set
            {
                this.model = value;
            }
        }

        public string Id
        {
            get => this.id;
            private set
            {
                this.id = value;
            }
        }
    }
}