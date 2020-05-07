using System;

namespace ConsoleApp1
{
    class InterfaceExample
    {
        interface G1
        {

            // interface method 
            void mymethod();
        }

        interface G2
        {

            // interface method 
            void mymethod();
        }

        // 'Geeks' implements both 
        // G1 and G2 interface 
        internal class Geeks : G1, G2
        {
            public Geeks()
            {
            }

            void G1.mymethod()
            {
                Console.WriteLine("GeeksforGeeks G1");
            }

            void G2.mymethod()
            {
                Console.WriteLine("GeeksforGeeks G2");
            }

            // Defining method 
            // this statement gives an error 
            // because we doesn't specify 
            // the interface name 
            public void mymethod()
            {
                Console.WriteLine("GeeksforGeeks");
            }
        }
    }
}
