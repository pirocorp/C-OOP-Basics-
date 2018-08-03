namespace P10_ExplicitInterfaces
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public class Startup
    {
        public static void Main()
        {
            var inputLine = string.Empty;

           while ((inputLine = Console.ReadLine()) != "End")
            {
                var tokens = inputLine.Split();

                var name = tokens[0];
                var country = tokens[1];
                var age = int.Parse(tokens[2]);

                var currentCitizen = new Citizen(name, country, age);
                var currentIperson = (IPerson) currentCitizen;
                var currentIresident = (IResident) currentCitizen;

                Console.WriteLine(currentIperson.GetName());
                Console.WriteLine(currentIresident.GetName());
            }
        }
    }
}
