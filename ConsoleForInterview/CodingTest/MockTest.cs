using System;
using Unity;

namespace ConsoleForInterview.CodingTest
{
    public class MockTest
    {
        ICar car;
        public MockTest(IUnityContainer container)
        {
            car = container.Resolve<ICar>();
        }

        public int DoRun()
        {
            return car.Run();
        }

        public interface ICar
        {
            int Run();
        }

        public class BMW : ICar
        {
            private int _miles = 0;

            public BMW()
            {
                Console.WriteLine("BMW constructor called");
            }

            public int Run()
            {
                return ++_miles;
            }
        }

        public class Ford : ICar
        {
            private int _miles = 0;

            public Ford()
            {
                Console.WriteLine("Ford constructor called");
            }

            public int Run()
            {
                return ++_miles;
            }
        }

        public class Audi : ICar
        {
            private int _miles = 0;

            public Audi()
            {
                Console.WriteLine("Audi constructor called");
            }

            public int Run()
            {
                return ++_miles;
            }
        }
    }
}
