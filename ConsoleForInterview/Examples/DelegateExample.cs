using System;

namespace ConsoleForInterview
{
    class DelegateExample
    {
        public static void Execute()
        {
            Student st = new Student("Athar");
            Teacher tchr = new Teacher();
            tchr.Display(st.Display);
            DeplayName pn1 = new DeplayName(PrintName);
            DeplayName pn2 = new DeplayName(PrintName);
            DeplayName pn3 = new DeplayName(PrintName);
            DeplayName pn4 = new DeplayName(PrintName);
            DeplayName pn5 = pn1 + pn2 + pn3 + pn4;
            pn5();
        }

        static void PrintName()
        {
            Console.WriteLine("Print name executed");
        }

        delegate void DeplayName();

        class Student
        {
            public string Name { get; set; }

            public Student(string name)
            {
                this.Name = name;
            }

            public void Display()
            {
                Console.WriteLine("Name is : " + Name);
            }
        }

        class Teacher
        {
            public void Display(DeplayName disp)
            {
                disp.Invoke();
            }
        }
    }
}
