using Ninject;
using Ninject.Modules;
using System;
using System.Reflection;

namespace ConsoleForInterview
{
    public class NinjectExample
    {
        public static void Execute()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());
            var testInject = kernel.Get<ITestNinject>();
            testInject.LogString("Write Log");
            testInject.WriteToFile("Write File");
            testInject.SendMail("Send Mail");
        }
    }

    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<ITestNinject>().To<TestInject>();
            Bind<IMailSender>().To<MockMailSender>();
            Bind<ILogWriter>().To<MockLogWriter>();
            Bind<IFileWriter>().To<MockFileWriter>();
        }
    }

    public interface ITestNinject
    {
        void SendMail(string content);

        void LogString(string content);

        void WriteToFile(string content);
    }

    public class TestInject : ITestNinject
    {
        private IFileWriter fileWriter;

        private IMailSender mailSender;

        [Inject]
        public ILogWriter Logger { get; set; }

        public TestInject(IFileWriter fileWriter)
        {
            this.fileWriter = fileWriter;
        }

        public void LogString(string content)
        {
            Console.WriteLine("Test Inject Log Writer");
            Logger.WriteLog(content);
        }

        [Inject]
        public void SetMailSender(IMailSender mailSender)
        {
            Console.WriteLine("Test Inject Mail Sender");
            this.mailSender = mailSender;
        }
        
        public void SendMail(string content)
        {
            Console.WriteLine("Mail Send");
            mailSender.Send(content);
        }

        public void WriteToFile(string content)
        {
            Console.WriteLine("Test Inject File Write");
            fileWriter.WriteToFile(content);
        }
    }

    public interface IMailSender
    {
        void Send(string str);
    }

    public class MockMailSender : IMailSender
    {
        public MockMailSender()
        {
            Console.WriteLine("Mail Sender Constructor Called");
        }
        public void Send(string str)
        {
            Console.WriteLine("Mock Mail Sender");
        }
    }

    public interface ILogWriter
    {
        void WriteLog(string str);
    }

    public class MockLogWriter : ILogWriter
    {
        public MockLogWriter()
        {
            Console.WriteLine("Log Writer Constructor Called");
        }

        public void WriteLog(string str)
        {
            Console.WriteLine("Mock Log Writer");
        }
    }

    public interface IFileWriter
    {
        void WriteToFile(string str);
    }

    public class MockFileWriter : IFileWriter
    {
        public MockFileWriter()
        {
            Console.WriteLine("File Writer Constructor Called");
        }

        public void WriteToFile(string str)
        {
            Console.WriteLine("Mock File Writer");
        }
    }
}
