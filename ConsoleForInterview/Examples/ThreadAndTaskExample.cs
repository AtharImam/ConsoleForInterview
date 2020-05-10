using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ThreadAndTaskExample
    {
        public static void Execute()
        {
            using (var cts = new CancellationTokenSource())
            {
                Task task = new Task(() => { LongRunningTaskWithToken(cts.Token); });
                task.Start();
                Console.WriteLine("Operation Performing...");
                if (Console.ReadKey().Key == ConsoleKey.C)
                {
                    Console.WriteLine("Cancelling..");
                    cts.Cancel();
                }
                Console.Read();
            }
        }

        private static void LongRunningTaskWithToken(CancellationToken token)
        {
            for (int i = 0; i < 10000000; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("Long running task cancelled");
                    break;
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }

        static void TaskContinueExample()
        {
            Task<int> task = new Task<int>(LongRunningTask);
            task.Start();
            Task<int> childTask = task.ContinueWith<int>(SquareOfNumber);
            Console.WriteLine("Sqaure of number is :" + childTask.Result);
            Console.WriteLine("The number is :" + task.Result);
        }

        private static int LongRunningTask()
        {
            Thread.Sleep(3000);
            return 2;
        }
        private static int SquareOfNumber(Task<int> obj)
        {
            return obj.Result * obj.Result;
        }

        static void MaxThreadExample()
        {
            int maxThread, completeThread;
            ThreadPool.GetMaxThreads(out maxThread, out completeThread);
            Console.WriteLine("Max Thread : {0}, Complete Thread : {1}", maxThread, completeThread);
            ThreadPool.GetMinThreads(out maxThread, out completeThread);
            Console.WriteLine("Min Thread : {0}, Complete Thread : {1}", maxThread, completeThread);
            ThreadPool.GetAvailableThreads(out maxThread, out completeThread);
            Console.WriteLine("Avl Thread : {0}, Complete Thread : {1}", maxThread, completeThread);
            Console.WriteLine("*********************");
            Task.Run(() => Parallel.For(0, 10, i => Thread.Sleep(2000)));
            Task.Run(() => Thread.Sleep(2000));
            Task.Run(() => Thread.Sleep(2000));
            Task.Run(() => Thread.Sleep(2000));
            Task.Run(() => Thread.Sleep(2000));
            //Thread.Sleep(10000);
            ThreadPool.GetMaxThreads(out maxThread, out completeThread);
            Console.WriteLine("Max Thread : {0}, Complete Thread : {1}", maxThread, completeThread);
            ThreadPool.GetMinThreads(out maxThread, out completeThread);
            Console.WriteLine("Min Thread : {0}, Complete Thread : {1}", maxThread, completeThread);
            ThreadPool.GetAvailableThreads(out maxThread, out completeThread);
            Console.WriteLine("Avl Thread : {0}, Complete Thread : {1}", maxThread, completeThread);
        }

        static void TaskExample1()
        {
            Parallel.For(0, 10, (i) =>
            {
                Thread.Sleep(1000);
                Console.WriteLine(i + " : Completed");
            });
            //Task.Factory.StartNew(Task1);
            //Task.Factory.StartNew(Task2);
            //Task.Factory.StartNew(Task3);
            Task.Factory.StartNew(Task1).ContinueWith((prev) => Task2()).ContinueWith((prev) => Task3());
        }

        static void Task1()
        {
            Console.WriteLine("Task1 Started");
            Thread.Sleep(1500);
            Console.WriteLine("Task1 Completed");
        }

        static void Task2()
        {
            Console.WriteLine("Task2 Started");
            Thread.Sleep(1000);
            Console.WriteLine("Task2 Completed");
        }
        static void Task3()
        {
            Console.WriteLine("Task3 Started");
            Thread.Sleep(500);
            Console.WriteLine("Task3 Completed");
        }

        static void BackgroundTaskExample()
        {
            Console.WriteLine("Task start");
            Method1();
            Method2();
            Console.Write("Please enter your name : ");
            string str = Console.ReadLine();
            Console.WriteLine("You have entered : " + str);
        }

        static async void Method1()
        {
            await Task.Delay(10000);
            Console.WriteLine("Method1 Executed.");
        }

        static async void Method2()
        {
            await Task.Delay(10000);
            Console.WriteLine("Method2 Executed.");
        }
    }
}
