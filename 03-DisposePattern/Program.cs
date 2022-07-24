namespace _03_DisposePattern
{
    internal class Program
    {
        public static long FinalizedObjects = 0;
        public static long TotalTime = 0;
        static void Main(string[] args)
        {
            for (int i = 0; i < 500000; i++)
            {
                //var obj = new WithoutDispose();
                //obj.DoWork();
                using (var obj = new WithDispose())
                    obj.DoWork();
        }
            double avgLifetime = 1.0 * TotalTime / FinalizedObjects;
            Console.WriteLine($"Number of disposed/finalized objects: {FinalizedObjects} k");
            Console.WriteLine($"Average resource lifetime: {avgLifetime} ms");
        }
    }
}