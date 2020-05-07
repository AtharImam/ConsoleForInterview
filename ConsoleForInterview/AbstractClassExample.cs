using System;

namespace ConsoleForInterview
{
    public class AbstractClassExample
    {
        abstract class Abs1
        {
            public abstract int Num { get; set; }
            public abstract void Print();
        }

        abstract class Abs2 : Abs1
        {
            public abstract override void Print();
        }

        abstract class Abs3 : Abs2
        {
            public abstract override void Print();
        }

        class Impl : Abs3
        {
            public override int Num { get; set; }

            public override void Print()
            {
                Console.WriteLine("Print Abstract");
            }
        }
    }
}
