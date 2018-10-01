namespace P02_Customer
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            var customers = new List<Customer>()
            {
                new Customer("Stanka", "Peshova", "Ivanova", "830933049123", "Bulgaria, Sofia, 16 Vitosha str.", "+359897856231", "peterchuk@aac.bg", CustomerType.Regular),
                new Customer("Galin", "Peshov", "Gqrov", "83090494343123", "Bulgaria, Sofia, 16 Vitosha str.", "+359897856231", "peterchuk@aac.bg", CustomerType.Diamond),
                new Customer("Ivan", "Peshov", "Ivanov", "830904943434123", "Bulgaria, Sofia, 16 Vitosha str.", "+359897856231", "peterchuk@aac.bg", CustomerType.OneTime),
                new Customer("Chora", "Peshov", "Ivanov", "83090434349123", "Bulgaria, Sofia, 44 Simonas str.", "+359897856231", "peterchuk@aac.bg", CustomerType.Golden),
                new Customer("Asen", "Asenov", "Asenov", "83094343049123", "Bulgaria, Sofia, 16 Vitosha str.", "+359897856231", "peterchuk@aac.bg", CustomerType.Regular),
                new Customer("Asen", "Asenov", "Asenov", "43343434343434", "Bulgaria, Sofia, 16 Vitosha str.", "+359897856231", "peterchuk@aac.bg", CustomerType.Regular),
            };

            foreach (var customer in customers)
            {
                customer.addPayment(new Payment("Test Item", 3.442m));
            }

            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
            }

            var originalCustomer = new Customer("FirstPersonName", "FirstPersonName", "FirstPersonName", "FirstPersonName", "FirstPersonName", "FirstPersonName", "FirstPersonName", CustomerType.Diamond);
            var clone = originalCustomer.Clone();
            clone.addPayment(new Payment("Clone Payment", 1000M));
            clone.addPayment(new Payment("Clone Payment", 1000M));
            clone.addPayment(new Payment("Clone Payment", 1000M));
            clone.addPayment(new Payment("Clone Payment", 1000M));

            Console.WriteLine(originalCustomer);
            Console.WriteLine(clone);

            customers.Sort();
            foreach (var customer in customers)
            {
                Console.WriteLine(customer);
            }
        }
    }
}
