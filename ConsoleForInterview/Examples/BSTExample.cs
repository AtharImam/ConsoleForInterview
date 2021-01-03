using System;

namespace ConsoleForInterview.Examples
{
    public class BSTExample
    {
        public static void Execute()
        {
            int[] arr = { 2, 6, 13, 21, 36, 47, 63, 81, 99 };
            int[] arr1 = { 1, 2, 6, 13, 21, 30, 36, 47, 63, 81, 99, 100 };
            
            Console.WriteLine("2, 6, 13, 21, 36, 47, 63, 81, 99");
            foreach (var item in arr1)
            {
                int pos = -1;// FindElement(arr, 0, arr.Length, item);

                int left = 0, right = arr.Length;
                while(true)
                {
                    int mid = (left + right) / 2;
                    int midItem = arr[mid];
                    if (midItem == item)
                    {
                        pos = mid;
                        break;
                    }

                    if (left >= (right-1) || right==0)
                    {
                        pos = -1;
                        break;
                    }

                    if (item > midItem)
                    {
                        left = mid;
                    }
                    else
                    {
                        right = mid;
                    }
                }

                if (pos != -1)
                {
                    Console.WriteLine($"Element {item} found at : {pos}");
                }
                else
                {
                    Console.WriteLine($"Element {item} Not found");
                }
            }
        }

        static int FindElement(int[] arr, int left, int right, int item)
        {
            int mid = (left + right) / 2;
            int midItem = arr[mid];
            if (midItem == item)
            {
                return mid;
            }

            if (left >= (right-1) || right == 0)
            {
                return -1;
            }

            if (item > midItem)
            {
                return FindElement(arr, mid, right, item);
            }
            else
            {
                return FindElement(arr, left, mid, item);
            }
        }
    }
}
