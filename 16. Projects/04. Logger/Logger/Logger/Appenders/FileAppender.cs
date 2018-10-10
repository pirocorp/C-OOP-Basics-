namespace Logger.Appenders
{
    using System;
    using System.IO;
    using Interfaces;

    public class FileAppender : Appender
    {
        private readonly string path;
        private readonly StreamWriter writer;

        public FileAppender(IFormatter format, string path) 
            : base(format)
        {
            this.path = path;
            this.writer = new StreamWriter(this.path, true);
        }

        public override void Append(string message, ReportLevel reportLevel, DateTime date)
        {
            this.writer.WriteLine(this.Formatter.Format(message, reportLevel, date));
        }

        public void Close()
        {
            this.writer.Close();
        }
    }
}