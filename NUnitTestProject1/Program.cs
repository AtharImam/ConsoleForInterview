using System;
using System.Linq;

namespace NUnitTestProject1
{
    public class Program
    {
        public static int[] CountPosSumNeg(double[] arr)
        {
            if (arr == null || arr.Count() == 0)
            {
                return new int[] { };
            }

            int[] sums = new int[2];
            sums[0] = arr.Count(item => item > 0);
            sums[1] = Convert.ToInt32(arr.Where(item => item < 0).Sum());
            return sums;
        }
    }
}
