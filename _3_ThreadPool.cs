using System;
using System.Threading;

namespace Clr
{
    public class _3_ThreadPool : IExample
    {
        /// <summary>
        /// Thread pool threads do their work and go back to the pool.
        /// Threads are background threads, so the thread below will not get executed all the way.
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("Starting work in main thread.");
            ThreadPool.QueueUserWorkItem(Compute, 5);
            Console.WriteLine("Doing other work in main thread.");
            Thread.Sleep(2000);
            Console.WriteLine("Work in main thread finished.");
        }

        public void Compute(object state)
        {
            Console.WriteLine($"Worker state={state}.");
            Thread.Sleep(1000);
        }
    }
}