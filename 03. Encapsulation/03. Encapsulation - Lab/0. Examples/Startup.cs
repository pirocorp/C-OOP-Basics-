namespace _0._Examples
{
    using System;

    public class Startup    
    {
        public static void Main()
        {
            try
            {
                var person = new Person("Stancho", "Stamatov", 23, 556);
                Console.WriteLine(person.Name);
                Console.WriteLine(person);

                person.IncreaseSalary(15);
                Console.WriteLine(person);

            }
            catch (Exception ex) when(ex is ArgumentException)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}