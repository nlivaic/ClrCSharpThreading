using System;
using System.Threading;

namespace Clr
{
    public class _2_ForegroundBackgroundThreads
    {
        public void Execute()
        {
            Console.WriteLine("Starting work in main thread.");
            Thread backgroundThread = new Thread(Worker);
            backgroundThread.IsBackground = true;
            backgroundThread.Start(5);
            Console.WriteLine("Work in main thread finished.");
        }

        /// <summary>
        /// Once all the foreground threads are finished,
        /// CLR does not wait for background threads to finish and quits early.
        /// Code below, when executed within a background thread, will never get executed.
        /// </summary>
        public void Worker(object state)
        {
            Thread.Sleep(1000);
            Console.WriteLine($"Worker state={state}.");
        }
    }
}