using System;

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
