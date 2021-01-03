using System;

namespace ConsoleForInterview
{
    public class GenericStackExample
    {
        public static void Execute()
        {
            MyStack<Employee> stack = new MyStack<Employee>();
            stack.Push(new Employee() { Name = "One" });
            stack.Push(new Employee() { Name = "Two" });
            stack.Push(new Employee() { Name = "Three" });
            stack.Push(new Employee() { Name = "Four" });

            Console.WriteLine($"Name : {stack.Pop().Name}, Count:{stack.top}");
            Console.WriteLine($"Name : {stack.Pop().Name}, Count:{stack.top}");
            Console.WriteLine($"Name : {stack.Pop().Name}, Count:{stack.top}");
            Console.WriteLine($"Name : {stack.Pop().Name}, Count:{stack.top}");
            Console.WriteLine($"Name : {stack.Pop().Name}, Count:{stack.top}");
        }
    }

    public class MyStack<T> where T : class
    {
        static readonly int MAX = Int32.MaxValue-1;
        public int top { get; private set; }
        T[] stack = new T[MAX];

        bool IsEmpty()
        {
            return (top < 0);
        }
        public MyStack()
        {
            top = -1;
        }
        public bool Push(T data)
        {
            if (top >= MAX)
            {
                Console.WriteLine("Stack Overflow");
                return false;
            }
            else
            {
                stack[++top] = data;
                return true;
            }
        }

        internal T Pop()
        {
            if (top < 0)
            {
                Console.WriteLine("Stack Underflow");
                return null;
            }
            else
            {
                T value = stack[top--];
                return value;
            }
        }

        internal void Peek()
        {
            if (top < 0)
            {
                Console.WriteLine("Stack Underflow");
                return;
            }
            else
                Console.WriteLine("The topmost element of Stack is : {0}", stack[top]);
        }

        internal void PrintStack()
        {
            if (top < 0)
            {
                Console.WriteLine("Stack Underflow");
                return;
            }
            else
            {
                Console.WriteLine("Items in the Stack are :");
                for (int i = top; i >= 0; i--)
                {
                    Console.WriteLine(stack[i]);
                }
            }
        }
    }

    class Employee
    {
        public string Name { get; set; }
    }
}
