namespace BashSoft
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RepositoryFilter
    {
        public void FilterAndTake(Dictionary<string, double> studentsWithMarks, string wantedFilters, int studentsToTake)
        {
            if (wantedFilters == "excellent")
            {
               FilterAndTake(studentsWithMarks, x => x >= 5, studentsToTake); 
            }
            else if (wantedFilters == "average")
            {
                FilterAndTake(studentsWithMarks, x => x >= 3.5 && x < 5, studentsToTake);
            }
            else if (wantedFilters == "poor")
            {
                FilterAndTake(studentsWithMarks, x => x < 3.5, studentsToTake);
            }
            else
            {
                OutputWriter.WriteMessageOnNewLine(ExceptionMessages.InvalidStudentFilter);
            }
        }

        private void FilterAndTake(Dictionary<string, double> studentsWithMarks, Predicate<double> givenFilter, int studentsToTake)
        {
            var takenCounter = 0;

            foreach (var studentMark in studentsWithMarks)
            {
                if (takenCounter == studentsToTake)
                    break;

                if (givenFilter(studentMark.Value))
                {
                    OutputWriter.PrintStudent(studentMark);
                    takenCounter++;
                }
            }
        }
    }
}