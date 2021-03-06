﻿namespace _03._Company_Roster
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class CompanyRoster
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var employees = new List<Employee>();

            for (var i = 0; i < n; i++)
            {
                employees.Add(Employee.Parse(Console.ReadLine()));
            }

            var highAverageDepartment = employees
                .GroupBy(x => x.Department, (s, employeesByGroup) => new
                {
                    department = s,
                    workers = employeesByGroup.ToList(),
                    average = employeesByGroup.Average(e => e.Salary),
                })
                .OrderByDescending(g => g.average)
                .First();

            Console.WriteLine($"Highest Average Salary: {highAverageDepartment.department}");

            highAverageDepartment.workers
                .OrderByDescending(x => x.Salary)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x.Name} {x.Salary:F2} {x.Email} {x.Age}"));
        }
    }
}
