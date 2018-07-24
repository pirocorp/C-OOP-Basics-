using System;

namespace Google
{
    public class Parent
    {
        public Parent(string parentName, string parentBirthday)
        {
            this.parentName = parentName;
            this.parentBirthday = parentBirthday;
        }

        private string parentName;
        private string parentBirthday;
        
        public string ParentName
        {
            get => parentName;
            set => parentName = value;
        }

        public string ParentBirthday
        {
            get => parentBirthday;
            set => parentBirthday = value;
        }

        public static Parent Parse(string input)
        {
            var tokens = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            return Parse(tokens);
        }

        public static Parent Parse(string[] input)
        {
            var parentName = input[0];
            var parentBirthday = input[1];

            return new Parent(parentName, parentBirthday);
        }

        public override string ToString()
        {
            return $"{this.ParentName} {this.ParentBirthday}" + Environment.NewLine;
        }
    }
}
