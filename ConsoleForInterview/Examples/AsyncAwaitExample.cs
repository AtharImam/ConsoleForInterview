using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleForInterview
{
    public class AsyncAwaitExample
    {
        public static void Execute()
        {
            RunWithoutAwai();
        }

        static void RunWithoutAwai()
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
            public void DoWork()    
            {
                this.IsComplete = false;
                Console.WriteLine("Doing Work");
                LongOperation();
                Console.WriteLine("Work Completed");
                this.IsComplete = true;
            }

            public Task LongOperationAsync()
            {
                return Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Working!");
                    Thread.Sleep(2000);
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
