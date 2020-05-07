using System;

namespace ConsoleApp1
{
    class ConstructorExample
    {
        public class EmployeeCon
        {
            public EmployeeCon() : this(string.Empty, string.Empty, string.Empty)
            {
                Console.WriteLine("Employee() constructor called");
            }

            public EmployeeCon(string Name, string EmpId) : this(Name, EmpId, string.Empty)
            {
                Console.WriteLine("Employee(Name,EmpId) constructor called");
            }

            public EmployeeCon(string Name, string EmpId, string Department)
            {
                Console.WriteLine("Employee(Name,EmpId,Department) constructor called");
            }

        }
    }
}
