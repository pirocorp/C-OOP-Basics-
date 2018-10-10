namespace Logger.Interfaces
{
    using System;

    public interface IAppender
    {
        IFormatter Formatter { get; }

        void Append(string message, ReportLevel reportLevel, DateTime date);
    }
}
