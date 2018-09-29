namespace P07_StudentClass
{
    using System;

    public class Student
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        private string name;
        private int age;

        public Student(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public string Name
        {
            get => this.name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"Name cannot be empty or whitespace");
                }

                if (this.PropertyChanged != null)
                {
                    var eventArgs = new PropertyChangedEventArgs(nameof(this.name), this.name, value);
                    this.PropertyChanged(this, eventArgs);
                }

                this.name = value;
            }
        }

        public int Age
        {
            get => this.age;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Age cannot be negative");
                }

                if (this.PropertyChanged != null)
                {
                    var eventArgs = new PropertyChangedEventArgs(nameof(this.name), this.age.ToString(), value.ToString());
                    this.PropertyChanged(this, eventArgs);
                }

                this.age = value;
            }
        }
    }
}