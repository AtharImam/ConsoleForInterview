
namespace ConsoleForInterview.Examples
{
    class GlobalKeywordExample
    {
        public static void Execute()
        {
            object obj = new object();
            global::System.Console.WriteLine(obj.GetType().IsValueType);
        }

        public class System
        {
            public string Name { get; set; }

            public class Console
            {
                public static void WriteLine()
                {

                }
            }
        }
    }
}
