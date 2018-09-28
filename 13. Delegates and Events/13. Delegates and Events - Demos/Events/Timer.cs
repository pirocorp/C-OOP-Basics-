using System.Threading;

public class Timer
{
    private int tickCount;
    private int interval;

    public event TimeChangedEventHandler TimeChanged;

    public Timer(int tickCount, int interval)
    {
        this.tickCount = tickCount;
        this.interval = interval;
    }

    public int TickCount => this.tickCount;

    public int Interval => this.interval;

    protected void OnTimeChanged(int tick)
    {
        if (this.TimeChanged != null)
        {
            var args = new TimeChangedEventArgs(tick);
            this.TimeChanged(this, args);
        }
    }

    public void Run()
    {
        var tick = this.tickCount;
        while (tick > 0)
        {
            Thread.Sleep(this.interval);
            tick--;
            this.OnTimeChanged(tick);
        }
    }
}
