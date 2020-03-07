using System;
using System.Threading;

namespace Clr
{
    public class _2_ForegroundBackgroundThreads
    {

        /// <summary>
        /// Once all the foreground threads are finished,
        /// CLR does not wait for background threads to finish and quits early.
        /// `Compute`, when executed within a background thread, will never get executed.
        /// </summary>
        public void Execute()
        {
            Console.WriteLine("Starting work in main thread.");
            Thread backgroundThread = new Thread(Compute);
            backgroundThread.IsBackground = true;
            backgroundThread.Start(5);
            Console.WriteLine("Work in main thread finished.");
        }
        public void Compute(object state)
        {
            Thread.Sleep(1000);
            Console.WriteLine($"Worker state={state}.");
        }
    }
}