using System.Diagnostics;

namespace _03_DisposePattern
{
    internal class WithoutDispose
    {
        private Stopwatch stopwatch;

        public WithoutDispose()
        {
            stopwatch = new Stopwatch();
            stopwatch.Start();
        }

        public void DoWork()
        {
            double j = 0;
            for (int i = 0; i < 1000; i++)
            {
                j += i * i;
            }
        }
        ~WithoutDispose()
        {
            stopwatch.Stop();
            Interlocked.Increment(ref Program.FinalizedObjects);
            Interlocked.Add(ref Program.TotalTime, stopwatch.ElapsedMilliseconds);
        }
    }
}