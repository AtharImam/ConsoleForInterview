using System;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleForInterview.Examples
{
    public class IEnumeratorVsIEnumerable
    {
        public static void Execute()
        {
            Employee emp = new Employee();
            while (emp.MoveNext())
            {
                Console.WriteLine(emp.Current);
            }

            Console.WriteLine("---------------------------------------");
            Person pers = new Person();
            foreach (var p in pers)
            {
                Console.WriteLine(p);
            }
        }

        class Person : IEnumerable<int>
        {
            List<int> list = new List<int>() { 11, 10, 22, 30, 44, 50 };

            public IEnumerator<int> GetEnumerator()
            {
                for (int i = 0; i < list.Count; i++)
                {
                    yield return list[i];
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                for (int i = 0; i < list.Count; i++)
                {
                    yield return list[i];
                }
            }
        }

        private class Employee : IEnumerator<int>
        {
            List<int> list = new List<int>() { 11, 10, 22, 30, 44, 50 };

            int currPos = -1;

            public int Current
            {
                get
                {
                    if (currPos > -1 && currPos < list.Count)
                    {
                        return list[currPos];
                    }

                    throw new InvalidOperationException();
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    if (currPos > -1 && currPos < list.Count)
                    {
                        return list[currPos];
                    }

                    throw new InvalidOperationException();
                }
            }

            public void Dispose()
            {

            }

            public bool MoveNext()
            {
                if (currPos < list.Count - 1)
                {
                    currPos++;
                    return true;
                }

                return false;
            }

            public void Reset()
            {
                currPos = -1;
            }
        }
    }
}
