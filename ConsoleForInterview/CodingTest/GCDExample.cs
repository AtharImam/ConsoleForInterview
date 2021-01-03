using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleForInterview.CodingTest
{
    public class GCDExample
    {
		public static void Execute()
        {
			Console.WriteLine("Total Count: " + CountGCD(0, 3));
            Console.WriteLine("Test Example ********************************");
			Console.WriteLine("Total Count: " + CountGCDTest(0, 3));
		}


		static int CountGCDTest(int num1, int num2)
        {
			int totalCount = 0;
			for(int start = num1;start < num2; start++)
            {
				for (int end = start; end < num2; end++)
                {
					if(start!=end && GCDTest(start, end) == 1)
                    {
						Console.WriteLine($"{start} {end}");
						Console.WriteLine($"{end} {start}");
						totalCount+=2;
                    }
                }
			}

			return totalCount;
        }


		static int GCDTest(int dividend, int divisor)
        {
			return divisor > 0 ? GCDTest(divisor, dividend % divisor) : dividend;
        }


		static int CountGCD(int start, int end)
		{
			int ans = 0;
			for (int i = start; i < end; i++)
				for (int j = start; j < end; j++)
				{
                    Console.WriteLine("---------------------------");
					if (i != j && Gcd(i, j) == 1)
					{
						Console.WriteLine($"{i} {j}");
						ans++;
					}
				}

			return ans;
		}

		public static int Gcd(int a, int b)
		{
            Console.WriteLine($"a:{a}, b:{b}");
			return b > 0 ? Gcd(b, a % b) : a;
		}
	}
}
