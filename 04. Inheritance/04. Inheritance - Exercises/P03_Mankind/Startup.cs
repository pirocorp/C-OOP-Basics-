using System;

namespace P03_Mankind
{
    public class Startup
    {
        public static void Main()
        {
            Student student = null;
            Worker worker = null;

            try
            {
                student = Student.Parse(Console.ReadLine());
                worker = Worker.Parse(Console.ReadLine());

                Console.WriteLine(student);
                Console.WriteLine(worker);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}