using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleForInterview.Examples
{
    public class IEquatableExample
    {
        public static void Execute()
        {
            Person p1 = new Person() { Id = 1, Name = "Athar" };
            Person p2 = new Person() { Id = 1, Name = "Imam" };
            Console.WriteLine(p1.Equals(p2));
        }

        private class Person : IEquatable<Person>
        {
            public int Id { get; set; }

            public string Name { get; set; }
           
            public bool Equals(Person obj)
            {
                return this.Id == (obj as Person).Id;
            }

            public override int GetHashCode()
            {
                return Id;
            }
        }
    }
}
