using System;
using System.Collections;
using System.Collections.Generic;

namespace StandardConsole
{
    public class YieldExample
    {
        public delegate int Add(int num);

        public event Add AddEvent;

        public void ShowNumber()
        {
            Console.WriteLine(AddEvent(20));
        }

        public static void Execute()
        {
            foreach(int num in GetNumber())
            {
                Console.WriteLine("Number : " + num);
            }
        }

        public static IEnumerator GetCounter()
        {
            for (int index = 0; index < 5; index++)
            {
                yield return (index + 1) * 10;
            }
        }


        public static IEnumerable<int> GetNumber()
        {
            int num = 1;
            for(int index = 0; index < 5; index++)
            {
                yield return (index + 1)*10;
                num *= index;
            }

            yield return num;
        }
    }
}
