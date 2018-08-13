namespace BashSoft.IO.Commands
{
    using System;
    using Exceptions;
    using Judge;
    using Repository;

    public abstract class Command
    {
        private string input;
        private string[] data;
        private Tester judge;
        private StudentRepository repository;
        private IoManager inputOutputManager;

        protected Command(string input, string[] data, Tester judge, StudentRepository repository, IoManager inputOutputManager)
        {
            this.Input = input;
            this.Data = data;
            this.judge = judge;
            this.repository = repository;
            this.inputOutputManager = inputOutputManager;
        }

        protected string Input
        {
            get => this.input;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }

                this.input = value;
            }
        }

        protected string[] Data
        {
            get => this.data;
            private set
            {
                if (value == null || value.Length == 0)
                {
                    throw new NullReferenceException();
                }

                this.data = value;
            }
        }

        protected Tester Judge => this.judge;

        protected StudentRepository Repository => this.repository;

        protected IoManager IOManager => this.inputOutputManager;

        public abstract void Execute();
    }
}