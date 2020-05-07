using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StandardConsole
{
    public class AsyncAwaitExample
    {
        public static void Execute()
        {
            RunWithoutAwait();
        }

        static void RunWithoutAwait()
        {
            Console.WriteLine("Starting");
            Worker worker = new Worker();
            worker.DoWork();
            while (!worker.IsComplete)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }
            Console.WriteLine("Done");
            Console.ReadKey();
        }

        public class Worker
        {
            public bool IsComplete { get; private set; }
            public async Task DoWork()    
            {
                this.IsComplete = false;
                Console.WriteLine("Doing Work");
                await LongOperationWithParameterAsync("Hello");
                Console.WriteLine("Work Completed");
                await LongOperationWithParameterAsync("Hello");
                this.IsComplete = true;
            }

            public Task<int> LongOperationWithReturnAsync()
            {
                return Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Working!");
                    Thread.Sleep(25000);
                    return 100;
                });
            }

            public async Task<int> LongOperationWithParameterAsync(string name)
            {
                int value = 100;
                return await Task.Factory.StartNew(() =>
                {
                    Console.WriteLine(name);
                    Thread.Sleep(25000);
                    return value;
                    
                });
            }

            public Task LongOperationVoidAsync()
            {
                return Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Async Working!");
                    Thread.Sleep(15000);
                });
            }

            public void LongOperation()
            {
                Console.WriteLine("Working!");
                Thread.Sleep(2000);
            }
        }
    }
}
