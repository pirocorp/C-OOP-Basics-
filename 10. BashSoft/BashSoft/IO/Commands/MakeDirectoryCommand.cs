namespace BashSoft.IO.Commands
{
    using Exceptions;
    using Judge;
    using Repository;

    public class MakeDirectoryCommand : Command
    {
        public MakeDirectoryCommand(string input, string[] data, Tester judge, StudentRepository repository, IoManager inputOutputManager) 
            : base(input, data, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            var folderName = this.Data[1];
            this.IOManager.CreateDirectoryInCurrentFolder(folderName);
        }
    }
}