using System;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Runtime.CompilerServices;

namespace ConsoleForInterview
{
    class Program
    {
        static void Main(string[] args)
        {
            DynamicVsObject.Execute();
            
        }

        static int fnc()
        {
            return 10;
        }

        class A
        {

        }

        class B : A
        {
            public B()
            {
                A();
            }
        }
    }
}
