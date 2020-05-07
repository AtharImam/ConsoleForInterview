using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime;

namespace ConsoleApp1
{
    class ExtraExample
    {
        public static void DefaultContructorInfo()
        {
            Type type = typeof(Customer);
            ConstructorInfo ci = type.GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public, null, Type.EmptyTypes, null);
            Console.WriteLine("Is Construcot: "+ci.IsConstructor);
            Console.WriteLine("Is Public: " + ci.IsPublic);
        }
        class Customer
        {
        }

        public static void ReverseEachWorkExample()
        {
            string str = "One Two Three Four Five";
            Console.WriteLine(str);
            string newStr = string.Join(" ", str.Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(x => new string(x.Reverse().ToArray())));
            Console.WriteLine(newStr);
        }

        public static void GCInstance()
        {

            string result = string.Empty;
            if (GCSettings.IsServerGC == true)
                result = "server";
            else
                result = "workstation";
            Console.WriteLine("The {0} garbage collector is running.", result);
        }

        static void MaxWordCount()
        {
            string str = "hello athar athar hello name what hello";
            string[] arrStr = str.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            List<string> list = new List<string>();
            string current = string.Empty;
            int count = 0;
            foreach (string str1 in arrStr)
            {
                if (list.IndexOf(str1) > -1)
                {
                    continue;
                }

                int localCount = 0;
                foreach (string str2 in arrStr)
                {
                    if (str1 == str2)
                    {
                        localCount++;
                    }
                }

                if (localCount > count)
                {
                    count = localCount;
                    current = str1;
                }
            }

            Console.WriteLine("{0} {1}", current, count);
        }

        static void EnumerableExaple()
        {
            List<int> listInt = new List<int> { 1, 34, 2, 6, 32 };

            IEnumerable<int> enumerable = listInt;
            foreach (int i in enumerable)
            {
                Console.WriteLine("Enumerable : " + i);
            }

            Console.WriteLine("*******************");

            IEnumerator<int> enumerator = enumerable.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine("Enumerator : " + enumerator.Current);
            }
        }

        static void CompareExample()
        {
            List<Employee> empList = new List<Employee>();
            empList.Add(new Employee() { FirstName = "Athar", SecondName = "Imam", Salary = 2000 });
            empList.Add(new Employee() { FirstName = "Afeefah", SecondName = "Athar", Salary = 1000 });
            empList.Add(new Employee() { FirstName = "Aliya", SecondName = "Anjuman", Salary = 2500 });
            empList.Add(new Employee() { FirstName = "Mazhar", SecondName = "Imam", Salary = 1500 });
            empList.Add(new Employee() { FirstName = "Anjuman", SecondName = "Shaheen", Salary = 3000 });

            empList.Sort();

            foreach (var emp in empList)
            {
                Console.WriteLine(emp.ToString());
            }
        }
    }

    public class Employee : IComparable<Employee>
    {
        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public int Salary { get; set; }

        public int CompareTo(Employee other)
        {
            //return this.FirstName.CompareTo(other.FirstName);
            if (this.Salary > other.Salary)
            {
                return 1;
            }
            else if (this.Salary < other.Salary)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", FirstName, SecondName, Salary);
        }
    }

    public class EmployeeComparer : IComparer<Employee>
    {
        public int Compare(Employee x, Employee y)
        {
            return x.FirstName.CompareTo(y.FirstName);
        }
    }

    public class PublicClass
    {
        protected string String1 { get; set; }

        protected internal string String2 { get; set; }

        protected private string String3 { get; set; }
    }

    internal class InternalClass : PublicClass
    {
        public InternalClass()
        {
            this.String2 = "";
            this.String3 = "";
            PublicClass pc = new PublicClass();

        }
    }
}
