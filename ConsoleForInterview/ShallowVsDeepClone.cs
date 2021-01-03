using System;
using System.Text.Json;

namespace ConsoleForInterview
{
    public static class ShallowVsDeepClone
    {
        public static void Execute()
        {
            ShallowCopyExample();
            Console.WriteLine("------------------------------------------");
            DeepCopyExample();
        }

        static void ShallowCopyExample()
        {
            Person pers1 = new Person() { Id = 1, Name = "Athar", Address = new Address { Place = "Delhi" } };
            Person pers2 = pers1.Clone() as Person;
            Console.WriteLine("Shallow Copy Example");
            Console.WriteLine("Before Changing Name and Address ");
            Console.WriteLine($"Person1 Name: {pers1.Name}, Address: {pers1.Address.Place}");
            Console.WriteLine($"Person2 Name: {pers2.Name}, Address: {pers2.Address.Place}");
            pers2.Name = "Imam";
            pers2.Address.Place = "Gurugram";
            Console.WriteLine("After Changing Name and Address ");
            Console.WriteLine($"Person1 Name: {pers1.Name}, Address: {pers1.Address.Place}");
            Console.WriteLine($"Person2 Name: {pers2.Name}, Address: {pers2.Address.Place}");
        }

        static void DeepCopyExample()
        {
            Person pers1 = new Person() { Id = 1, Name = "Athar", Address = new Address { Place = "Delhi" } };
            Person pers2 = JsonSerializer.Deserialize<Person>(JsonSerializer.Serialize(pers1));
            Console.WriteLine("Deep Copy Example");
            Console.WriteLine("Before Changing Name and Address ");
            Console.WriteLine($"Person1 Name: {pers1.Name}, Address: {pers1.Address.Place}");
            Console.WriteLine($"Person2 Name: {pers2.Name}, Address: {pers2.Address.Place}");
            pers2.Name = "Imam";
            pers2.Address.Place = "Gurugram";
            Console.WriteLine("After Changing Name and Address ");
            Console.WriteLine($"Person1 Name: {pers1.Name}, Address: {pers1.Address.Place}");
            Console.WriteLine($"Person2 Name: {pers2.Name}, Address: {pers2.Address.Place}");
        }

        [Serializable]
        class Person : ICloneable
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public Address Address { get; set; }

            public object Clone()
            {
                return this.MemberwiseClone();
            }
        }

        class Address
        {
            public string Place { get; set; }
        }
    }
}
