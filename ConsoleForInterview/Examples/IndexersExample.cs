using System;

namespace ConsoleForInterview
{
    public class IndexersExample
    {
        public static void Execute()
        {
            IndexerClass Team = new IndexerClass();
            Team[0] = "Rocky";
            Team[1] = "Teena";
            Team[2] = "Ana";
            Team[3] = "Victoria";
            Team[4] = "Yani";
            Team[5] = "Mary";
            Team[6] = "Gomes";
            Team[7] = "Arnold";
            Team[8] = "Mike";
            Team[9] = "Peter";
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(Team[i]);
            }

            Console.WriteLine("Index positon of Gomes : " + Team["Gomes"]);
        }

        class IndexerClass
        {
            private string[] names = new string[10];

            public string this[int i]
            {
                get
                {
                    return names[i];
                }
                set
                {
                    names[i] = value;
                }
            }

            public int this[string name]
            {
                get
                {
                    return Array.IndexOf(names, name);
                }
            }
        }
    }
}
