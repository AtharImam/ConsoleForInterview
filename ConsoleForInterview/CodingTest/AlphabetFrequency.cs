using System;
using System.Linq;

namespace ConsoleForInterview.CodingTest
{
    public static class AlphabetFrequency
    {
        /// <summary>
        /// Sample "geeksforgeeks", “aabccccddd”, "elephant"
        /// </summary>
        /// <param name="s"></param>
        public static void Execute()
        {
            string s = "ab03dcaop765";
            Console.WriteLine($"Orignail String : {s}");
            Console.WriteLine($"Compressed String : {FrequencyOfAlphabets(s)}");
            Console.WriteLine($"Compressed String : {GetFrequency(s)}");
            //Console.WriteLine($"Compressed String : {Compress(s)}");
        }

        public static string FrequencyOfAlphabets(string str)
        {
            //string cstr = string.Join("", str.GroupBy(item => item).OrderBy(item => item.Key).Select(item => new string(item.Key.ToString() + item.Count().ToString())).ToArray());
            string cstr = string.Join("", str.GroupBy(item => item).Select(item => item.Key.ToString() + item.Count()).OrderBy(item => item));
            return cstr;
        }

        private static string GetFrequency(string s)
        {
            int[] freq = new int[255];
            for (int index = 0; index < s.Length; index++)
            {
                freq[s[index]]++;
            }

            string str = string.Empty;

            for (int index = 0; index < 255; index++)
            {
                if (freq[index] == 0)
                    continue;

                str += (char)index + "" + freq[index];
            }

            return str;
        }

        private static string Compress(string s)
        {
            int n = s.Length;
            int MAX = 26;
            // To store the frequency  
            // of the characters  
            int[] freq = new int[MAX];

            // Update the frequency array  
            for (int i = 0; i < n; i++)
            {
                freq[s[i] - 'a']++;
            }

            string frequency = string.Empty;
            // Print the frequency in alphatecial order  
            for (int i = 0; i < MAX; i++)
            {

                // If the current alphabet doesn't  
                // appear in the string  
                if (freq[i] == 0) continue;

                //Console.Write((char)(i + 'a') + "" + freq[i]);
                frequency += (char)(i + 'a') + "" + freq[i];
            }

            return frequency;
        }
    }
}
