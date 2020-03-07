using System;
using System.Threading;

namespace Clr
{
    public class _1_ThreadsExample
    {
        public void Execute()
        {
            Console.WriteLine("Starting work in main thread.");
            Thread thread = new Thread(Worker);
            thread.Start(5);
            Console.WriteLine("Doing other work in main thread.");
            Thread.Sleep(1000);
            thread.Join();
            Console.WriteLine("Work in main thread finished.");
        }

        public void Worker(object state)
        {
            Console.WriteLine($"Worker state={state}.");
            Thread.Sleep(1000);
        }
    }
}