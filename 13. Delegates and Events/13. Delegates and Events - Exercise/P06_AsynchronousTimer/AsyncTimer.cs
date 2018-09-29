namespace P06_AsynchronousTimer
{
    using System;
    using System.Timers;

    public class AsyncTimer
    {
        private Timer timer;

        public AsyncTimer(Action action, int ticks, int timeInterval)
        {
            this.Action = action;
            this.Ticks = ticks;
            this.TimeInterval = timeInterval;
            this.timer = new Timer(timeInterval);
        }

        public Action Action { get; }

        public int Ticks { get; private set; }

        public int TimeInterval { get; }

        public void Run()
        {
            this.timer.Elapsed += this.OnTimeEvent;
            this.timer.AutoReset = true;
            this.timer.Enabled = true;
        }

        private void OnTimeEvent(object sender, ElapsedEventArgs e)
        {
            this.Action();

            if (this.Ticks <= 1)
            {
                this.timer.AutoReset = false;
                this.timer.Enabled = false;
            }

            this.Ticks--;
        }
    }
}