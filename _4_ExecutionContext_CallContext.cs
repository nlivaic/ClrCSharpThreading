using System;
using System.Threading;

namespace Clr
{
    /// <summary>
    /// Examples won't work because `CallContext` does not exist in .NET Core.
    /// </summary>
    public class _4_ExecutionContext_CallContext
    {
        public void Execute()
        {
            // Console.WriteLine("Starting work in main thread.");
            // CallContext.LogicalSetData("Name", "SomeValue");
            // // Execution context flows to child thread by default.
            // // Output should be "SomeValue".
            // ThreadPool.QueueUserWorkItem(Compute, 5);
            // Console.WriteLine("Doing other work in main thread.");
            // Thread.Sleep(2000);
            // // Suppress flow of execution context to child thread.
            // // Output should be empty.
            // ExecutionContext.SuppressFlow();
            // ThreadPool.QueueUserWorkItem(Compute, 6);
            // Console.WriteLine("Work in main thread finished.");
        }

        public void Compute(object state)
        {
            // var v = (string)CallContext.LogicalGetData("Name");
            // Console.WriteLine($"Compute v={v}");
        }
    }
}