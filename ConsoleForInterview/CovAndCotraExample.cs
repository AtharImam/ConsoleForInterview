using System;
using System.Collections.Generic;

namespace ConsoleForInterview
{
    public class CovAndCotraExample
    {
        static object GetObject() { return null; }
        static void SetObject(object obj) { }

        static string GetString() { return ""; }
        static void SetString(string str) { }

        static void Test()
        {
            // Covariance. A delegate specifies a return type as object,  
            // but you can assign a method that returns a string.  
            Func<object> del = GetString;

            // Contravariance. A delegate specifies a parameter type as string,  
            // but you can assign a method that takes an object.  
            Action<string> del2 = SetObject;
        }

        //delegate T Factory<T>();//delegate Factory // produces error.
        delegate T Factory<out T>();//out is the Keyword for contravariance

        delegate void Action1<in T>(T a);//in is the Keyword for contravariance

        static Dog MakeDog()//Method that matches delegate Factory
        {
            return new Dog();
        }

        public static void Execute()
        {
            //////Covariance
            Factory<Dog> dogMaker = MakeDog;//Create delegate object.
            Factory<Animal> animalMaker = dogMaker;   //Attempt to assign delegate object.
            Console.WriteLine(animalMaker().NumberOfLegs.ToString());


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
            public int NumberOfLegs = 4;
        }

        public class Dog : Animal
        {
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
