using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace ConsoleForInterview
{
    public class PubSubEventAggregator
    {
        public static void Execute()
        {
            EventAggregator eve = new EventAggregator();
            Publisher pub = new Publisher(eve);
            Subscriber sub = new Subscriber(eve);

            pub.PublishMessage();
            Console.ReadLine();
        }

        public class Subscription<TMessage> : IDisposable
        {
            public readonly MethodInfo MethodInfo;
            private readonly EventAggregator EventAggregator;
            public readonly WeakReference TargetObjet;
            public readonly bool IsStatic;

            private bool isDisposed;
            public Subscription(Action<TMessage> action, EventAggregator eventAggregator)
            {
                MethodInfo = action.Method;
                if (action.Target == null)
                {
                    IsStatic = true;
                }

                TargetObjet = new WeakReference(action.Target);
                EventAggregator = eventAggregator;
            }

            ~Subscription()
            {
                if (!isDisposed)
                {
                    Dispose();
                }
            }

            public void Dispose()
            {
                EventAggregator.UnSbscribe(this);
                isDisposed = true;
            }

            public Action<TMessage>? CreatAction()
            {
                if (TargetObjet.Target != null && TargetObjet.IsAlive)
                {
                    return (Action<TMessage>)Delegate.CreateDelegate(typeof(Action<TMessage>), TargetObjet.Target, MethodInfo);
                }

                if (this.IsStatic)
                {
                    return (Action<TMessage>)Delegate.CreateDelegate(typeof(Action<TMessage>), MethodInfo);
                }

                return null;
            }
        }

        public class EventAggregator
        {
            private readonly object lockObj = new object();
            private readonly Dictionary<Type, IList> subscriber;

            public EventAggregator()
            {
                subscriber = new Dictionary<Type, IList>();
            }

            public void Publish<TMessageType>(TMessageType message)
            {
                Type t = typeof(TMessageType);
                IList sublst;
                if (subscriber.ContainsKey(t))
                {
                    lock (lockObj)
                    {
                        sublst = new List<Subscription<TMessageType>>(subscriber[t].Cast<Subscription<TMessageType>>());
                    }

                    foreach (Subscription<TMessageType> sub in sublst)
                    {
                        sub.CreatAction()?.Invoke(message);
                    }
                }
            }

            public Subscription<TMessageType> Subscribe<TMessageType>(Action<TMessageType> action)
            {
                Type t = typeof(TMessageType);
                IList actionlst;
                var actiondetail = new Subscription<TMessageType>(action, this);

                lock (lockObj)
                {
                    if (!subscriber.TryGetValue(t, out actionlst))
                    {
                        actionlst = new List<Subscription<TMessageType>>();
                        actionlst.Add(actiondetail);
                        subscriber.Add(t, actionlst);
                    }
                    else
                    {
                        actionlst.Add(actiondetail);
                    }
                }

                return actiondetail;
            }

            public void UnSbscribe<TMessageType>(Subscription<TMessageType> subscription)
            {
                Type t = typeof(TMessageType);
                if (subscriber.ContainsKey(t))
                {
                    lock (lockObj)
                    {
                        subscriber[t].Remove(subscription);
                    }
                    subscription = null;
                }
            }

        }

        public class Publisher
        {
            EventAggregator EventAggregator;
            public Publisher(EventAggregator eventAggregator)
            {
                EventAggregator = eventAggregator;
            }

            public void PublishMessage()
            {
                EventAggregator.Publish(new MyMessage());
                EventAggregator.Publish(10);
            }
        }

        public interface IMyMessage
        {

        }

        public class MyMessage : IMyMessage
        {

        }

        public class Subscriber
        {
            Subscription<MyMessage> myMessageToken;
            Subscription<int> intToken;
            EventAggregator eventAggregator;

            public Subscriber(EventAggregator eve)
            {
                eventAggregator = eve;
                eve.Subscribe<MyMessage>(this.Test);
                eve.Subscribe<int>(this.IntTest);
            }

            private void IntTest(int obj)
            {
                Console.WriteLine(obj);
                eventAggregator.UnSbscribe(intToken);
            }

            private void Test(MyMessage test)
            {
                Console.WriteLine(test.ToString());
                eventAggregator.UnSbscribe(myMessageToken);
            }
        }
    }

    public class PubSubEventExample
    {
        public static void Execute()
        {
            new Client();
        }

        public class Client
        {
            private readonly IPublisher<int> IntPublisher;
            private readonly Subscriber<int> IntSublisher1;
            private readonly Subscriber<int> IntSublisher2;

            public Client()
            {
                IntPublisher = new Publisher<int>();//create publisher of type integer  

                IntSublisher1 = new Subscriber<int>(IntPublisher);//subscriber 1 subscribe to integer publisher  
                IntSublisher1.Publisher.DataPublisher += publisher_DataPublisher1;//event method to listen publish data  

                IntSublisher2 = new Subscriber<int>(IntPublisher);//subscriber 2 subscribe to interger publisher  
                IntSublisher2.Publisher.DataPublisher += publisher_DataPublisher2;//event method to listen publish data  

                IntPublisher.PublishData(10); // publisher publish message  
            }

            void publisher_DataPublisher1(object sender, MessageArgument<int> e)
            {
                Console.WriteLine("Subscriber 1 : " + e.Message);
            }

            void publisher_DataPublisher2(object sender, MessageArgument<int> e)
            {
                Console.WriteLine("Subscriber 2 : " + e.Message);
            }
        }

        public class MessageArgument<T> : EventArgs
        {
            public T Message { get; set; }
            public MessageArgument(T message)
            {
                Message = message;
            }
        }

        public interface IPublisher<T>
        {
            event EventHandler<MessageArgument<T>> DataPublisher;
            void OnDataPublisher(MessageArgument<T> args);
            void PublishData(T data);
        }

        public class Publisher<T> : IPublisher<T>
        {
            //Defined datapublisher event  
            public event EventHandler<MessageArgument<T>> DataPublisher;

            public void OnDataPublisher(MessageArgument<T> args)
            {
                var handler = DataPublisher;
                if (handler != null)
                    handler(this, args);
            }

            public void PublishData(T data)
            {
                MessageArgument<T> message = (MessageArgument<T>)Activator.CreateInstance(typeof(MessageArgument<T>), new object[] { data });
                OnDataPublisher(message);
            }
        }

        public class Subscriber<T>
        {
            public IPublisher<T> Publisher { get; private set; }
            public Subscriber(IPublisher<T> publisher)
            {
                Publisher = publisher;
            }
        }
    }

    public class SimpleObserverExaple
    {
        public static void Execute()
        {
            IPublisher pubs = new Publisher();
            ISubscriber subs1 = new Subscriber("First", pubs);
            ISubscriber subs2 = new Subscriber("Second", pubs);
            ISubscriber subs3 = new Subscriber("Third", pubs);

            pubs.Notify("Subscribe Message 1");

            subs2.UnRegister();

            pubs.Notify("Subscribe Message 2");
            Console.Read();
        }

        public interface ISubscriber
        {
            void DisplayMessage(string message);

            void UnRegister();
        }

        public class Subscriber : ISubscriber
        {
            private string name;

            private IPublisher publisher;

            public Subscriber(string name, IPublisher publisher)
            {
                this.name = name;
                this.publisher = publisher;
                this.publisher.Register(this);
            }

            public void UnRegister()
            {
                this.publisher.UnRegister(this);
            }

            public void DisplayMessage(string message)
            {
                Console.WriteLine($"{name} received message : {message}");
            }
        }

        public interface IPublisher
        {
            void Register(ISubscriber subscriber);

            void UnRegister(ISubscriber subscriber);

            void Notify(string message);
        }

        public class Publisher : IPublisher
        {
            Action<string> publishMessage = null;

            public void Register(ISubscriber subscriber)
            {
                publishMessage += subscriber.DisplayMessage;
            }

            public void UnRegister(ISubscriber subscriber)
            {
                if (subscriber != null)
                {
                    publishMessage -= subscriber.DisplayMessage;
                }
            }

            public void Notify(string message)
            {
                this.publishMessage(message);
            }
        }
    }
}
