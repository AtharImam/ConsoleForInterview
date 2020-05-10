using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleForInterview
{
    public class DynamicVsObject
    {
        public static void Execute()
        {
            object a = "Rohatash Kumar";
            string a1 = a.ToString();

            dynamic d = "Athar Imam";
            string a2 = d;

            dynamic d1 = 12;
            string a3 = d1;
        }
    }
}
