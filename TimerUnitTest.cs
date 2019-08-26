using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

class ClassWithTimer: IDisposable
{
    private readonly Timer _timer;

    public ClassWithTimer()
    {
        _timer = new Timer(TimeSpan.FromMinutes(5).Milliseconds) {AutoReset = true};
        _timer.Elapsed += TimerOnElapsed;
    }

    private void TimerOnElapsed(object sender, ElapsedEventArgs e)
    {
        Value = CalculateNewValue(Value);
    }

    public void Start()
    {
        _timer.Start();
    }

    public void Stop()
    {
        _timer.Stop();
    }

    public int Value { get; private set; }

    private static int CalculateNewValue(int oldValue)
    {
        int newValue = 0;
        // ... calculation omitted ...
        return newValue;
    }

    public void Dispose()
    {
        _timer?.Dispose();
    }
}
