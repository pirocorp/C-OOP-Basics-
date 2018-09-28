namespace P04_CustomLINQExtensionMethods
{
    public class Student
    {
        public Student(string name, int grade)
        {
            this.Name = name;
            this.Grade = grade;
        }

        public string Name { get; }

        public int Grade { get; }
    }
}