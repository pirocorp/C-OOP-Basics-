namespace BashSoft.IO.Commands
{
    using Exceptions;
    using Judge;
    using Repository;

    public class ReadDatabaseCommand : Command
    {
        public ReadDatabaseCommand(string input, string[] data, Tester judge, StudentRepository repository, IoManager inputOutputManager) 
            : base(input, data, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            var databasePath = this.Data[1];
            this.Repository.LoadData(databasePath);
        }
    }
}