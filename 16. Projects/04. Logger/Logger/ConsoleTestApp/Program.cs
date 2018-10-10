namespace ConsoleTestApp
{
    using Logger;
    using Logger.Appenders;
    using Logger.Formatters;

    public class Program
    {
        public static void Main()
        {
            var simpleFormat = new SimpleFormatter();
            var xmlFormat = new XmlFormatter();
            var consoleAppender = new ConsoleAppender(xmlFormat);
            var fileAppender = new FileAppender(xmlFormat, "log.txt");
            var logger = new Logger(consoleAppender);
            logger.Critical("Out of Memory");
            logger.Info("Unused local variable 'name'");
        }
    }
}
