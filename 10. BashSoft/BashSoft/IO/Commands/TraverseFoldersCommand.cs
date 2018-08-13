namespace BashSoft.IO.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Exceptions;
    using Judge;
    using Repository;

    public class TraverseFoldersCommand : Command
    {
        public TraverseFoldersCommand(string input, string[] data, Tester judge, StudentRepository repository, IoManager inputOutputManager) 
            : base(input, data, judge, repository, inputOutputManager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length < 2)
            {
                this.IOManager.TraverseDirectory(0);
            }
            else
            {
                var success = int.TryParse(this.Data[1], out var depth);

                if (success)
                {
                    this.IOManager.TraverseDirectory(depth);
                }
                else
                {
                    throw new NotANumberException();
                }
            }
        }
    }
}