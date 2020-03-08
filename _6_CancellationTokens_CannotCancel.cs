using System;
using System.Threading;

namespace Clr
{
    public class _6_CancellationTokens : IExample
    {
        public void Execute()
        {
            Console.WriteLine("Starting work on main thread.");
            CancellationTokenSource cts = new CancellationTokenSource();
            // By passing .None, you sever the link between CancellationTokenSource and Token,
            // thus eliminating a way for the calling thread to cancel operation.
            ThreadPool.QueueUserWorkItem(o => Worker(CancellationToken.None, 5000));
            Console.WriteLine("Try to cancel worker process by pressing Enter.");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
                cts.Cancel();
            Console.WriteLine("Process is not cancelled. Press key to exit.");
            Console.ReadKey();
        }

        public void Worker(CancellationToken cancellationToken, int length)
        {
            Console.WriteLine("Worker starting to process.");
            for (int i = 0; i < length; i++)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    Console.WriteLine("Worker cancelled.");
                    return;
                }
                Thread.Sleep(1);
            }
            Console.WriteLine("Worker done with processing.");
        }
    }
}