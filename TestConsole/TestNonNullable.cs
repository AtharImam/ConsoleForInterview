using System;
using System.Collections.Generic;
using System.Text;

namespace TestConsole
{
    internal class TestNonNullable
    {
        public static void Test()
        {
            NonNullableType nonNullableType = new NonNullableType();
            Console.WriteLine(nonNullableType.Name);
        }
    }   
}
