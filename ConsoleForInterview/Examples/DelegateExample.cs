using System;
using System.IO;
using System.Threading;

namespace ConsoleForInterview
{
    class DelegateExample
    {
        public static void Execute()
        {

        }

        public static void Test3()
        {
            // Create a new clock
            Clock theClock = new Clock();

            // Create the display and tell it to
            // subscribe to the clock just created
            DisplayClock dc = new DisplayClock();
            dc.Subscribe(theClock);

            // Create a Log object and tell it
            // to subscribe to the clock
            LogClock lc = new LogClock();
            lc.Subscribe(theClock);

            // Get the clock started
            theClock.Run();
        }

        public static void Test2()
        {
            MyClass myClass = new MyClass();

            FileLogger fl = new FileLogger("process.log");

            //MyClass.LogHandler myLogger = null;
            //myLogger += new MyClass.LogHandler(Logger);
            //myLogger += new MyClass.LogHandler(fl.Logger);
            //myClass.Process(myLogger);

            myClass.Log += new MyClass.LogHandler(Logger);
            myClass.Log += new MyClass.LogHandler(fl.Logger);
            myClass.Process();
            fl.Close();
        }

        static void Logger(string s)
        {
            Console.WriteLine(s);
        }

        static void Test1()
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

        public class MyClass
        {
            // Declare a delegate that takes a single string parameter
            // and has no return type.
            public delegate void LogHandler(string message);

            public event LogHandler Log;

            // The use of the delegate is just like calling a function directly,
            // though we need to add a check to see if the delegate is null
            // (that is, not pointing to a function) before calling the function.
            public void Process(LogHandler logHandler)
            {
                if (logHandler != null)
                {
                    logHandler("Process() begin");
                }

                if (logHandler != null)
                {
                    logHandler("Process() end");
                }
            }

            public void Process()
            {
                OnLog("Process() begin");
                OnLog("Process() end");
            }

            protected void OnLog(string message)
            {
                if (Log != null)
                {
                    Log(message);
                }
            }
        }

        public class FileLogger
        {
            FileStream fileStream;
            StreamWriter streamWriter;

            // Constructor
            public FileLogger(string filename)
            {
                fileStream = new FileStream(filename, FileMode.OpenOrCreate);
                streamWriter = new StreamWriter(fileStream);
            }

            // Member Function which is used in the Delegate
            public void Logger(string s)
            {
                streamWriter.WriteLine(s);
            }

            public void Close()
            {
                streamWriter.Close();
                fileStream.Close();
            }
        }

        /* ======================= Event Publisher =============================== */

        // Our subject -- it is this class that other classes
        // will observe. This class publishes one event:
        // SecondChange. The observers subscribe to that event.
        public class Clock
        {
            // Private Fields holding the hour, minute and second
            private int _hour;
            private int _minute;
            private int _second;

            // The delegate named SecondChangeHandler, which will encapsulate
            // any method that takes a clock object and a TimeInfoEventArgs
            // object as the parameter and returns no value. It's the
            // delegate the subscribers must implement.
            public delegate void SecondChangeHandler(object clock, TimeInfoEventArgs timeInformation);

            // The event we publish
            public event SecondChangeHandler SecondChange;

            // The method which fires the Event
            protected void OnSecondChange(object clock, TimeInfoEventArgs timeInformation)
            {
                // Check if there are any Subscribers
                // Call the Event
                SecondChange?.Invoke(clock, timeInformation);
            }

            // Set the clock running, it will raise an
            // event for each new second
            public void Run()
            {
                for (; ; )
                {
                    // Sleep 1 Second
                    Thread.Sleep(1000);

                    // Get the current time
                    DateTime dt = DateTime.Now;

                    // If the second has changed
                    // notify the subscribers
                    if (dt.Second != _second)
                    {
                        // Create the TimeInfoEventArgs object
                        // to pass to the subscribers
                        TimeInfoEventArgs timeInformation = new TimeInfoEventArgs(dt.Hour, dt.Minute, dt.Second);

                        // If anyone has subscribed, notify them
                        OnSecondChange(this, timeInformation);
                    }

                    // update the state
                    _second = dt.Second;
                    _minute = dt.Minute;
                    _hour = dt.Hour;
                }
            }
        }

        // The class to hold the information about the event
        // in this case it will hold only information
        // available in the clock class, but could hold
        // additional state information
        public class TimeInfoEventArgs : EventArgs
        {
            public TimeInfoEventArgs(int hour, int minute, int second)
            {
                this.hour = hour;
                this.minute = minute;
                this.second = second;
            }

            public readonly int hour;
            public readonly int minute;
            public readonly int second;
        }

        /* ======================= Event Subscribers =============================== */

        // An observer. DisplayClock subscribes to the
        // clock's events. The job of DisplayClock is
        // to display the current time
        public class DisplayClock
        {
            // Given a clock, subscribe to
            // its SecondChangeHandler event
            public void Subscribe(Clock theClock)
            {
                theClock.SecondChange += TimeHasChanged;
            }

            // The method that implements the
            // delegated functionality
            public void TimeHasChanged(object theClock, TimeInfoEventArgs ti)
            {
                Console.WriteLine("Current Time: {0}:{1}:{2}", ti.hour.ToString(), ti.minute.ToString(), ti.second.ToString());
            }
        }

        // A second subscriber whose job is to write to a file
        public class LogClock
        {
            public void Subscribe(Clock theClock)
            {
                theClock.SecondChange += WriteLogEntry;
            }

            // This method should write to a file
            // we write to the console to see the effect
            // this object keeps no state
            public void WriteLogEntry(object theClock, TimeInfoEventArgs ti)
            {
                Console.WriteLine("Logging to file: {0}:{1}:{2}", ti.hour.ToString(), ti.minute.ToString(), ti.second.ToString());
            }
        }
    }
}
