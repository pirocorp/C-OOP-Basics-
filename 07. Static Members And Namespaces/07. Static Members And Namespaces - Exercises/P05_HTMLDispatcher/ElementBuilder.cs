namespace P05_HTMLDispatcher
{
    using System.Collections.Generic;
    using System.Text;

    public class ElementBuilder
    {
        private string elementName;
        private List<Atribut> atributes;
        private string content;

        public ElementBuilder(string elementName)
        {
            this.ElementName = elementName;
            this.atributes = new List<Atribut>();
        }

        public string ElementName
        {
            get => this.elementName;
            private set
            {
                Validator.ValidateStringNullEmptyOrWhite(value, nameof(this.ElementName));
                this.elementName = value;
            }
        }

        public IReadOnlyCollection<Atribut> Atributes => this.atributes;

        public string Content
        {
            get => this.content;
            private set
            {
                Validator.ValidateStringNullEmptyOrWhite(value, nameof(this.Content));
                this.content = value;
            }
        }

        public void AddAttribute(string atributeName, string value)
        {
            var atribut = new Atribut(atributeName, value);
            this.atributes.Add(atribut);
        }

        public void AddContent(string content)
        {
            this.Content = content;
        }

        public static string operator *(ElementBuilder element, int n)
        {
            var stringBuilder = new StringBuilder();

            for (var i = 0; i < n; i++)
            {
                stringBuilder.Append(element);
            }

            return stringBuilder.ToString();
        }

        public static string operator *(int n, ElementBuilder element)
        {
            return element * n;
        }

        public override string ToString()
        {
            return $"<{this.ElementName} {string.Join(" ", this.Atributes)}>{this.Content}</{this.ElementName}>";
        }
    }
}