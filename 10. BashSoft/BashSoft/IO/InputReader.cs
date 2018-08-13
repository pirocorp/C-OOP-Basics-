namespace BashSoft.IO
{
    using System;
    using Static_data;

    public class InputReader
    {
        private const string endCommand = "quit";
        private CommandInterpreter interpreter;

        public InputReader(CommandInterpreter interpreter)
        {
            this.interpreter = interpreter;
        }

        public void StartReadingCommands()
        {
            OutputWriter.WriteMessage($"{SessionData.currentPath}" + "> ");
            var input = Console.ReadLine().Trim();

            while (input != endCommand)
            {
                this.interpreter.InterpredCommand(input);
                OutputWriter.WriteMessage($"{SessionData.currentPath}" + "> ");
                input = Console.ReadLine().Trim();
            }
        }
    }
}