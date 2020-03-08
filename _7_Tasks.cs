using System;
using System.Threading;
using System.Threading.Tasks;

namespace Clr
{
    public class _7_Tasks : IExample
    {
        public void Execute()
        {
            var inputValue = 5;
            // Thread Pool
            Console.WriteLine($"Queueing operation on Thread Pool.");
            ThreadPool.QueueUserWorkItem(ComputeWithThread, inputValue);
            Console.WriteLine($"Thread Pool operation not waited on. No returned value could be communicated.");

            // new Task()
            Console.WriteLine($"Task created using `new Task()`.");
            var newTaskCompute = new Task<int>(() => ComputeWithTask(inputValue));
            newTaskCompute.Start();
            // Not mandatory, here for demonstration purposes.
            // Calling thread will wait on .Result as well.
            newTaskCompute.Wait();
            var newTaskResult = newTaskCompute.Result;
            Console.WriteLine($"Task created using `new Task` completed, resulting in {newTaskResult}.");

            // Task.Run()
            Console.WriteLine($"Task created using `Task.Run()`.");
            inputValue = 10;
            var taskRunCompute = Task.Run(() => ComputeWithTask(inputValue));
            taskRunCompute.Wait();
            var taskRunResult = taskRunCompute.Result;
            Console.WriteLine($"Task created using `new Task` completed, resulting in {taskRunResult}.");

            // Cancellation token for Tasks.
            CancellationTokenSource cts1 = new CancellationTokenSource();

            // new Task()
            Console.WriteLine($"Task created to be cancelled using `new Task()`.");
            var newTaskComputeCancelled = new Task<int>(() => ComputeWithTask(cts1.Token, inputValue), cts1.Token);
            newTaskComputeCancelled.Start();
            cts1.Cancel();
            try
            {
                // Exception gets thrown by the Task only when referencing .Result or .Wait()
                var newTaskResultCancelled = newTaskComputeCancelled.Result;
                Console.WriteLine($"Task created using `new Task` completed.");
            }
            catch (AggregateException ex)
            {
                Console.WriteLine("Task created using `new Task` cancelled.");
            }

            // Another cancellation token for Tasks.
            CancellationTokenSource cts2 = new CancellationTokenSource();

            // Task.Run()
            Console.WriteLine($"Task created using `Task.Run()`.");
            var taskRunComputeCancelled = Task.Run(() => ComputeWithTask(cts2.Token, inputValue), cts2.Token);
            cts2.Cancel();
            try
            {
                // Exception gets thrown by the Task only when referencing .Result or .Wait()
                var taskRunResultCancelled = taskRunComputeCancelled.Result;
                Console.WriteLine($"Task created using `Task.Run()` completed.");
            }
            catch (AggregateException ex)
            {
                Console.WriteLine("Task created using `Task.Run()` cancelled.");
            }
            Console.WriteLine("Done...");
        }

        public void ComputeWithThread(object state)
        {
            Console.WriteLine("\tStarting compute operation.");
            Thread.Sleep(2000);
            Console.WriteLine("\tCompute operation completed.");
            // No way to return a value.
        }

        public int ComputeWithTask(CancellationToken token, object state)
        {
            Console.WriteLine("\tStarting compute operation.");
            Thread.Sleep(2000);
            token.ThrowIfCancellationRequested();
            Console.WriteLine("\tCompute operation completed.");
            return (int)state * (int)state;
        }

        public int ComputeWithTask(object state)
        {
            Console.WriteLine("\tStarting compute operation.");
            Thread.Sleep(2000);
            Console.WriteLine("\tCompute operation completed.");
            return (int)state * (int)state;
        }
    }
}