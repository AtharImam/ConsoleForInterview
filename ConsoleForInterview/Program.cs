using ConsoleForInterview.Examples;
using System;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using ConsoleForInterview.CodingTest;

namespace ConsoleForInterview
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] paths = { @"D:\angulartest\auth-01-auth-component\node_modules",
            //@"D:\angulartest\firstangapp\node_modules",@"D:\angulartest\http-01-start\node_modules",
            //@"D:\angulartest\my-first-app\node_modules",@"D:\angulartest\pipes-start\node_modules"};
            //Parallel.ForEach(paths, (path) =>
            //    Utility.DeleteDirectory(path);
            //int totalFiles = 0;
            //long size = Utility.GetDirectorySize(@"D:\angulartest\my-first-app", ref totalFiles);
            //Console.WriteLine($"Total Files: {totalFiles}, Size in MB: {((size / 1024) / 1024)}");
            //Utility.DeleteDirectory(@"D:\angulartest\my-first-app\node_modules");
            //Utility.CopyDirectory(@"D:\JSExamples\angulartest\my-first-app\node_modules", @"D:\JSExamples\angulartest\ng-pwa-01-start");

            //for (int i = 0; i < 10; i++)
            //{
            //    using (SqlConnection conn = new SqlConnection("Data Source=localhost; Initial Catalog=TestDb; User Id=sa; Password=Passw0rd"))
            //    {
            //        conn.Open();
            //        Console.WriteLine("Connection Open: " + i);
            //        //conn.Close();
            //    }
            //}

            //ArrayElementAppears.Execute();
            //CamelCase.Execute();
            //Console.WriteLine(MediumTest.AlphabetIndex("Hello India"));
            //Console.WriteLine(MediumTest.CountDecoding("1231".ToCharArray(), 3));


            //AlphabetDecoding.Execute();
            //AlphabetFrequency.Execute();
            //GCDExample.Execute();
            //ChangeVariableExample.Execute();
            //SecondLargestNumberExample.Execute();
            ArrayElementAppears.Execute();
            Console.Read();
        }
    }
}