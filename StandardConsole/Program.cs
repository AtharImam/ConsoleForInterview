using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandardConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            YieldExample.Execute();
            //YieldExample yie = new YieldExample();
            //yie.AddEvent += Yie_AddEvent;
            //yie.ShowNumber();
        }

        private static int Yie_AddEvent(int num)
        {
            num += 10;
            return num;
        }

        public static void ChangeNumber(int? num)
        {
            num = 10;
        }
    }
}
