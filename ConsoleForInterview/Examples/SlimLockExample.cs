﻿using System;
using System.Text;
using System.Threading;

namespace ConsoleForInterview
{
    public class SlimLockExample
    {
        const int MaxValues = 25;
        static int[] _array = new int[MaxValues];
        static ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();

        public static void Execute()
        {
            ThreadPool.QueueUserWorkItem(WriteThread);
            for (int i = 0; i < 3; i++)
            {
                ThreadPool.QueueUserWorkItem(ReadThread);
            }
        }

        static void WriteThread(object state)
        {
            int id = Thread.CurrentThread.ManagedThreadId;
            for (int i = 0; i < MaxValues; ++i)
            {
                _lock.EnterWriteLock();
                Console.WriteLine("///////////////Entered WriteLock on thread {0}", id);
                _array[i] = i * i;
                Console.WriteLine("==============Added {0} to array on thread {1}", _array[i], id);
                Console.WriteLine(@"\\\\\\\\\\\\\\\Exiting WriteLock on thread {0}", id);
                _lock.ExitWriteLock();
                Thread.Sleep(100);
            }
        }
        static void ReadThread(object state)
        {
            int id = Thread.CurrentThread.ManagedThreadId;
            for (int i = 0; i < MaxValues; ++i)
            {
                _lock.EnterReadLock();
                Console.WriteLine("*******************Entered ReadLock on thread {0}", id);
                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < i; j++)
                {
                    if (sb.Length > 0) sb.Append(", ");
                    sb.Append(_array[j]);
                }
                Console.WriteLine("-------------------Array: {0} on thread {1}", sb, id);
                Console.WriteLine("+++++++++++++++++++Exiting ReadLock on thread {0}", id);
                _lock.ExitReadLock();
                Thread.Sleep(100);
            }
        }
    }
}
