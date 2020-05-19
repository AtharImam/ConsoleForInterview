using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.EntitySql;
using System.Threading;
using System.Xml.Schema;

namespace ConsoleForInterview
{
    public class CovAndCotraExample
    {
        static void SetObject(object obj)
        {
            Console.WriteLine(obj + " Called");
        }

        static string GetString()
        {
            return "GetString called";
        }
        
        public static void Test()
        {
            // Covariance. A delegate specifies a return type as object,  
            // but you can assign a method that returns a string.  
            Func<object> del = GetString;
            Console.WriteLine(del.Invoke());

            // Contravariance. A delegate specifies a parameter type as string,  
            // but you can assign a method that takes an object.  
            Action<string> del2 = SetObject;
            del2.Invoke("SetObject");
        }

        delegate T CovFactory<out T>(string name, int legs);

        delegate T CovFactory<out T, out T1>(out Animal T1,string name, int legs);

        delegate void ConFactory<in T>(T t);

        public static void Execute()
        {
            CovFactory<Animal> ani = new CovFactory<Dog>((name, legs) =>
            {
                Dog dog = new Dog() { Name = name, NumberOfLegs = legs };
                return dog;
            });

            CovFactory<Animal, Animal> ant = (out Animal T1, string name, int legs) =>
            {
                T1 = new Dog();
                return T1;
            };

            ani.Invoke("Puppy", 4).Display();
            Console.WriteLine("**********************");
            ConFactory<Dog> dog = new ConFactory<Animal>(param =>
              {
                  param.Display();
              });

            dog.Invoke(new Dog() { Name = "Tommy", NumberOfLegs = 4 });
        }

        private static Animal Method(out Animal T1, string name, int legs)
        {
            throw new NotImplementedException();
        }

        Dog MakeDog(string name, int legs)
        {
            Dog dog = new Dog() { Name = name, NumberOfLegs = legs };
            return dog;
        }

        public static void Execute1()
        {
            // Assignment compatibility.
            string str = "test";
            // An object of a more derived type is assigned to an object of a less derived type.
            object obj = str;

            // Covariance.
            IEnumerable<string> strings = new List<string>();

            // An object that is instantiated with a more derived type argument
            // is assigned to an object instantiated with a less derived type argument.
            // Assignment compatibility is preserved.
            IEnumerable<object> objects = strings;

            // Contravariance.
            // Assume that the following method is in the class:
            // static void SetObject(object o) { }
            Action<object> actObject = (obj) => { };

            // An object that is instantiated with a less derived type argument
            // is assigned to an object instantiated with a more derived type argument.
            // Assignment compatibility is reversed.
            Action<string> actString = actObject;
        }

        public class Animal
        {
            public Animal()
            {
                Console.WriteLine("Animal Called");
            } 

            public int NumberOfLegs = 4;

            public virtual void Display()
            {
                Console.WriteLine("Number of legs: " + NumberOfLegs);
            }
        }

        public class Dog : Animal
        {
            public Dog()
            {
                Console.WriteLine("Dog Called");
            }

            public string Name { get; set; }

            public override void Display()
            {
                Console.WriteLine($"Name: {Name}, Number of legs: {NumberOfLegs}");
            }
        }
    }

    public class MoreGenericCovariance
    {
        // Covariant interface.
        interface ICovariant<out R> { }

        // Extending covariant interface.
        interface IExtCovariant<out R> : ICovariant<R> { }

        // Implementing covariant interface.
        class Sample<R> : ICovariant<R> { }

        public static void Execute()
        {
            ICovariant<Animal> iobj = new Sample<Animal>();
            ICovariant<Dog> istr = new Sample<Dog>();

            // You can assign istr to iobj because
            // the ICovariant interface is covariant.
            iobj = istr;
        }

        public class Animal
        {
            public int NumberOfLegs = 4;
        }

        public class Dog : Animal
        {
        }
    }

    public class MoreGenericContravariance
    {
        // Contravariant interface.
        interface IContravariant<in A> { }

        // Extending contravariant interface.
        interface IExtContravariant<in A> : IContravariant<A> { }

        // Implementing contravariant interface.
        class Sample<A> : IContravariant<A> { }

        public static void Execute()
        {
            IContravariant<Animal> iobj = new Sample<Animal>();
            IContravariant<Dog> istr = new Sample<Dog>();

            // You can assign iobj to istr because
            // the IContravariant interface is contravariant.
            istr = iobj;
        }

        public class Animal
        {
            public int NumberOfLegs = 4;
        }

        public class Dog : Animal
        {
        }
    }
}
