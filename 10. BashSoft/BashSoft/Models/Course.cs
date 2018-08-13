namespace BashSoft.Models
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        public string name;
        public Dictionary<string, Student> studentsByName;
        public const int NumberOfTasksOnExam = 5;
        public const int MaxScoreOnExamTask = 100;

        public Course(string name)
        {
            this.name = name;
            this.studentsByName = new Dictionary<string, Student>();
        }

        public void EnrollStudent(Student student)
        {
            if (this.studentsByName.ContainsKey(student.UserName))
            {
                OutputWriter.DisplayException(String.Format(ExceptionMessages.StudentAlreadyEnrolledInGivenCourse, student.UserName, this.name));
                return;
            }

            this.studentsByName.Add(student.UserName, student);
        }
    }
}