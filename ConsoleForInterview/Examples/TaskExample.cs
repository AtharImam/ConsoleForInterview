using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace ConsoleForInterview
{
    public class TaskExample
    {
        public static void Execute()
        {
           
        }

        public static void TaskWaitAllExample()
        {
            List<Task> tasks = new List<Task>();
            for(int index = 0; index < 5; index++)
            {
                Task task = Task.Run(() =>
                {
                    Console.WriteLine($"Task {index+1} Running....");
                    Thread.Sleep(5000);
                });
                tasks.Add(task);
            }

            Console.WriteLine("Task.WaitAll called");
            Task.WaitAll(tasks.ToArray());
            Console.WriteLine("Task.WaitAll completed");
        }

        public static void TaskWhenAllAllExample()
        {
            List<Task<int>> tasks = new List<Task<int>>();
            for (int index = 0; index < 5; index++)
            {
                Task<int> task = new Task<int>(() =>
                {
                    int total = 0;
                    for (int i = 0; i < index + 10; i++)
                    {
                        total += i;
                    }

                    Thread.Sleep(200);
                    return total;
                });

                task.Start();
                tasks.Add(task);
            }

            Console.WriteLine("Task.WhenAll called");
            //Task<int[]> waitTask = Task.WhenAll(tasks.ToArray());

            //foreach(int result in waitTask.Result)
            //{
            //    Console.WriteLine("Result : " + result);
            //}

            Task.WhenAll(tasks.ToArray()).ContinueWith((waitTask) =>
            {
                foreach (int result in waitTask.Result)
                {
                    Console.WriteLine("Result : " + result);
                }
            });

            Task<int> newtask = new Task<int>(() =>
            {
                int total = 0;
                for (int i = 0; i < 10; i++)
                {
                    total += i;
                }

                Thread.Sleep(200);
                return total;
            });

            newtask.Start();
            newtask.ContinueWith(t =>
            {
                Console.WriteLine("Result : " + t.Result);
            });

            Console.WriteLine("Task.WhenAll completed");
        }

        public static async Task ContinueWithExample()
        {
            // Execute the antecedent.
            Task<DayOfWeek> taskA = Task.Run(() => DateTime.Today.DayOfWeek);

            // Execute the continuation when the antecedent finishes.
            await taskA.ContinueWith(antecedent =>
            {
                Console.WriteLine("Today is {0}.", antecedent.Result);
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            });
        }

        public static async Task AwaitExample()
        {
            // Execute the antecedent.
            Task<DayOfWeek> taskA = Task.Run(() => DateTime.Today.DayOfWeek);

            Console.WriteLine("Today is {0}.", taskA.Result);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        }

        // Demonstrates how to create a basic dataflow pipeline.
        // This program downloads the book "The Iliad of Homer" by Homer from the Web
        // and finds all reversed words that appear in that book.
        public class DataflowReversedWordsExample
        {
            public void Execute()
            {
                //
                // Create the members of the pipeline.
                //

                // Downloads the requested resource as a string.
                var downloadString = new TransformBlock<string, string>(async uri =>
                {
                    Console.WriteLine("Downloading '{0}'...", uri);

                    return await new HttpClient().GetStringAsync(uri);
                });

                // Separates the specified text into an array of words.
                var createWordList = new TransformBlock<string, string[]>(text =>
                {
                    Console.WriteLine("Creating word list...");

                    // Remove common punctuation by replacing all non-letter characters
                    // with a space character.
                    char[] tokens = text.Select(c => char.IsLetter(c) ? c : ' ').ToArray();
                    text = new string(tokens);

                    // Separate the text into an array of words.
                    return text.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                });

                // Removes short words and duplicates.
                var filterWordList = new TransformBlock<string[], string[]>(words =>
                {
                    Console.WriteLine("Filtering word list...");

                    return words.Where(word => word.Length > 3).Distinct().ToArray();
                });

                // Finds all words in the specified collection whose reverse also
                // exists in the collection.
                var findReversedWords = new TransformManyBlock<string[], string>(words =>
                {
                    Console.WriteLine("Finding reversed words...");

                    var wordsSet = new HashSet<string>(words);

                    return from word in words.AsParallel()
                           let reverse = new string(word.Reverse().ToArray())
                           where word != reverse && wordsSet.Contains(reverse)
                           select word;
                });

                // Prints the provided reversed words to the console.
                var printReversedWords = new ActionBlock<string>(reversedWord =>
                {
                    Console.WriteLine("Found reversed words {0}/{1}",
                       reversedWord, new string(reversedWord.Reverse().ToArray()));
                });

                //
                // Connect the dataflow blocks to form a pipeline.
                //

                var linkOptions = new DataflowLinkOptions { PropagateCompletion = true };

                downloadString.LinkTo(createWordList, linkOptions);
                createWordList.LinkTo(filterWordList, linkOptions);
                filterWordList.LinkTo(findReversedWords, linkOptions);
                findReversedWords.LinkTo(printReversedWords, linkOptions);

                // Process "The Iliad of Homer" by Homer.
                downloadString.Post("http://www.gutenberg.org/cache/epub/16452/pg16452.txt");

                // Mark the head of the pipeline as complete.
                downloadString.Complete();

                // Wait for the last block in the pipeline to process all messages.
                printReversedWords.Completion.Wait();
            }
        }

        public class ProducerConsumerExample
        {
            AggregateMessage aggregateMessage;

            public ProducerConsumerExample()
            {
                aggregateMessage = new AggregateMessage();
            }

            public void Execute()
            {
                // Create a BufferBlock<byte[]> object. This object serves as the
                // target block for the producer and the source block for the consumer.
                var buffer = new BufferBlock<IMessage>();

                // Start the consumer. The Consume method runs asynchronously.
                var consumer = ConsumeAsync(buffer);

                // Post source data to the dataflow block.
                Produce(buffer);

                // Wait for the consumer to process all data.
                consumer.Wait();

                // Print the count of bytes processed to the console.
                string message = aggregateMessage.ToString();
                Console.WriteLine("Processed Messages: ", message);
            }

            // Demonstrates the production end of the producer and consumer pattern.
            void Produce(ITargetBlock<IMessage> target)
            {
                Task task1 = Task.Run(() =>
                {
                    Task.Delay(300);
                    target.Post(new EmpMessage { Id = 1, Name = "Athar" });
                });

                Task task2 = Task.Run(() =>
                {
                    Task.Delay(300);
                    target.Post(new DeptMessage { Id = 1, Department = "Admin" });
                });

                Task task3 = Task.Run(() =>
                {
                    Task.Delay(300);
                    target.Post(new SalarMessage { Id = 1, Salary = 20000 });
                });

                Task task4 = Task.Run(() =>
                {
                    Task.Delay(300);
                    target.Post(new CompanyMessage { Id = 1, Name = "Nagarro", Location = "Gurgaon" });
                });

                Task task5 = Task.Run(() =>
                {
                    Task.Delay(300);
                    target.Post(new TownMessage { Id = 1, Country = "India" });
                });

                Task.WaitAll(task1, task2, task3, task4, task5);

                // Set the target to the completed state to signal to the consumer
                // that no more data will be available.
                target.Complete();
                target.Completion.Wait();
            }

            // Demonstrates the consumption end of the producer and consumer pattern.
            async Task ConsumeAsync(ISourceBlock<IMessage> source)
            {
                // Read from the source buffer until the source buffer has no
                // available output data.
                while (await source.OutputAvailableAsync())
                {
                    var data = source.Receive();
                    aggregateMessage.AddMessage(data);
                }
            }
        }

        public class ActionBlockMessageExample
        {
            ActionBlock<IMessage> bufferBlock;
            AggregateMessage aggregateMessage;
            
            public ActionBlockMessageExample()
            {
                aggregateMessage = new AggregateMessage();
                bufferBlock = new ActionBlock<IMessage>(aggregateMessage.AddMessage, new ExecutionDataflowBlockOptions
                {
                    MaxDegreeOfParallelism = DataflowBlockOptions.Unbounded,
                    EnsureOrdered = false,
                    BoundedCapacity = 5
                });
            }

            public async void Execute()
            {
                Task task1 = Task.Run(() =>
                {
                    Task.Delay(300);
                    bufferBlock.Post(new EmpMessage { Id = 1, Name = "Athar" });
                });

                Task task2 = Task.Run(() =>
                {
                    Task.Delay(300);
                    bufferBlock.Post(new DeptMessage { Id = 1, Department = "Admin" });
                });

                Task task3 = Task.Run(() =>
                {
                    Task.Delay(300);
                    bufferBlock.Post(new SalarMessage { Id = 1, Salary = 20000 });
                });

                Task task4 = Task.Run(() =>
                {
                    Task.Delay(300);
                    bufferBlock.Post(new CompanyMessage { Id = 1, Name = "Nagarro", Location = "Gurgaon" });
                });

                Task task5 = Task.Run(() =>
                {
                    Task.Delay(300);
                    bufferBlock.Post(new TownMessage { Id = 1, Country = "India" });
                });

                Task.WaitAll(task3, task1, task2, task4, task5);
                bufferBlock.Complete();
                bufferBlock.Completion.Wait();
                Console.WriteLine(aggregateMessage.ToString());
            }
        }

        public class BroadcasthBlockMessageExample
        {
            BroadcastBlock<IMessage> bufferBlock;
            AggregateMessage aggregateMessage = new AggregateMessage();
            public BroadcasthBlockMessageExample()
            {
                bufferBlock = new BroadcastBlock<IMessage>(f =>
                {
                    AddMessage(f);
                    return f;
                });
            }

            public async void Execute()
            {
                Task task1 = Task.Run(() =>
                {
                    Task.Delay(300);
                    bufferBlock.SendAsync(new EmpMessage { Id = 1, Name = "Athar" });
                });

                Task task2 = Task.Run(() =>
                {
                    Task.Delay(300);
                    bufferBlock.SendAsync(new DeptMessage { Id = 1, Department = "Admin" });
                });

                Task task3 = Task.Run(() =>
                {
                    Task.Delay(300);
                    bufferBlock.SendAsync(new SalarMessage { Id = 1, Salary = 20000 });
                });

                Task task4 = Task.Run(() =>
                {
                    Task.Delay(300);
                    bufferBlock.SendAsync(new CompanyMessage { Id = 1, Name = "Nagarro", Location = "Gurgaon" });
                });

                Task task5 = Task.Run(() =>
                {
                    Task.Delay(300);
                    bufferBlock.SendAsync(new TownMessage { Id = 1, Country = "India" });
                });

                Task.WaitAll(task3, task1, task2, task4, task5);
                bufferBlock.Receive();
                bufferBlock.Receive();
                bufferBlock.Receive();
                bufferBlock.Receive();
                bufferBlock.Receive();
                Console.WriteLine(aggregateMessage.ToString());
            }

            public void AddMessage(IMessage message)
            {
                Console.WriteLine("Message Capture: " + message.GetType());
                if (message is EmpMessage)
                {
                    aggregateMessage.EmpMessage = message as EmpMessage;
                }
                else if (message is DeptMessage)
                {
                    aggregateMessage.DeptMessage = message as DeptMessage;
                }
                else if (message is SalarMessage)
                {
                    aggregateMessage.SalarMessage = message as SalarMessage;
                }
                else if (message is CompanyMessage)
                {
                    aggregateMessage.CompanyMessage = message as CompanyMessage;
                }
                else if (message is TownMessage)
                {
                    aggregateMessage.TownMessage = message as TownMessage;
                }
            }

            class AggregateMessage
            {
                public EmpMessage EmpMessage { get; set; }

                public DeptMessage DeptMessage { get; set; }

                public SalarMessage SalarMessage { get; set; }

                public CompanyMessage CompanyMessage { get; set; }

                public TownMessage TownMessage { get; set; }
            }

            public interface IMessage
            {

            }

            public class EmpMessage : IMessage
            {
                public int Id { get; set; }

                public string Name { get; set; }

                public override string ToString()
                {
                    return $"EmpMessage-> Id:{Id}, Name: {Name}";
                }
            }

            public class DeptMessage : IMessage
            {
                public int Id { get; set; }
                public string Department { get; set; }

                public override string ToString()
                {
                    return $"DeptMessage-> Id:{Id}, Department: {Department}";
                }
            }

            public class SalarMessage : IMessage
            {
                public int Id { get; set; }
                public double Salary { get; set; }

                public override string ToString()
                {
                    return $"SalarMessage-> Id:{Id}, Salary: {Salary}";
                }
            }

            public class CompanyMessage : IMessage
            {
                public int Id { get; set; }
                public string Name { get; set; }

                public string Location { get; set; }

                public override string ToString()
                {
                    return $"CompanyMessage-> Id:{Id}, Location: {Location}";
                }
            }

            public class TownMessage : IMessage
            {
                public int Id { get; set; }
                public string Country { get; set; }

                public override string ToString()
                {
                    return $"TownMessage-> Id:{Id}, Country: {Country}";
                }
            }
        }

        public class BatchBlockMessageExample
        {
            BatchBlock<IMessage> bufferBlock = new BatchBlock<IMessage>(5);
            AggregateMessage aggregateMessage = new AggregateMessage();

            public async void Execute()
            {
                Task task1 = Task.Run(() =>
                {
                    Task.Delay(300);
                    bufferBlock.Post(new EmpMessage { Id = 1, Name = "Athar" });
                });

                Task task2 = Task.Run(() =>
                {
                    Task.Delay(300);
                    bufferBlock.Post(new DeptMessage { Id = 1, Department = "Admin" });
                });

                Task task3 = Task.Run(() =>
                {
                    Task.Delay(300);
                    bufferBlock.Post(new SalarMessage { Id = 1, Salary = 20000 });
                });

                Task task4 = Task.Run(() =>
                {
                    Task.Delay(300);
                    bufferBlock.Post(new CompanyMessage { Id = 1, Name = "Nagarro", Location = "Gurgaon" });
                });

                Task task5 = Task.Run(() =>
                {
                    Task.Delay(300);
                    bufferBlock.Post(new TownMessage { Id = 1, Country = "India" });
                });

                foreach (var message in bufferBlock.Receive())
                {
                    aggregateMessage.AddMessage(message);
                }

                Console.WriteLine(aggregateMessage.ToString());
            }
        }

        public class BufferedBlockMessageExample
        {
            BufferBlock<IMessage> bufferBlock = new BufferBlock<IMessage>();
            AggregateMessage aggregateMessage = new AggregateMessage();

            public async void Execute()
            {
                //Task task1 = new Task(() =>
                //{
                //    Thread.Sleep(300);
                //    bufferBlock.SendAsync<EmpMessage>(new EmpMessage { Id = 1, Name = "Athar" });
                //});

                //Task task2 = Task.Run(() =>
                //{
                //    Thread.Sleep(300);
                //    bufferBlock.SendAsync<DeptMessage>(new DeptMessage { Id = 1, Department = "Admin" });
                //});

                Task taskComplete = Task.Run(async () =>
                {
                    for (int i = 0; i < 5; i++)
                    {
                        var message = await bufferBlock.ReceiveAsync();
                        aggregateMessage.AddMessage(message);
                    }
                });

                Parallel.Invoke(() =>
                {
                    Thread.Sleep(300);
                    bufferBlock.SendAsync<EmpMessage>(new EmpMessage { Id = 1, Name = "Athar" });
                },() =>
                {
                    Thread.Sleep(300);
                    bufferBlock.SendAsync<DeptMessage>(new DeptMessage { Id = 1, Department = "Admin" });
                });

                Task task3 = Task.Run(() =>
                {
                    Thread.Sleep(300);
                    bufferBlock.SendAsync<SalarMessage>(new SalarMessage { Id = 1, Salary = 20000 });
                });

                Task task4 = Task.Run(() =>
                {
                    Thread.Sleep(300);
                    bufferBlock.SendAsync<CompanyMessage>(new CompanyMessage { Id = 1, Name = "Nagarro", Location="Gurgaon" });
                });

                Task task5 = Task.Run(() =>
                {
                    Thread.Sleep(300);
                    bufferBlock.SendAsync<TownMessage>(new TownMessage { Id = 1, Country = "India" });
                });

                await taskComplete.ContinueWith(t =>
                {
                    Console.WriteLine(aggregateMessage.ToString());
                });
            }
        }

        public class DataFlowBlockExample
        {
            BufferBlock<int> buffer = new BufferBlock<int>(new DataflowBlockOptions { BoundedCapacity = 10 });

            async Task Produce(IEnumerable<int> values)
            {
                foreach (var value in values)
                    // Send the message to buffer block asynchronously. 
                    // The SendAsync method helps to throttle the messages sent
                    await buffer.SendAsync(value); ;
            }

            async Task MultipleProducers(params IEnumerable<int>[] producers)
            {
                // Running multiple producers in parallel waiting 
                // all to terminate before notify the buffer block to complete
                await Task.WhenAll(producers.Select(item => Produce(item))).ContinueWith(_ => buffer.Complete());
            }

            async Task Consumer(Action<int> process)
            {
                // Safeguard the buffer block from receiving a message 
                // only if there are any items available in the queue
                while (await buffer.OutputAvailableAsync())
                {
                    process(await buffer.ReceiveAsync());
                }
            }

            static void MyAmazingMethod()
            {
                try
                {
                    Task[] taskArray = { Task.Factory.StartNew(() => WaitAndThrow(1, 1000)),
                                 Task.Factory.StartNew(() => WaitAndThrow(2, 2000)),
                                 Task.Factory.StartNew(() => WaitAndThrow(3, 3000)) };

                    //Task.WaitAll(taskArray);
                    Task.WhenAll(taskArray).ContinueWith(t =>
                    {
                        WaitAndThrow(4, 1000);
                        t.ConfigureAwait(false);
                    });

                    Console.WriteLine("This isn't going to happen");
                }
                catch (AggregateException ex)
                {
                    foreach (var inner in ex.InnerExceptions)
                    {
                        Console.WriteLine($"Caught AggregateException in Main at {DateTime.UtcNow}: " + inner.Message);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Caught Exception in Main at {DateTime.UtcNow}: " + ex.Message);
                }
                Console.WriteLine("Done.");
                Console.ReadLine();
            }

            static void WaitAndThrow(int id, int waitInMs)
            {
                Console.WriteLine($"{DateTime.UtcNow}: Task {id} started");

                Thread.Sleep(waitInMs);
                // throw new CustomException($"Task {id} throwing at {DateTime.UtcNow}");
            }

            class CustomException : Exception
            {
                public CustomException(string message) : base(message)
                { }
            }

            public static void MultiTaskExecuteSimultaneous()
            {

            }

            public static void ParenChildAttach()
            {
                var parent = Task.Factory.StartNew(() =>
                {
                    Console.WriteLine("Outer task executing.");

                    var child = Task.Factory.StartNew(() =>
                    {
                        Console.WriteLine("Nested task starting.");
                        Thread.Sleep(500);
                        Console.WriteLine("Nested task completing.");
                    }, TaskCreationOptions.AttachedToParent);
                });

                parent.Wait();
                Console.WriteLine("Outer has completed.");
            }
        }

        public class AggregateMessage
        {
            public EmpMessage EmpMessage { get; set; }

            public DeptMessage DeptMessage { get; set; }

            public SalarMessage SalarMessage { get; set; }

            public CompanyMessage CompanyMessage { get; set; }

            public TownMessage TownMessage { get; set; }

            public void AddMessage(IMessage message)
            {
                if (message is EmpMessage)
                {
                    this.EmpMessage = message as EmpMessage;
                }
                else if (message is DeptMessage)
                {
                    this.DeptMessage = message as DeptMessage;
                }
                else if (message is SalarMessage)
                {
                    this.SalarMessage = message as SalarMessage;
                }
                else if (message is CompanyMessage)
                {
                    this.CompanyMessage = message as CompanyMessage;
                }
                else if (message is TownMessage)
                {
                    this.TownMessage = message as TownMessage;
                }

                Console.WriteLine("Message Capture: " + message.GetType());
            }

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder();
                sb.AppendLine();
                sb.Append(this.EmpMessage.ToString());
                sb.AppendLine();
                sb.Append(this.DeptMessage.ToString());
                sb.AppendLine();
                sb.Append(this.SalarMessage.ToString());
                sb.AppendLine();
                sb.Append(this.CompanyMessage.ToString());
                sb.AppendLine();
                sb.Append(this.TownMessage.ToString());
                sb.AppendLine();

                return sb.ToString();
            }
        }

        public interface IMessage
        {

        }

        public class EmpMessage : IMessage
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public override string ToString()
            {
                return $"EmpMessage-> Id:{Id}, Name: {Name}";
            }
        }

        public class DeptMessage : IMessage
        {
            public int Id { get; set; }

            public string Department { get; set; }

            public override string ToString()
            {
                return $"DeptMessage-> Id:{Id}, Department: {Department}";
            }
        }

        public class SalarMessage : IMessage
        {
            public int Id { get; set; }

            public double Salary { get; set; }

            public override string ToString()
            {
                return $"SalarMessage-> Id:{Id}, Salary: {Salary}";
            }
        }

        public class CompanyMessage : IMessage
        {
            public int Id { get; set; }

            public string Name { get; set; }

            public string Location { get; set; }

            public override string ToString()
            {
                return $"CompanyMessage-> Id:{Id}, Location: {Location}";
            }
        }

        public class TownMessage : IMessage
        {
            public int Id { get; set; }

            public string Country { get; set; }

            public override string ToString()
            {
                return $"TownMessage-> Id:{Id}, Country: {Country}";
            }
        }
    }
}