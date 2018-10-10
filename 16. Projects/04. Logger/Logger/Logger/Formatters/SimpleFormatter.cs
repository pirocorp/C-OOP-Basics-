namespace Logger.Formatters
{
    using System;
    using Interfaces;

    public class SimpleFormatter : IFormatter
    {
        public string Format(string msg, ReportLevel reportLevel, DateTime date)
        {
            return $"{date} - {reportLevel} - {msg}";
        }
    }
}