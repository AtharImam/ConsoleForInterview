using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleForInterview
{
    public class ArrayExample
    {
        List<Employee> empList = null;
        Employee[] empArray = null;
        public static void Execute()
        {
            ArrayExample ars = new ArrayExample();
            Console.WriteLine("List to dictionary-----------------");
            ars.CreateList();
            var dict1 = ars.ListToDictionary();
            foreach(KeyValuePair<int,Employee> kvp in dict1)
            {
                Console.WriteLine($"Id: {kvp.Key} Name: {kvp.Value.Name}");
            }

            Console.WriteLine("\n\nArray to dictionary-----------------");
            ars.CreateArray();
            var dict2 = ars.ArrayToDictionary();
            foreach (KeyValuePair<int, Employee> kvp in dict2)
            {
                Console.WriteLine($"Id: {kvp.Key} Name: {kvp.Value.Name}");
            }
        }

        void CreateList()
        {
            empList = new List<Employee>();
            empList.Add(new Employee { Id = 1, Name = "Athar" });
            empList.Add(new Employee { Id = 2, Name = "Imam" });
            empList.Add(new Employee { Id = 3, Name = "Afeefah" });
            empList.Add(new Employee { Id = 4, Name = "Anjuman" });
            empList.Add(new Employee { Id = 5, Name = "Aliya" });
            empList.Add(new Employee { Id = 6, Name = "Talta" });
            empList.Add(new Employee { Id = 7, Name = "Chand" });
        }

        Dictionary<int,Employee>  ListToDictionary()
        {
            var dict = empList.ToDictionary(x => x.Id, y => y);
            return dict;
        }

        void CreateArray()
        {
            empArray = new Employee[7];
            empArray[0] = new Employee { Id = 1, Name = "Athar" };
            empArray[1] = new Employee { Id = 2, Name = "Imam" };
            empArray[2] = new Employee { Id = 3, Name = "Afeefah" };
            empArray[3] = new Employee { Id = 4, Name = "Anjuman" };
            empArray[4] = new Employee { Id = 5, Name = "Aliya" };
            empArray[5] = new Employee { Id = 6, Name = "Talta" };
            empArray[6] = new Employee { Id = 7, Name = "Chand" };
        }

        Dictionary<int, Employee> ArrayToDictionary()
        {
            var dict = empArray.ToDictionary(x => x.Id, y => y);
            return dict;
        }

        class Employee
        {
            public int Id { get; set; }

            public string Name { get; set; }
        }
    }
}
