using System.Diagnostics;

namespace _03_DisposePattern
{
    internal class WithDispose : IDisposable
    {
        private Stopwatch stopwatch;
        private bool disposed = false;

        public WithDispose()
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                stopwatch.Stop();
                Interlocked.Increment(ref Program.FinalizedObjects);
                Interlocked.Add(ref Program.TotalTime, stopwatch.ElapsedMilliseconds);

                if (disposing)
                {
                    //explictly called from user code
                } 
                else
                {
                    //called from finalizer!
                }

            }
        }

        ~WithDispose()
        {
            Dispose(false);
        }
    }
}