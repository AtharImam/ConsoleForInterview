using System;
using System.Threading;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace ConsoleForInterview.Examples
{
    class UnityContainerTest
    {
        IUnityContainer container = new UnityContainer();
        public static void Execute()
        {
            UnityContainerTest test = new UnityContainerTest();
            test.Register();
            //test.TestExecute();
            //test.PerResolveInstance();
            test.ChildContainer();
            //test.TestDBContext();
        }

        void TestExecute()
        {
            //I2 i = container.Resolve<I2>();
            //i.Print();
            //container.Resolve<Driver>().RunCar();
            //container.Resolve<Driver>().RunCar();
            //this.ChildContainer();
            for(int i = 0; i < 5; i++)
            {
                Thread thread = new Thread(()=>
                {
                    container.Resolve<Driver>().RunCar();
                    container.Resolve<Driver>().RunCar();
                });
                thread.Start();
            }
        }

        void PerResolveInstance()
        {
            container.Resolve<IDriver>().RunCar();
            container.Resolve<IDriver>("Driver1").RunCar();
        }

        void Register()
        {
            //container.RegisterType<I1, A1>();
            //container.RegisterType<I1, B1>("B");
            //container.RegisterType<I2, C1>(new InjectionMethod("Inject", new B1()));
            //container.RegisterType<ICar, BMW>(new TransientLifetimeManager()); // for transient instance
            //container.RegisterType<ICar, BMW>(new ContainerControlledLifetimeManager()); // for singleton instance
            container.RegisterType<ICar, BMW>(new HierarchicalLifetimeManager()); //for child container instance
            //container.RegisterType<ICar, BMW>(new PerThreadLifetimeManager()); // for singleton instance per thread
            container.RegisterType<ICar, BMW>(TypeLifetime.PerResolve); // for singleton instance per resolve
            //container.RegisterType<IDriver, Driver>();
            //container.RegisterType<IDriver, Driver1>("Driver1");
        }

        void ChildContainer()
        {
            var childContainer = container.CreateChildContainer();
            container.Resolve<Driver>().RunCar();
            container.Resolve<Driver>().RunCar();
            Console.WriteLine("--------------------------------");
            childContainer.Resolve<Driver>().RunCar();
            childContainer.Resolve<Driver>().RunCar();
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

        public class Driver1 : IDriver
        {
            private ICar _car = null;

            public Driver1(ICar car, ICar car1)
            {
                //Console.WriteLine("Driver constructor called");
                _car = car;
                car1.Run();
            }

            public void RunCar()
            {
                Console.WriteLine("Running {0} - {1} mile ", _car.GetType().Name, _car.Run());
            }
        }

        public interface IDriver
        {
            void RunCar();
        }

        public class Driver : IDriver
        {
            private ICar _car = null;

            public Driver(ICar car, ICar car1)
            {
                //Console.WriteLine("Driver constructor called");
                _car = car;
                car1.Run();
            }

            public void RunCar()
            {
                Console.WriteLine("Running {0} - {1} mile ", _car.GetType().Name, _car.Run());
            }
        }

        interface I1
        {
            void Print();
        }

        class A1 : I1
        {
            public void Print()
            {
                Console.WriteLine("A1 Print");
            }
        }

        class B1 : I1
        {
            public void Print()
            {
                Console.WriteLine("B1 Print");
            }
        }


        interface I2
        {
            void Print();
        }

        class C1 : I2
        {
           // [Dependency]
            public I1 i;

            string name;

            //[InjectionConstructor]
            //public C1(string name)
            //{
            //    this.name = name;
            //}

            //[InjectionConstructor]
            //public C1(B1 i1)
            //{
            //    i = i1;
            //}

            [InjectionConstructor]
            public C1()
            {

            }

            [InjectionMethod]
            public void Inject(I1 i)
            {
                this.i = i;
            }

            public void Print()
            {
                if (i != null)
                {
                    i.Print();
                }

                Console.WriteLine("C1 Print");
            }
        }
    }
}
