namespace Logger.Appenders
{
    using System;
    using Interfaces;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(IFormatter format) 
            : base(format)
        {
        }

        public override void Append(string message, ReportLevel reportLevel, DateTime date)
        {
            Console.WriteLine(this.Formatter.Format(message, reportLevel, date));
        }
    }
}