namespace P03_StudentSystem
{
    using System;
    using System.Collections.Generic;

    public class Student
    {
        private string name;
        private int age;
        private double grade;

        public double Grade
        {
            get => grade;
            set => grade = value;
        }

        public int Age
        {
            get => age;
            set => age = value;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public Student(string name, int age, double grade)
        {
            this.Name = name;
            this.Age = age;
            this.grade = grade;
        }

        public override string ToString()
        {
            return $"{this.Name} is {this.Age} years old. {GetGradeComment(this)}";
        }

        private static string GetGradeComment(Student student)
        {
            if (student.Grade >= 5.00)
            {
                return "Excellent student.";
            }
            else if (student.Grade < 5.00 && student.Grade >= 3.50)
            {
                return "Average student.";
            }
            else
            {
                return "Very nice person.";
            }
        }

        public static Student Parse(string[] args)
        {
            var name = args[0];
            var age = int.Parse(args[1]);
            var grade = double.Parse(args[2]);

            return new Student(name, age, grade);
        }
    }
}