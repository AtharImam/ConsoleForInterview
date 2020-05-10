using System;

namespace StandardConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomainExample.Execute();
            Console.Read();
        }

        enum Grade { Low = 1, Medium = 2, High = 4, Maximum = 8 }
        [Flags]
        enum GradeFlags { Low = 1, Medium = 2, High = 4, Maximum = 8 }
    }
}
