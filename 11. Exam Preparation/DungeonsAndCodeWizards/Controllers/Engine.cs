namespace DungeonsAndCodeWizards.Controllers
{
    using System;
    using System.Linq;
    using Interfaces;

    public class Engine
    {
        private bool isRunning;
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly DungeonMaster dungeonMaster;

        public Engine(IReader reader, IWriter writer)
        {
            this.isRunning = true;
            this.reader = reader;
            this.writer = writer;
            this.dungeonMaster = new DungeonMaster();
        }

        public void Run()
        {
            while (isRunning)
            {
                var command = this.reader.ReadLine();

                try
                {
                    this.ReadCommand(command);
                }
                catch (ArgumentException ae)
                {
                    this.writer.WriteLine($"Parameter Error: {ae.Message}");
                }
                catch (InvalidOperationException ioe)
                {
                    this.writer.WriteLine($"Invalid Operation: {ioe.Message}");
                }

                if (this.dungeonMaster.IsGameOver() || this.isRunning == false)
                {
                    this.writer.WriteLine("Final stats:");
                    this.writer.WriteLine(this.dungeonMaster.GetStats());
                    this.isRunning = false;
                }
            }
        }

        private void ReadCommand(string command)
        {
            if (string.IsNullOrEmpty(command))
            {
                this.isRunning = false;
                return;
            }

            var commandArgs = command.Split(' ');
            var commandName = commandArgs[0];
            var args = commandArgs.Skip(1).ToArray();

            var output = string.Empty;

            switch (commandName)
            {
                case "JoinParty":
                    output = this.dungeonMaster.JoinParty(args);
                    break;

                case "AddItemToPool":
                    output = this.dungeonMaster.AddItemToPool(args);
                    break;

                case "PickUpItem":
                    output = this.dungeonMaster.PickUpItem(args);
                    break;

                case "UseItem":
                    output = this.dungeonMaster.UseItem(args);
                    break;

                case "GiveCharacterItem":
                    output = this.dungeonMaster.GiveCharacterItem(args);
                    break;

                case "UseItemOn":
                    output = this.dungeonMaster.UseItemOn(args);
                    break;

                case "GetStats":
                    output = this.dungeonMaster.GetStats();
                    break;

                case "Attack":
                    output = this.dungeonMaster.Attack(args);
                    break;

                case "Heal":
                    output = this.dungeonMaster.Heal(args);
                    break;

                case "EndTurn":
                    output = this.dungeonMaster.EndTurn(args);
                    break;
            }

            if (output != string.Empty)
            {
                this.writer.WriteLine(output);
            }
        }
    }
}