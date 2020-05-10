
using ConsoleForInterview.Examples;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace ConsoleForInterview
{
    class Program
    {
        static void Main(string[] args)
        {
            List<empl> list = new List<empl> {
            new empl{ Name="Athar"},
            new empl{ Name="Imam"},
            new empl{ Name="Athar"},
            new empl{ Name="Shaheen"}
            };
            var cnt1 = list.Find(item => item.Name == "Athar");
            var cnt2 = list.Find(item => item.Name == "SSSSS");
            var cnt3 = list.FindAll(item => item.Name=="Athar");
            var cnt4 = list.Where(item => item.Name == "SSSSS");
            
            Console.Read();
        }

        class empl
        {
            public string Name { get; set; }
        }
    }
}
