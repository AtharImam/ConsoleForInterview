using System;
using System.Collections.Generic;
using System.Net;

namespace StandardConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            long l = 10;
            Display(1M);
            Console.Read();
        }

        static void Display(decimal num)
        {
            Console.WriteLine("decimal Display");
        }

        static void Display(double num)
        {
            Console.WriteLine("double Display");
        }

        static void Display()
        {
            Console.WriteLine("Default display");
        }

        static void Display(string name = "")
        {
            Console.WriteLine("Param display");
        }

        static void ChangeName(dynamic p)
        {
            p.Name = "Imam";
        }

        class Person
        {
            public string Name { get; set; }
        }

        enum Grade { Low = 1, Medium = 2, High = 4, Maximum = 8 }
        [Flags]
        enum GradeFlags { Low = 1, Medium = 2, High = 4, Maximum = 8 }
    }
}
