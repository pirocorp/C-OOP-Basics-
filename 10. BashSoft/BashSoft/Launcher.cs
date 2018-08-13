namespace BashSoft
{
    using IO;
    using Judge;
    using Repository;

    public class Launcher
    {
        public static void Main()
        {
            var tester = new Tester();
            var ioManager = new IOManager();
            var repo = new StudentRepository(new RepositoryFilter(), new RepositorySorter());

            var currentInterpreter = new CommandInterpreter(tester, repo, ioManager);
            var reader = new InputReader(currentInterpreter);

            reader.StartReadingCommands();
        }
    }
}