using System;

namespace ConsoleApp1
{
    public delegate string demoDelegate(string str1, string str2);
    
    public class EventExample
    {
        event demoDelegate myEvent;
        public EventExample()
        {
            this.myEvent += (str1, str2) => this.Display(str1, str2);
            this.myEvent += new demoDelegate(this.Display1);
        }
        public string Display(string studentname, string subject)
        {
            string str = "Student: " + studentname + "\nSubject: " + subject;
            Console.WriteLine(str);
            return str;
        }

        public string Display1(string studentname, string subject)
        {
            string str = "Student1: " + studentname + "\nSubject1: " + subject;
            Console.WriteLine(str);
            return str;
        }
        public static void Execute()
        {
            EventExample e = new EventExample();
            foreach (var d in e.myEvent.GetInvocationList())
            {
                Console.WriteLine(d.Method.Name);
            }
            string res = e.myEvent("Jack", "Science");
            Console.WriteLine("RESULT...\n" + res);
        }
    }
}
