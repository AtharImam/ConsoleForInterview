using System;
using System.Threading;

namespace ConsoleApp1
{
    class DeadlockDemo
    {
        static Sm sm1 = new Sm();
        static Sm sm2 = new Sm();

        static void DeadLockEx()
        {
            Thread t1 = new Thread(DeadLockEx1);
            Thread t2 = new Thread(DeadLockEx2);
            t1.Start();
            t2.Start();
        }

        static void DeadLockEx1()
        {
            lock (sm1)
            {
                Thread.Sleep(2000);
                lock (sm2)
                {
                    sm2.Do();
                }
            }
        }

        static void DeadLockEx2()
        {
            lock (sm2)
            {
                Thread.Sleep(2000);
                lock (sm1)
                {
                    sm2.Do();
                }
            }
        }
    }

    class Sm
    {
        public void Do()
        {
            Console.WriteLine("Sm Do");
        }
    }
}
