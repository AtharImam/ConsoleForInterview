using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace ConsoleForInterview.Examples
{
    public class IComparerVsIComparable
    {
        public static void Execute()
        {
            List<Person> pers = new List<Person>()
            {
                new Person(){Id=5,Name="Athar" },
                new Person(){Id=3,Name="Imam" },
                new Person(){Id=15,Name="Aliya" },
                new Person(){Id=10,Name="Anjuman" }
            };

            pers.Sort();
            foreach (Person p in pers)
            {
                Console.WriteLine($"Id: {p.Id}, Name: {p.Name}");
            }

            Console.WriteLine("------------------------------");
            pers.Sort(new PersonComparer());
            foreach (Person p in pers)
            {
                Console.WriteLine($"Id: {p.Id}, Name: {p.Name}");
            }
        }

        private class PersonComparer : IComparer<Person>
        {
            public int Compare([AllowNull] Person x, [AllowNull] Person y)
            {
                return x.Id > y.Id ? -1 : 1;
            }
        }

        private class Person : IComparable<Person>
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public int CompareTo([AllowNull] Person other)
            {
                return this.Id > other.Id ? 1 : -1;
            }
        }
    }
}
