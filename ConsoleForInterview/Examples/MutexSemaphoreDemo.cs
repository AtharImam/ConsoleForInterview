using System;
using System.Threading;

namespace ConsoleApp1
{
    class MutexSemaphoreDemo
    {
        static Mutex m1 = new Mutex(true, "AImam");
        static Semaphore s1 = new Semaphore(2, 2, "AtharImam");


        public void Example()
        {
            //Create mumber of thread to explain muiltiple thread example  
            for (int i = 0; i < 4; i++)
            {
                Thread t = new Thread(MutexDemo);
                t.Name = string.Format("Thread {0} :", i + 1);
                t.Start();
            }
        }

        static void SemaphoreDemo()
        {
            if (s1.WaitOne(5000, false) == true)
            {

                Console.WriteLine("New Instance created...");
            }
            else
            {

                Console.WriteLine("Instance already acquired...");
            }
        }

        static void MutexDemo()
        {
            if (m1.WaitOne(5000, false))
            {

                Console.WriteLine("New Instance created...");
            }
            else
            {

                Console.WriteLine("Instance already acquired...");
            }
        }
    }
}
