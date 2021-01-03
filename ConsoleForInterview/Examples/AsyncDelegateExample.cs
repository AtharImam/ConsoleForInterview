using System;

namespace ConsoleForInterview.Examples
{
    class AsyncDelegateExample
    {
        delegate string SayHello(string str);
        public static void Execute()
        {
            SayHello say = new SayHello(DoWork);
            say.BeginInvoke("Athar Imam", (iresult) =>
            {
                var result = say.EndInvoke(iresult);
                Console.WriteLine(result);
            }, null);

            Console.WriteLine("Application End");
        }

        static string DoWork(string str)
        {
            return "Hello " + str;
        }
    }
}
