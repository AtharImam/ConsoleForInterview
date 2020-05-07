using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ConsoleForInterview
{
    public class ComparerExample
    {
        public static void Execute()
        {
            TerimExcessExample();
        }

        public static void TerimExcessExample()
        {
            List<Employee> listEmp = new List<Employee>(100);
            listEmp.Add(new Employee() { Id = 10, Name = "abc" });
            listEmp.Add(new Employee() { Id = 5, Name = "dddd" });
            listEmp.Add(new Employee() { Id = 15, Name = "fff" });
            listEmp.Sort(new EmployeeComparer());
            Console.WriteLine("Currenct capacity : " + listEmp.Capacity);
            listEmp.TrimExcess();
            Console.WriteLine("Currenct capacity : " + listEmp.Capacity);
            listEmp.Add(new Employee() { Id = 15, Name = "fff" });
            listEmp.Add(new Employee() { Id = 15, Name = "fff" });
            listEmp.Add(new Employee() { Id = 15, Name = "fff" });
            listEmp.Add(new Employee() { Id = 15, Name = "fff" });
            listEmp.Add(new Employee() { Id = 15, Name = "fff" });
            listEmp.Add(new Employee() { Id = 15, Name = "fff" });
            Console.WriteLine("Currenct capacity : " + listEmp.Capacity);
            foreach (var e in listEmp)
            {
                Console.WriteLine("Id : {0}, Name : {1}", e.Id, e.Name);
            }
        }

        public class EmployeeComparer : IComparer<Employee>
        {
            public int Compare([AllowNull] Employee self, [AllowNull] Employee other)
            {
                if (other == null)
                {
                    return -1;
                }
                else if (self == null)
                {
                    return 1;
                }

                if (self.Id > other.Id)
                {
                    return -1;
                }
                else if (self.Id < other.Id)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }

        public class Employee : IComparable<Employee>
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public int CompareTo([AllowNull] Employee other)
            {
                if (other == null)
                {
                    return 1;
                }

                if(Id>other.Id)
                {
                    return 1;
                }else if(Id<other.Id)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
