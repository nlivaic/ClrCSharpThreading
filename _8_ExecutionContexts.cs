using System;
using System.Threading;
using System.Threading.Tasks;

namespace Clr
{
    public class _8_ExecutionContexts : IExample
    {
        public int MyProperty { get; set; }

        public void Execute()
        {
            Console.WriteLine("Execute started.");
            var t = Task.Run(() => Compute());
            t.ContinueWith(t => Continuation());
            Console.WriteLine("Execute done.");
        }

        public void Compute()
        {
            Console.WriteLine("Computing started.");
            Thread.Sleep(1000);     // Simulate work.
            Console.WriteLine("Computing done.");
        }

        private void Continuation()
        {
            Console.WriteLine("Continuation started.");
            MyProperty = 19;
            Console.WriteLine("Continuation done.");
        }
    }
}