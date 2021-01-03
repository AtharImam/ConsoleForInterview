using System;
using System.Linq;

namespace ConsoleForInterview.CodingTest
{
    public static class ArrayElementAppears
    {
        public static void Execute()
        {
            int[] arr = { 3, 3, 4, 2, 4, 4, 2, 4, 5 };
            int n = arr.Length;
            Method1(arr, n);
            Method2(arr, n);
        }

        static void Method2(int[] arr, int n)
        {
            Console.Write("Method2: ");
            var item = arr.GroupBy(item => item).Select(item => new { Key = item.Key, Cnt = item.Count() }).FirstOrDefault(item => item.Cnt > n / 2);
            if (item == null)
            {
                Console.WriteLine("No item present");
            }
            else
            {
                Console.WriteLine(item.Key);
            }
        }

        static void Method1(int[] arr, int n)
        {
            Console.WriteLine("Method1:");
            int cand = FindCandiate(arr, n);
            if (IsMajority(arr, n, cand))
            {
                Console.WriteLine("Majority : " + cand);
            }
            else
            {
                Console.WriteLine("Majority : " + -1);
            }
        }

        static int FindCandiate(int[] arr, int size)
        {
            int majIndex = 0, count = 1;
            for (int index = 1; index < size; index++)
            {
                if (arr[majIndex] == arr[index])
                    count++;
                else
                    count--;

                if (count == 0)
                {
                    majIndex = index;
                    count = 1;
                }
            }

            return arr[majIndex];
        }

        static bool IsMajority(int[] arr, int size, int cand)
        {
            int i, count = 0;
            for (int index = 0; index < size; index++)
            {
                if (arr[index] == cand)
                    count++;
            }

            return (count > size / 2);
        }



        // Function to find Majority element 
        // in an array 
        static int FindMajority(int[] arr, int n)
        {
            int maxCount = 0;
            int index = -1; // sentinels 
            for (int i = 0; i < n; i++)
            {
                int count = 0;
                for (int j = 0; j < n; j++)
                {
                    if (arr[i] == arr[j])
                        count++;
                }

                // update maxCount if count of 
                // current element is greater 
                if (count > maxCount)
                {
                    maxCount = count;
                    index = i;
                }
            }

            // if maxCount is greater than n/2 
            // return the corresponding element 
            if (maxCount > n / 2)
                return arr[index];

            return -1;
        }
    }
}
