using System;

class OverloadingSystemObject
{
    static void Main()
    {
        var firstStudent = new Student();
        firstStudent.Name = "Bai Ivan";
        firstStudent.Age = 68;
        Console.WriteLine(firstStudent); // called firstStudent.ToString()

        var secondStudent = new Student();
        if (firstStudent != secondStudent)  // it is true
            Console.WriteLine("{0} != {1}", firstStudent, secondStudent);

        secondStudent.Name = "Bai Ivan";
        secondStudent.Age = 68;
        if (firstStudent == secondStudent)  // it is true
            Console.WriteLine("{0} == {1}", firstStudent, secondStudent);

        secondStudent.Age = 70;
        if (firstStudent != secondStudent)  // it is true
            Console.WriteLine("{0} != {1}", firstStudent, secondStudent);
    }
}
