using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleForInterview.Examples
{
    class OperatorOverloadingExample
    {
        public static void Execute()
        {
            
        }

        class Complex
        {
            private int x;
            private int y;
            public Complex()
            {
            }
            public Complex(int i, int j)
            {
                x = i;
                y = j;
            }
            public void ShowXY()
            {
                Console.WriteLine("{0} {1}", x, y);
            }
            public static Complex operator -(Complex c)
            {
                Complex temp = new Complex();
                temp.x = -c.x;
                temp.y = -c.y;
                return temp;
            }
        }

        interface I
        {

        }

        static class A
        {
            static A()
            {

            }
        }
    }
}
