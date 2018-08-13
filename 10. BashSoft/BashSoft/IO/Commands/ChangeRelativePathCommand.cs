namespace BashSoft.IO.Commands
{
    using Exceptions;
    using Judge;
    using Repository;

    public class ChangeRelativePathCommand : Command
    {
        public ChangeRelativePathCommand(string input, string[] data, Tester judge, StudentRepository repository, IoManager inputOutputManager) 
            : base(input, data, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            var relPath = this.Data[1];
            this.IOManager.ChangeCurrentDirectoryRelative(relPath);
        }
    }
}