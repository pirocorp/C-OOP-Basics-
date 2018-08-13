namespace BashSoft.IO.Commands
{
    using System.Diagnostics;
    using Exceptions;
    using Judge;
    using Repository;
    using Static_data;

    public class OpenFileCommand : Command
    {
        public OpenFileCommand(string input, string[] data, Tester judge, StudentRepository repository, IoManager inputOutputManager) 
            : base(input, data, judge, repository, inputOutputManager)
        {

        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            var filename = this.Data[1];
            Process.Start(SessionData.CurrentPath + "\\" + filename);
        }
    }
}