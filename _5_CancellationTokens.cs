using System;
using System.Threading;

namespace Clr
{
    public class _5_CancellationTokens : IExample
    {
        public void Execute()
        {
            Console.WriteLine("Starting work on main thread.");
            CancellationTokenSource cts = new CancellationTokenSource();
            ThreadPool.QueueUserWorkItem(o => Worker(cts.Token, 1000000));
            Console.WriteLine("Press Enter to cancel worker process.");
            var key = Console.ReadKey();
            if (key.Key == ConsoleKey.Enter)
                cts.Cancel();
            Console.WriteLine("Process finished. Press key to exit.");
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
                Thread.Sleep(100);
            }
            Console.WriteLine("Worker done with processing.");
        }
    }
}