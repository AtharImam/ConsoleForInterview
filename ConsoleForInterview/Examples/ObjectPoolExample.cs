using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleForInterview
{
    public class ObjectPoolExample
    {
        public static void Execute()
        {
            //CancellationTokenSource cts = new CancellationTokenSource();

            //// Create an opportunity for the user to cancel.
            //Task.Run(() =>
            //{
            //    if (Console.ReadKey().KeyChar == 'c' || Console.ReadKey().KeyChar == 'C')
            //        cts.Cancel();
            //});

            //ObjectPool<MyClass> pool = new ObjectPool<MyClass>(() => new MyClass());

            //// Create a high demand for MyClass objects.
            //Parallel.For(0, 1000000, (i, loopState) =>
            //{
            //    MyClass mc = pool.GetObject();
            //    Console.CursorLeft = 0;
            //    // This is the bottleneck in our application. All threads in this loop
            //    // must serialize their access to the static Console class.
            //    Console.WriteLine("{0:####.####}", mc.GetValue(i));

            //    pool.PutObject(mc);
            //    if (cts.Token.IsCancellationRequested)
            //        loopState.Stop();
            //});
            //Console.WriteLine("Press the Enter key to exit.");
            //Console.ReadLine();
            //cts.Dispose();

            Factory fa = new Factory();
            Student myStu = fa.GetStudent();
            Console.WriteLine("First object");
            Student myStu1 = fa.GetStudent();
            Console.WriteLine("Second object");
            Student myStu2 = fa.GetStudent();
            Console.WriteLine("Third object");
            Student myStu3 = fa.GetStudent();
            Console.WriteLine("Fourth object");
            Student myStu4 = fa.GetStudent();
            Console.WriteLine("Fifth object");
            Console.Read();
        }
    }

    public class ObjectPool<T>
    {
        private ConcurrentBag<T> _objects;
        private Func<T> _objectGenerator;

        public ObjectPool(Func<T> objectGenerator)
        {
            if (objectGenerator == null) throw new ArgumentNullException("objectGenerator");
            _objects = new ConcurrentBag<T>();
            _objectGenerator = objectGenerator;
        }

        public T GetObject()
        {
            T item;
            Console.WriteLine("Called GetObject");
            Console.WriteLine("Total Objects In Collection before get : " + _objects.Count);
            if (_objects.TryTake(out item))
            {
                Console.WriteLine("Total Objects In Collection after get  : " + _objects.Count);
                return item;
            }

            Console.WriteLine("Total Objects In Collection after get  : " + _objects.Count);
            return _objectGenerator();
        }

        public void PutObject(T item)
        {
            Console.WriteLine("Called PutObject");
            Console.WriteLine("Total Objects In Collection before put : " + _objects.Count);
            _objects.Add(item);
            Console.WriteLine("Total Objects In Collection after put  : " + _objects.Count);
        }
    }

    // A toy class that requires some resources to create.
    // You can experiment here to measure the performance of the
    // object pool vs. ordinary instantiation.
    class MyClass
    {
        public int[] Nums { get; set; }
        public double GetValue(long i)
        {
            return Math.Sqrt(Nums[i]);
        }
        public MyClass()
        {
            Nums = new int[1000000];
            Random rand = new Random();
            for (int i = 0; i < Nums.Length; i++)
            {
                Nums[i] = rand.Next();
            }
        }
    }

    class Factory
    {
        // Maximum objects allowed!
        private static int _PoolMaxSize = 3;
        // My Collection Pool
        private static readonly Queue objPool = new Queue(_PoolMaxSize);
        public Student GetStudent()
        {
            Student oStudent;
            // Check from the collection pool. If exists, return
            // object; else, create new
            if (Student.ObjectCounter >= _PoolMaxSize &&
               objPool.Count > 0)
            {
                // Retrieve from pool
                oStudent = RetrieveFromPool();
            }
            else
            {
                oStudent = GetNewStudent();
            }

            return oStudent;
        }
        private Student GetNewStudent()
        {
            // Creates a new Student
            Student oStu = new Student();
            objPool.Enqueue(oStu);
            return oStu;
        }
        protected Student RetrieveFromPool()
        {
            Student oStu;
            // Check if there are any objects in my collection
            if (objPool.Count > 0)
            {
                oStu = (Student)objPool.Dequeue();
                Student.ObjectCounter--;
            }
            else
            {
                // Return a new object
                oStu = new Student();
            }

            return oStu;
        }
    }
    class Student
    {
        public static int ObjectCounter = 0;
        public Student()
        {
            ++ObjectCounter;
        }
        private string _Firstname;
        private string _Lastname;
        private int _RollNumber;
        private string _Class;


        public string Firstname
        {
            get
            {
                return _Firstname;
            }
            set
            {
                _Firstname = value;
            }
        }

        public string Lastname
        {
            get
            {
                return _Lastname;
            }
            set
            {
                _Lastname = value;
            }
        }

        public string Class
        {
            get
            {
                return _Class;
            }
            set
            {
                _Class = value;
            }
        }

        public int RollNumber
        {
            get
            {
                return _RollNumber;
            }
            set
            {
                _RollNumber = value;
            }
        }
    }
}
