using System;

namespace ConsoleForInterview
{
    public class StringEqualsExample
    {
        public static void Execute()
        {
            string s1 = "human";
            string s2 = "human";
            char[] arr = { 'h', 'u', 'm', 'a', 'n' };
            string s3 = new string(arr);
            string s4 = new string(arr);

            Console.WriteLine("s1==s2 {0}", s1 == s2);
            Console.WriteLine("s1.euals(s2) {0}", s1.Equals(s2));
            Console.WriteLine("s3==s4 {0}", s3 == s4);
            Console.WriteLine("s3.equals(s4) {0}", s3.Equals(s4));
            Console.WriteLine("s1==s3 {0}", s1 == s3);
            Console.WriteLine("s1.eqals(s3) {0}", s1.Equals(s3));
            Console.WriteLine("s3.eqals(s1) {0}", s3.Equals(s1));
        }
    }
}
