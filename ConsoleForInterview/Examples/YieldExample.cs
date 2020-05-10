using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleForInterview
{
    public class YieldExample
    {
        public static void Execute()
        {
            foreach(int num in GetNumber())
            {
                Console.WriteLine("Number : " + num);
            }
        }

        public static IEnumerable<int> GetNumber()
        {
            for(int index = 0; index < 5; index++)
            {
                yield return (index + 1)*10;
                int num = 10;
            }
        }
    }
}
