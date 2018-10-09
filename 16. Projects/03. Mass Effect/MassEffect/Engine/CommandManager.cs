﻿namespace MassEffect.Engine
{
    using System;
    using System.Collections.Generic;

    using Commands;
    using Interfaces;

    public class CommandManager : ICommandManager
    {
        protected readonly Dictionary<string, Command> commandsByName;

        public CommandManager()
        {
            this.commandsByName = new Dictionary<string, Command>();
        }

        public IGameEngine Engine { get; set; }

        public void ProcessCommand(string commandString)
        {
            var commandArgs = commandString.Split(' ');
            var commandName = commandArgs[0];

            if (!this.commandsByName.ContainsKey(commandName))
            {
                throw new NotSupportedException($"Command {commandName} does not exist.");
            }

            var command = this.commandsByName[commandName];
            command.Execute(commandArgs);
        }

        public virtual void SeedCommands()
        {
            this.commandsByName["create"] = new CreateCommand(this.Engine);
            this.commandsByName["attack"] = new AttackCommand(this.Engine);
            this.commandsByName["status-report"] = new StatusReportCommand(this.Engine);
            this.commandsByName["plot-jump"] = new PlotJumpCommand(this.Engine);
            this.commandsByName["over"] = new OverCommand(this.Engine);
        }
    }
}
