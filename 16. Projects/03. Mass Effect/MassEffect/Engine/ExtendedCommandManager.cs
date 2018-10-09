namespace MassEffect.Engine
{
    using Commands;

    public class ExtendedCommandManager : CommandManager
    {
        public override void SeedCommands()
        {
            base.SeedCommands();

            this.commandsByName["system-report"] = new SystemReportCommand(this.Engine);
        }
    }
}