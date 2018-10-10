namespace Logger.Appenders
{
    using System;
    using Interfaces;

    public abstract class Appender : IAppender
    {
        private IFormatter formatter;

        protected Appender(IFormatter format)
        {
            this.Formatter = format;
        }

        public IFormatter Formatter
        {
            get => this.formatter;
            private set => this.formatter = value ?? throw new ArgumentNullException(nameof(this.Formatter), "Formatter cannot be null.");
        }

        public abstract void Append(string message, ReportLevel reportLevel, DateTime date);
    }
}