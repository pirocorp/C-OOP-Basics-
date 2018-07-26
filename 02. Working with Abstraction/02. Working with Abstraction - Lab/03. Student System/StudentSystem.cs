namespace P03_StudentSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class StudentSystem
    {
        private Dictionary<string, Student> repo;

        public StudentSystem()
        {
            this.Repo = new Dictionary<string, Student>();
        }

        public Dictionary<string, Student> Repo
        {
            get => repo;
            private set => repo = value;
        }

        public void ParseCommand(string inputLine, Action<string> printAction)
        {
            var args = inputLine.Split();

            if (args[0] == "Create")
            {
                var name = args[1];

                if (!repo.ContainsKey(name))
                {
                    var student = Student.Parse(args.Skip(1).ToArray());

                    Repo[name] = student;
                }
            }
            else if (args[0] == "Show")
            {
                var name = args[1];

                if (Repo.ContainsKey(name))
                {
                    var student = Repo[name];

                    printAction(student.ToString());
                }
            }
        }
    }
}