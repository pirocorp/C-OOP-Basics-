namespace Logger.Interfaces
{
    using System;

    public interface IFormatter
    {
        string Format(string msg, ReportLevel reportLevel, DateTime date);
    }
}
