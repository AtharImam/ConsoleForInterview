using System.Linq;

namespace ConsoleForInterview.CodingTest
{
    public class SecondLargestNumberExample
    {
        public static void Execute()
        {
            int[] arr = { 12, 35, 1, 10, 34, 1 };
            if (arr.Length < 2)
            {
                System.Console.WriteLine("Invalid Input");
                return;
            }

            Method1(arr);
            Method2(arr);
        }

        static void Method1(int[] arr)
        {
            int first = arr.Max();
            int second = arr.Where(item => item < first).Max();
            System.Console.WriteLine("Method1 : " + second);
        }

        static void Method2(int[] arr)
        {
            int first, second;
            first = second = int.MinValue;

            for(int index = 0; index < arr.Length; index++)
            {
                if (arr[index] > first)
                {
                    first = arr[index];
                }
            }

            for (int index = 0; index < arr.Length; index++)
            {
                if (arr[index] > second && arr[index] != first)
                {
                    second = arr[index];
                }
            }

            System.Console.WriteLine("Method2 : " + second);
        }
    }
}
