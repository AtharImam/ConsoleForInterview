using ConsoleForInterview.Examples;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleForInterview
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //int totalFiles = 0;
            //long size = Utility.GetDirectorySize(@"D:\angulartest\my-first-app", ref totalFiles);
            //Console.WriteLine($"Total Files: {totalFiles}, Size in MB: {((size / 1024) / 1024)}");
            //Utility.DeleteDirectory(@"D:\angulartest\my-first-app\node_modules");
            //Utility.CopyDirectory(@"D:\angulartest\my-first-app\node_modules", @"D:\angulartest\auth-01-auth-component");
            //Console.ReadLine();
            //MediumTest.Execute();
            //Console.WriteLine(Convert.ToString(10, 2));
            //Console.WriteLine(Convert.ToInt32("101", 2));
            //Console.WriteLine($"{(int)'A'} {(int)'a'} {(int)'0'}");

            //IEnumeratorVsIEnumerable.Execute();
            //IComparerVsIComparable.Execute();  
            //UnityContainerTest.Execute();
            //LinqExample.Execute();
            //ShallowVsDeepClone.Execute();
            //BSTExample.Execute();
            //Task delay = asyncTask();
            //syncCode();
            //delay.Wait();
            //Console.ReadLine();
            //WaitFor().Wait();
            (int x, string s) = ReturnMultiple();
            Console.WriteLine($"{x} {s}");
        }

        static (int, string) ReturnMultiple()
        {
            return (5, "Imam");
        }

        private static async Task WaitFor()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(5000);
            });

            Thread.Sleep(5000);
        }

        static async Task asyncTask()
        {
            var sw = new Stopwatch();
            sw.Start();
            Console.WriteLine("async: Starting");
            Task delay = Task.Delay(5000);
            Console.WriteLine("async: Running for {0} seconds", sw.Elapsed.TotalSeconds);
            await delay;
            Console.WriteLine("async: After Delay Running for {0} seconds", sw.Elapsed.TotalSeconds);
            Console.WriteLine("async: Done");
        }

        static void syncCode()
        {
            var sw = new Stopwatch();
            sw.Start();
            Console.WriteLine("sync: Starting");
            Thread.Sleep(5000);
            Console.WriteLine("sync: After Sleep Running for {0} seconds", sw.Elapsed.TotalSeconds);
            Console.WriteLine("sync: Done");
        }

       

        [MethodImpl(MethodImplOptions.Synchronized)]
        static void Change(out Person pers)
        {
            pers = new Person() {Name="Imam" };
        }

        class Person
        {
            public string Name { get; set; }
        }
    }
}