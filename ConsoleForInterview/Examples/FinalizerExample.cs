using System;
using System.Threading;

namespace ConsoleForInterview
{
    public class FinalizerExample
    {
        public static void Execute()
        {
            CreateObject();
            GC.Collect(3);
            //GC.WaitForPendingFinalizers();
            //GC.Collect(3);
            Thread.Sleep(100);
        }

        static void CreateObject()
        {
            using (Abc abc = new Abc()) ;
            //    abc.Dispose();
            //abc = null;
        }

        class Abc : IDisposable
        {
            public Abc()
            {
                Console.WriteLine("Constructor called");
            }
            public void Dispose()
            {
                Dispose(true);
                //GC.SuppressFinalize(this);
            }
            protected void Dispose(bool isDisposing)
            {
                Console.WriteLine("Dispose Called");
            }

            ~Abc()
            {
                Console.WriteLine("Distructor Called");
                Dispose(false);
            }
        }
    }
}
