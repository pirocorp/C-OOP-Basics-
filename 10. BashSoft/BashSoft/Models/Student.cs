﻿namespace BashSoft.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Static_data;

    public class Student
    {
        private string userName;
        private Dictionary<string, Course> enrolledCourses;
        private Dictionary<string, double> marksByCourseName;

        public Student(string userName)
        {
            this.UserName = userName;
            this.enrolledCourses = new Dictionary<string, Course>();
            this.marksByCourseName = new Dictionary<string, double>();
        }

        public string UserName
        {
            get => this.userName;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException(nameof(this.UserName), ExceptionMessages.NullOrEmptyValue);
                }

                this.userName = value;
            }
        }

        public IReadOnlyDictionary<string, Course> EnrolledCourses => this.enrolledCourses;

        public IReadOnlyDictionary<string, double> MarksByCourseName => this.marksByCourseName;

        public void EnrollInCourse(Course course)
        {
            if (this.enrolledCourses.ContainsKey(course.Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.StudentAlreadyEnrolledInGivenCourse, this.userName, course.Name));
            }

            this.enrolledCourses.Add(course.Name, course);
        }

        public void SetMarksInCourse(string courseName, params int[] scores)
        {
            if (!this.enrolledCourses.ContainsKey(courseName))
            {
                throw new ArgumentException(ExceptionMessages.NotEnrolledInCourse);
            }

            if (scores.Length > Course.NumberOfTasksOnExam)
            {
                throw new ArgumentException(ExceptionMessages.InvalidNumberOfScores);
            }

            this.marksByCourseName.Add(courseName, CalculateMark(scores));
        }

        private double CalculateMark(int[] scores)
        {
            var percentageOfSolvedExam = scores.Sum() / (double) (Course.NumberOfTasksOnExam * Course.MaxScoreOnExamTask);
            var mark = percentageOfSolvedExam * 4 + 2;
            return mark;
        }
    }
}