namespace BashSoft.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using IO;
    using Static_data;

    public class RepositorySorter
    {
        public void OrderAndTake(Dictionary<string, double> wantedData, string comparison, int studentsToTake)
        {
            comparison = comparison.ToLower();
            if (comparison == "ascending")
            {
                this.PrintStudents(wantedData
                    .OrderBy(x => x.Value)
                    .Take(studentsToTake)
                    .ToDictionary(x => x.Key, x => x.Value));
            }
            else if(comparison == "descending")
            {
                this.PrintStudents(wantedData
                    .OrderByDescending(x => x.Value)
                    .Take(studentsToTake)
                    .ToDictionary(x => x.Key, x => x.Value));
            }
            else
            {
                throw new ArgumentNullException(ExceptionMessages.InvalidQueryComparison);
            }
        }

        public void PrintStudents(Dictionary<string, double> studentsSorted)
        {
            foreach (var kv in studentsSorted)
            {
                OutputWriter.PrintStudent(kv);
            }
        }
    }
}