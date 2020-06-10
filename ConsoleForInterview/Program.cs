using ConsoleForInterview.Examples;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleForInterview
{
    class Program
    {
        static void Main(string[] args)
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
            BSTExample.Execute();
        }   

        class Person
        {
            public string Name { get; set; }
        }
    }
}