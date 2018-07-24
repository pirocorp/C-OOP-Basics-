namespace Google
{
    using System;

    public class Child
    {
        public Child(string childName, string childBirthday)
        {
            this.childName = childName;
            this.childBirthday = childBirthday;
        }

        private string childName;
        private string childBirthday;
        
        public string ChildName
        {
            get => childName;
            set => childName = value;
        }

        public string ChildBirthday
        {
            get => childBirthday;
            set => childBirthday = value;
        }

        public static Child Parse(string input)
        {
            var tokens = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            return Parse(tokens);
        }

        public static Child Parse(string[] input)
        {
            var childName = input[0];
            var childBirthday = input[1];

            return new Child(childName, childBirthday);
        }

        public override string ToString()
        {
            return $"{this.ChildName} {this.ChildBirthday}" + Environment.NewLine;
        }
    }
}
