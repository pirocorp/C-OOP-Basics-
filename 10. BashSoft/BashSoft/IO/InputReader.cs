namespace BashSoft.IO
{
    using System;
    using Static_data;

    public class InputReader
    {
        private const string END_COMMAND = "quit";
        private CommandInterpreter interpreter;

        public InputReader(CommandInterpreter interpreter)
        {
            this.interpreter = interpreter;
        }

        public void StartReadingCommands()
        {
            OutputWriter.WriteMessage($"{SessionData.CurrentPath}" + "> ");
            var input = Console.ReadLine().Trim();

            while (input != END_COMMAND)
            {
                this.interpreter.InterpredCommand(input);
                OutputWriter.WriteMessage($"{SessionData.CurrentPath}" + "> ");
                input = Console.ReadLine().Trim();
            }
        }
    }
}