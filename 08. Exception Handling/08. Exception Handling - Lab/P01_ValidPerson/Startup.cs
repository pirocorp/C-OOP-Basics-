namespace P01_ValidPerson
{
    using System;

    public class Startup
    {
        public static void Main(string[] args)
        {
            var pesho = new Person("Pesho", "Peshev", 24);

            try
            {
                var noname = new Person(string.Empty, "Peshev", 35);
                var noLastname = new Person("Ivan", null, 22);

                var negativeAge = new Person("Ivan", "Ivanov", -5);
                var tooOld = new Person("Petranka", "Pesheva", 121);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Exception thrown: {e.Message}");
            }
        }
    }
}