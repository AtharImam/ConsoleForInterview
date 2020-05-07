using System;

namespace ConsoleForInterview
{
    class StructExample
    {
        public static void Execute()
        {
            Employee se1 = new Employee("Athar");
            IEmployee se2 = new Employee("Hello");
            se1.DisplayName();
            se2.DisplayName();
            se2 = se1;
            se2.DisplayName();
            se1.SetName("Imam");
            se1.DisplayName();
            se2.DisplayName();
        }

        interface I1
        {
            void DisplayName();
        }

        interface I2
        {
            void DisplayName();
        }

        interface IEmployee : I1, I2
        {
            void DisplayName();
        }

        struct Emp
        {
            string Addr { get; set; }
        }

        struct Employee : IEmployee //Emp, IEmployee can't inherit from class or struct type except interface, because struts by default sealed type.
        {
            public string Name;
            EmpCls cls;

            //public Employee() // cannot declare parameterless constructor
            //{
            //    cls = new EmpCls();
            //}

            public Employee(string name)
            {
                cls = new EmpCls();
                this.Name = name;
                cls.Name = name;
            }

            public void SetName(string name)
            {
                this.Name = name;
                cls.Name = name;
            }

            public void DisplayName()
            {
                Console.WriteLine($"Current Name is : {Name}");
                Console.WriteLine($"CLS Name is : {cls.Name}");
            }
        }

        class EmpCls
        {
            public string Name { get; set; }
        }

    }
}
