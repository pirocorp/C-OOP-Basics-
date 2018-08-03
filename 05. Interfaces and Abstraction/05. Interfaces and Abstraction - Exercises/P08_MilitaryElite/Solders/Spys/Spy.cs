namespace P08_MilitaryElite.Solders.Spys
{
    using System;
    using Interfaces;

    public class Spy : Soldier, ISpy
    {
        private int codeNumber;

        public Spy(int id, string firstname, string lastname, int codeNumber) 
            : base(id, firstname, lastname)
        {
            this.codeNumber = codeNumber;
        }

        public int CodeNumber => this.codeNumber;

        public override string ToString()
        {
            return $"{base.ToString()}" + Environment.NewLine + 
                   $"Code Number: {this.CodeNumber}";
        }
    }
}