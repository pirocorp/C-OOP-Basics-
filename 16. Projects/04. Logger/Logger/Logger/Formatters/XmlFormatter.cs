namespace Logger.Formatters
{
    using System;
    using Interfaces;

    public class XmlFormatter : IFormatter
    {
        public string Format(string msg, ReportLevel reportLevel, DateTime date)
        {
            return $"<log>" + Environment.NewLine +
                   $"<message>{msg}</message>" + Environment.NewLine +
                   $"<date>{date}</date>" + Environment.NewLine +
                   $"<reportLevel>{reportLevel}</reportLevel>" + Environment.NewLine +
                   $"</log>";
        }
    }
}