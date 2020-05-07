using System;

namespace ConsoleForInterview
{
    public class InheritanceExample
    {
        public static void Execute()
        {
            //Employee partTime = new ParttimeEmployee("Athar");
            //partTime.DisplayName();

            //FulltimeEmployee fullTime = new FulltimeEmployee("Imam");
            //fullTime.DisplayName();

            BaseClass bc = new SecondChild();
            Console.WriteLine("BaseClass bc = new SecondChild(): " + bc.GetMethod());

            DerivedClass dc = new SecondChild();
            Console.WriteLine("DerivedClass dc = new SecondChild(): " + dc.GetMethod());

            SecondChild sc = new SecondChild();
            Console.WriteLine("SecondChild sc = new SecondChild(): " + sc.GetMethod());
        }

        public class BaseClass
        {
            public virtual string GetMethod()
            {
                return "Base Class";
            }
        }
        public class DerivedClass : BaseClass
        {
            public new virtual string GetMethod()
            {
                return "DerivedClass";
            }
        }
        public class SecondChild : DerivedClass
        {
            public override string GetMethod()
            {
                return "Second level Child";
            }
        }

        public class Employee
        {
            public string Name { get; protected set; }

            public virtual void DisplayName()
            {
                Console.WriteLine("Base Employee : " + Name);
            }
        }

        public class ParttimeEmployee : Employee
        {
            public ParttimeEmployee(string name)
            {
                this.Name = name;
                Console.WriteLine("Parttime default constructor");
            }

            //public ParttimeEmployee(string name):this()
            //{
            //    this.Name = name;
            //    Console.WriteLine("Parttime paremeterized constructor");
            //}

            public void SetName(string name)
            {
                this.Name = name;
            }

            public new void DisplayName()
            {
                Console.WriteLine("Parttime Employee : " + Name);
            }
        }

        public class FulltimeEmployee : Employee
        {
            public FulltimeEmployee(string name)
            {
                this.Name = name;
            }
            public override void DisplayName()
            {
                Console.WriteLine("Fulltime Employee : " + Name);
            }
        }
    }
}
