namespace Logger.Appenders
{
    using System;
    using System.IO;
    using Interfaces;

    public class FileAppender : Appender
    {
        private readonly string path;

        public FileAppender(IFormatter format, string path) 
            : base(format)
        {
            this.path = path;
        }

        public override void Append(string message, ReportLevel reportLevel, DateTime date)
        {
            var writer = new StreamWriter(this.path, true);
            writer.WriteLine(this.Formatter.Format(message, reportLevel, date));

            writer.Close();
        }
    }
}