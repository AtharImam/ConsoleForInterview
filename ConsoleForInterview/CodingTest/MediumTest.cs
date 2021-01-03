using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleForInterview.CodingTest
{
    public class MediumTest
    {
		public static void Execute()
		{
			//Console.WriteLine($"A: {(int)'A'}, a: {(int)'a'}");
			//Console.WriteLine(ReverseCase("Happy Birthday"));// ➞ "hAPPY bIRTHDAY"
			//Console.WriteLine(ReverseCase("MANY THANKS"));// ➞ "many thanks"
			//Console.WriteLine(ReverseCase("sPoNtAnEoUs"));// ➞ "SpOnTaNeOuS"
			//Console.WriteLine(IsIsogram("Algorism"));
			//Console.WriteLine(IsIsogram("PasSword"));
			//Console.WriteLine(IsIsogram("Consecutive"));
			//Console.WriteLine(Maskify("4556364607935616"));
			//Console.WriteLine(Maskify("64607935616"));
			//Console.WriteLine(Maskify("1"));
			//Console.WriteLine(Maskify(""));
			//Console.WriteLine(CounterpartCharCode('ⱥ'));
			//Console.WriteLine(AverageWordLength("I just planted a young oak tree, wonder how tall it will grow in a few years?"));
			//Console.WriteLine(MinTurns("0000","9999"));
			//string str = "ABC";
			//int n = str.Length;
			//Permute(str, 0, n - 1);
			//foreach(string str in PrintAnagram("ABC", 0))
			//{
			//    Console.WriteLine(str);
			//}
			//Console.WriteLine(AnagramStrStr("car","race"));
			//StringSplitOptions.RemoveEmptyEntries

			//Console.WriteLine(LargetNumberInArray(1, 5, 32, 23, 65, 11, 28, 38));
			//Console.WriteLine(LargetNumberInArray(2, 5, 32, 23, 65, 11, 28, 38));
			//Console.WriteLine(LargetNumberInArray(3, 5, 32, 23, 65, 11, 28, 38));
			//Console.WriteLine(LargetNumberInArray(4, 5, 32, 23, 65, 11, 28, 38));
			//Console.WriteLine(PalindromeDescendant(9735));
			List<int> list = new List<int>();
			Dictionary<string, string> dict = new Dictionary<string, string>();

			//list.IndexOf()
			//string str = Convert.ToString((double)1/3);
			//         Console.WriteLine(str);
			//Console.WriteLine(Rational(1, 1225));
			int[] arr = new int[] { 10,9,8,7,6 };
			//Console.WriteLine(Candy1(arr));
			Console.WriteLine(Candy2(arr));
			Console.WriteLine(Candy3(arr));
		}

		public static int Candy3(int[] ratings)
        {
			int[] candies = new int[ratings.Length];
			Array.Fill(candies, 1);
			bool flag = true;
			while (flag)
			{
				flag = false;
				for (int index = 0; index < ratings.Length; index++)
				{
					if (index != (ratings.Length - 1) && ratings[index] > ratings[index + 1] && candies[index]<=candies[index+1])
					{
						candies[index] = candies[index + 1] + 1;
						flag = true;
					}

					if (index > 0 && ratings[index] > ratings[index - 1] && candies[index] <= candies[index - 1])
					{
						candies[index] = candies[index - 1] + 1;
						flag = true;
					}
				}
			}

			return candies.Sum();
        }

		public static int Candy2(int[] ratings)
		{
			int[] candies = new int[ratings.Length];
			Console.WriteLine(string.Join(",", ratings.Select(item => item.ToString())));
			Array.Fill(candies, 1);
			Console.WriteLine(string.Join(",", candies.Select(item => item.ToString())));
			bool flag = true;
			int sum = 0;
			while (flag)
			{
				flag = false;
				for (int i = 0; i < ratings.Length; i++)
				{
					if (i != ratings.Length - 1 && ratings[i] > ratings[i + 1] && candies[i] <= candies[i + 1])
					{
						candies[i] = candies[i + 1] + 1;
						flag = true;
					}
					if (i > 0 && ratings[i] > ratings[i - 1] && candies[i] <= candies[i - 1])
					{
						candies[i] = candies[i - 1] + 1;
						flag = true;
					}
					Console.WriteLine(string.Join(",", candies.Select(item => item.ToString())));
				}
			}
			foreach (int candy in candies)
			{
				sum += candy;
			}
			return sum;
		}

		public static int Candy1(int[] ratings)
		{
			int[] candies = new int[ratings.Length];
			Console.WriteLine(string.Join(",", ratings.Select(item => item.ToString())));
			Array.Fill(candies, 1);
			Console.WriteLine(string.Join(",", candies.Select(item => item.ToString())));
			for (int i = 1; i < ratings.Length; i++)
			{
				if (ratings[i] > ratings[i - 1])
				{
					candies[i] = candies[i - 1] + 1;
				}
				Console.WriteLine(string.Join(",", candies.Select(item => item.ToString())));
			}
			int sum = candies[ratings.Length - 1];
			for (int i = ratings.Length - 2; i >= 0; i--)
			{
				if (ratings[i] > ratings[i + 1])
				{
					candies[i] = Math.Max(candies[i], candies[i + 1] + 1);
				}
				Console.WriteLine(string.Join(",", candies.Select(item => item.ToString())));
				sum += candies[i];
			}
			return sum;
		}

		public static string Rational(int a, int b)
		{
			string res = "0.";
			List<int> c = new List<int>();
			int i = 1;
			c.Add(a);
			while (c[i - 1] > 0)
			{
				c.Add(i);
				c[i] = c[i - 1] * 10;
				int k = (c[i] - (c[i] % b)) / b;
				c[i] = c[i] % b;
				res += k;
				for (int j = 0; j < i; j++)
				{
					if (c[i] == c[j])
					{
						res = res.Insert(j + 2, "(") + ")";
						c[i] = 0;
					}
				}
				i++;
			}
			return res;
		}

		public static bool SameLetterPattern1(string str1, string str2)
		{
			str1 = str1.ToLower();
			str2 = str2.ToLower();
			bool blFlag = true;
			if (str1.Length == str2.Length)
			{
				int iMarker = 1;
				for (int i = 0; i < str1.Length; i++)
				{
					str1 = str1.Replace(str1[i].ToString(), iMarker.ToString());
					str2 = str2.Replace(str2[i].ToString(), iMarker.ToString());
					iMarker++;
				}

				if (str1 != str2)
				{
					blFlag = false;
				}
			}
			else
			{
				blFlag = false;
			}
			return blFlag;
		}

		public static bool SameLetterPattern(string str1, string str2)
		{
			if (str1.Length != str2.Length)
				return false;
			for (int i = 0; i < str1.Length-1; i++)
			{
				int index1 = str1.IndexOf(str1.Substring(i, 1), i + 1);
				int index2 = str2.IndexOf(str2.Substring(i, 1), i + 1);
				if (index1 != index2)
					return false;
			}
			return true;
		}

		public static string LandscapeType(int[] arr)
		{
			List<int> list = arr.ToList();
			int min = list.Min();
			int max = list.Max();
			int maxIndex = list.IndexOf(max);

			bool flag = true;
			if (maxIndex > 0 && maxIndex < list.Count-1 )
			{
				int lastDigit = max;
				for (int index = maxIndex-1; index >=0; index--)
					if (list[index] > lastDigit)
					{
						flag = false;
						break;
                    }
                    else
                    {
						lastDigit = list[index];
					}

				lastDigit = max;
				if (flag)
				{
					for (int index = maxIndex+1; index < list.Count; index++)
						if (list[index] > lastDigit)
						{
							flag = false;
							break;
						}
						else
						{
							lastDigit = list[index];
						}
				}

				if (flag)
				{
					return "mountain";
				}
			}

			flag = true;
			int minIndex = list.IndexOf(min);
			if (minIndex > 0 && minIndex < list.Count-1)
			{
				int lastDigit = min;
				for (int index = minIndex-1; index >=0; index--)
					if (list[index] < lastDigit)
					{
						flag = false;
						break;
					}
					else
					{
						lastDigit = list[index];
					}

				if (flag)
				{
					lastDigit = min;
					for (int index = minIndex+1; index < list.Count; index++)
						if (list[index] < lastDigit)
						{
							flag = false;
							break;
						}
						else
						{
							lastDigit = list[index];
						}
				}

				if (flag)
				{
					return "valley";
				}
			}

			return "neither";
		}

		public static bool PalindromeDescendant(int num)
		{
			char[] arr = num.ToString().ToCharArray();
			if (arr.Length == 1)
				return false;
			if (!CheckPallindrome(arr))
			{
				if (arr.Length > 2)
				{
					int newNum = 0;
					for (int index = 0; index < arr.Length-1; index++)
					{
						int num1 = ((int)arr[index]) - 48;
						int num2 = ((int)arr[index + 1]) - 48;
						newNum = newNum * 10 + (num1 + num2);
						index++;
					}

					return PalindromeDescendant(newNum);
				}
				else return false;
			}
			return true;
		}

		public static bool CheckPallindrome(char[] arr)
		{
			for (int index = 0; index < arr.Length / 2; index++)
			{
				if (arr[index] != arr[arr.Length - index - 1])
					return false;
			}

			return true;
		}

		public static string ConvertToHex(string inputword)
		{
			string final = string.Empty;
			for (int index = 0; index < inputword.Length; index++)
			{
				if (!string.IsNullOrEmpty(final))
					final += " ";
				final += Convert.ToString((int)inputword[index], 16);
			}
			
			return final;
		}

		public static double UniqueFract()
		{
			List<double> list = new List<double>();

			for (int enu = 1; enu < 9; enu++)
			{
				for (int deno = enu + 1; deno <= 9; deno++)
				{
					double f = (double)enu / deno;
					list.Add(f);
				}
			}

			list.RemoveAll(p => p > 1.0);
			return list.Distinct().Sum();
		}

		public static string Simplify(string str)
		{
			string[] strs = str.Split('/');
			int num1 = Convert.ToInt32(strs[0]);
			int num2 = Convert.ToInt32(strs[1]);
			int gcd = Gcd(num1, num2);
			if (gcd == 1)
				return str;
			num1 /= gcd;
			num2 /= gcd;
			return num2 == 1 ? num1.ToString() : num1 + "/" + num2;
		}

		public static int Gcd(int a, int b)
		{
			return b > 0 ? Gcd(b, a % b) : a;
		}

		static int CountGCD(int start, int end)
		{
			int ans = 0;
			for (int i = start; i <= end; i++)
				for (int j = start; j <= end; j++)
				{
					if (i != j && Gcd(i, j) == 1)
					{
						Console.WriteLine($"{i} {j}");
						ans++;
					}
				}

			return ans;
		}

		public static int CountDecodingDigits(char[] digits, int n)
		{
			int[] count = new int[n + 1]; // An array to store results of subproblems
			count[0] = 1;
			count[1] = 1;

			for (int i = 2; i <= n; i++)
			{
				count[i] = 0;

				// If the last digit != 0, then last digit must add to the number of words
				if (digits[i - 1] > '0')
				{
					int n1 = count[i - 1];
					count[i] = n1;
				}

				// If second last digit is smaller than 2 and last digit is smaller than 7, then last two digits form a valid character
				if (digits[i - 2] == '1' || (digits[i - 2] == '2' && digits[i - 1] < '7'))
				{
					int n2 = count[i - 2];
					count[i] += n2;
				}
			}

			return count[n];
		}

		public static int CountDecoding(char[] digits, int n)
		{
			string str = new string(digits);
			//Console.WriteLine($"****{str} {n}");
			// base cases 
			if (n == 0 || n == 1)
				return 1;

			// Initialize count 
			int count = 0;

			// If the last digit is not 0, then  
			// last digit must add to 
			// the number of words 
			if (digits[n - 1] > '0')
				count = CountDecoding(digits, n - 1);

			// If the last two digits form a number 
			// smaller than or equal to 26, then  
			// consider last two digits and recur 
			if (digits[n - 2] == '1' || (digits[n - 2] == '2' && digits[n - 1] <= '6'))
				count += CountDecoding(digits, n - 2);

			return count;
		}

		public static int LargetNumberInArray(int order, params int[] nums)
        {
			return nums.OrderByDescending(item => item).Take(order).Last();
        }

		public static string FrequencyOfAlphabets(string str)
		{
			string cstr = string.Join("",str.GroupBy(item => item).OrderBy(item => item.Key).Select(item => new string(item.Key.ToString() + item.Count().ToString())).ToArray());
			return cstr;
        }

		public static string RollingCipher(string str, int n)
		{
			char[] arr = str.ToCharArray();
			for (int index = 0; index < arr.Length; index++)
			{
				int ch = arr[index];
				bool isUpper = char.IsUpper(arr[index]);
				ch += n;
				if (isUpper)
				{
					if (ch < 65)
						ch = 90 - (65 - ch) + 1;
					else if (ch > 90)
						ch = 65 + (ch - 90) - 1;
				}
				else
				{
					if (ch < 97)
						ch = 122 - (97 - ch) + 1;
					else if (ch > 122)
						ch = 97 + (ch - 122) - 1;
				}

				arr[index] = (char)ch;
			}

			return new string(arr);
		}

		public static bool IsValidHexCode(string str)
		{
			if (str[0] != '#' || str.Length != 7)
				return false;

			for (int index = 1; index < str.Length; index++)
			{
				char ch = str[index];
				if (char.IsDigit(ch))
					continue;
				if (char.IsLetter(ch))
				{
					if ((ch >= 'A' && ch <= 'F') || (ch >= 'a' && ch <= 'f'))
						continue;
					else
						return false;
				}
				else return false;
			}

			return true;
		}

		public static int NextPrime(int num)
		{
			while (true)
			{
				if (CheckPrime(num))
					return num;
				num++;
			}
		}

		public static bool CheckPrime(int num)
		{
			if (num == 1)
				return false;

			if (num <= 3)
				return true;

			for (int index = 2; index <= num / 2; index++)
			{
				if (num % index == 0)
					return false;
			}

			return true;
		}

		public static int SockPairs(string socks)
		{
			if (string.IsNullOrEmpty(socks))
				return 0;
			List<char> list = socks.ToCharArray().ToList();
			int pairCount = 0;
			while (list.Count > 0)
			{
				int endCount = 0;
				char ch = list[0];
				for (int index = 1; index < list.Count; index++)
				{
					if (ch == list[index])
					{
						endCount = index;
						pairCount++;
						break;
					}
				}

				if (endCount > 0)
				{
					list.RemoveAt(endCount);
				}

				list.RemoveAt(0);
			}

			return pairCount;
		}

		public static int ReversedBinaryInteger(int num)
		{
			string binary = Convert.ToString(num, 2);
			string revBinary = new string(binary.Reverse().ToArray());
			return Convert.ToInt32(revBinary, 2);
		}

		public static string TextToNumberBinary(string str)
		{
			string[] strs = str.Split(' ');
			strs = strs.Where(item => item.Equals("zero", StringComparison.InvariantCultureIgnoreCase)
										   || item.Equals("one", StringComparison.InvariantCultureIgnoreCase)).ToArray();
			int length = strs.Length;
			int take = ((int)length / 8) * 8;
			int nzero = strs.Take(take).Count(item => item.Equals("zero", StringComparison.InvariantCultureIgnoreCase));
			int none = strs.Take(take).Count(item => item.Equals("one", StringComparison.InvariantCultureIgnoreCase));
			if ((nzero + none) < 8)
				return "";

			string cstr= string.Join("", strs.Take(take).Select(item => item.Equals("zero", StringComparison.InvariantCultureIgnoreCase) ? "0"
								 : item.Equals("one", StringComparison.InvariantCultureIgnoreCase) ? "1" : "").ToArray());

			return cstr;
		}

		public static string Sorting(string str)
		{
			char[] arr = str.ToCharArray();
			int length = arr.Length;
			for (int index = 0; index < length; index++)
			{
				for (int y = 0; y < length - index - 1; y++)
				{
					char ch1 = arr[y];
					char ch2 = arr[y + 1];
					if ((char.IsLetter(ch1) && char.IsDigit(ch2))
						|| (char.ToLower(ch1) == char.ToLower(ch2)))
					{
						continue;
					}

					if (char.IsDigit(ch1) && char.IsLetter(ch2))
						DoCharSwap(arr, y, y + 1);
					else if (char.ToLower(ch1) > char.ToLower(ch2))
						DoCharSwap(arr, y, y + 1);
				}
			}

			for (int y = 0; y < length - 1; y++)
			{
				if (char.ToLower(arr[y]) == arr[y + 1])
					DoCharSwap(arr, y, y + 1);
			}

			return new string(arr);
		}

		public static void DoCharSwap(char[] arr, int x, int y)
		{
			char ch = arr[x];
			arr[x] = arr[y];
			arr[y] = ch;
		}

		public static string MysteryFunc(string str)
		{
			char initChar = '0';
			int repeat = 0;
			string final = "";
			for (int index = 0; index < str.Length; index++)
			{
				char ch = str[index];
				if (char.IsLetter(ch))
				{
					initChar = ch;
					repeat = 0;
				}
				else if (char.IsDigit(ch))
					repeat = ch - 48;

				if (repeat > 0)
				{
					final += new string(Enumerable.Repeat(initChar, repeat).ToArray());
				}
			}

			return final;
		}

		public static int DuplicateCount(string str)
		{
			return str.GroupBy(item => item).Count(i => i.Count() > 1);
		}

		public static string AlphabetIndex(string str)
		{
			string nStr = "";
			for (int index = 0; index < str.Length; index++)
			{
				int charPos = 0;
				if (str[index] >= 65 && str[index] <= 90)
				{
					charPos = str[index] - 65 + 1;
				}
				else if (str[index] >= 97 && str[index] <= 122)
				{
					charPos = str[index] - 97 + 1;
				}

				if (charPos > 0)
				{
					if (!string.IsNullOrEmpty(nStr))
						nStr += " ";
					nStr += charPos.ToString();
				}
			}

			return nStr;
		}

		public static string ToSnakeCase(string str)
		{
			string nStr = "";
			int initPos = 0;
			for (int index = 0; index < str.Length; index++)
			{
				if (str[index] == char.ToUpper(str[index]))
				{
					if (!string.IsNullOrEmpty(nStr))
						nStr += "_";
					nStr += str.Substring(initPos, index - initPos).ToLower();
					initPos = index;
				}
				else if (index == str.Length - 1)
				{
					if (!string.IsNullOrEmpty(nStr))
						nStr += "_";
					nStr += str.Substring(initPos, index - initPos + 1).ToLower();
				}
			}

			return nStr;
		}

		public static string ToCamelCase(string str)
		{
			string[] strs = str.ToLower().Split('_');
			for (int index = 1; index < strs.Length; index++)
			{
				strs[index] = strs[index].Substring(0, 1).ToUpper() + strs[index].Substring(1, strs[index].Length - 1);
			}

			return string.Join("", strs);
		}

		public static bool Trouble(long num1, long num2)
		{
			//1222345, 12345-> false
			//10560002, 100 -> true
			string str1 = num1.ToString();
			char ch1 = str1[0];
			int repeatCount = 0;
			for (int index = 0; index < str1.Length; index++)
			{
				if (str1[index] == ch1)
				{
					repeatCount++;
				}
				else
				{
					repeatCount = 1;
					ch1 = str1[index];
				}

				if (repeatCount == 3)
					break;
			}

			string str2 = num2.ToString();
			repeatCount = 0;
			bool isFlag = false;
			for (int index = 0; index < str2.Length; index++)
			{
				if (str2[index] == ch1)
				{
					repeatCount++;
				}
				else
				{
					repeatCount = 0;
				}

				if (repeatCount == 2)
				{
					isFlag = true;
					break;
				}
			}

			return isFlag;
		}

		public static string HighLow(string str)
		{
			string[] strs = str.Split(' ');
			int low = strs.Min(item => Convert.ToInt32(item));
			int high = strs.Max(item => Convert.ToInt32(item));
			return high.ToString() + " " + low.ToString();
		}

		public static bool ValidatePIN(string pin)
		{
			if (string.IsNullOrEmpty(pin) || !(pin.Length == 4 || pin.Length == 6))
				return false;

			return !pin.Any(item => !char.IsDigit(item));
		}

		public static bool CanComplete(string initial, string word)
		{
			//"butl", "beautiful"
			int lastPos = 0;
			for (int index = 0; index < initial.Length; index++)
			{
				bool flag = false;
				for (int index1 = lastPos; index1 < word.Length; index1++)
				{
					if (word[index1] == initial[index])
					{
						flag = true;
						lastPos = index1 + 1;
						break;
					}
				}

				if (!flag)
				{
					return false;
				}
			}

			return true;
		}

		public static int MysteryFunc(int num)
		{
			int div = 2;
			string str = "";
			while (true)
			{
				if (div < num)
				{
					str += "2";
					div *= 2;
				}
				else
				{
					div /= 2;
					str += Convert.ToString(num % div);
					break;
				}
			}

			return Convert.ToInt32(str);
		}

		public static bool IsSmooth(string sentence)
		{
			//Rita asks Sam mean numbered dilemmas
			string[] strs = sentence.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
			for (int index = 0; index < strs.Length - 1; index++)
			{
				if (char.ToLower(strs[index][strs[index].Length - 1])
					 != char.ToLower(strs[index + 1][0]))
					return false;
			}

			return true;
		}

		public static string ReverseAndNot(int i)
		{
			string str1 = i.ToString();
			string str2 = "";
			while (i != 0)
			{
				str2 += (i % 10).ToString();
				i /= 10;
			}

			return str2 + str1;
		}

		public static bool ValidatePassword(string password)
		{
			if (password.Length < 6 || password.Length > 24)
				return false;
			int tSmallChars = 0;
			int tCapChars = 0;
			int tDigits = 0;
			int tSplChars = 0;
			int tNChars = 0;
			string splChars = "!@#$%^&*()+=_-{}[]:;\"'?<>,.";
			int repeat = 0;
			char rptChar = password[0];
			for (int index = 0; index < password.Length; index++)
			{
				char ch = password[index];
				if (rptChar == ch)
					repeat++;
				else
				{
					rptChar = ch;
					repeat = 1;
				}
				if (repeat > 2)
					return false;

				if (ch >= 97 && ch <= 122)
					tSmallChars++;
				else if (ch >= 65 && ch <= 90)
					tCapChars++;
				else if (ch >= 48 && ch <= 57)
					tDigits++;
				else if (splChars.Any(item => item == ch))
					tSplChars++;
				else tNChars++;
			}

			return tSmallChars > 0 && tCapChars > 0 && tDigits > 0 && tSplChars > 0 && tNChars == 0;
		}

		public static bool AnagramStrStr(string needle, string haystack)
		{
			int length = needle.Length;
			foreach (string str in PrintAnagram(needle, 0))
			{
				for (int index = 0; index < haystack.Length - length; index++)
				{
					string sstr = haystack.Substring(index, length);
					if (sstr.Equals(str,StringComparison.OrdinalIgnoreCase))
					{
						return true;
					}
				}
			}

			return false;
		}

		public static IEnumerable<string> GetAnagram(string needle, int start)
		{
			int length = needle.Length;
			if (start == (length - 1))
			{
				yield return needle;
			}
			else
			{
				for (int index = start; index < length; index++)
				{
					var nstr = Swap(needle, start, index);
					foreach (string cstr in GetAnagram(nstr, start + 1))
					{
						yield return cstr;
					}
				}
			}
		}

		public static IEnumerable<string> PrintAnagram(string str, int start)
		{
			int length = str.Length;
			if (start == (length - 1))
			{
				yield return str;
			}
			else
			{
				for (int index = start; index < length; index++)
				{
					var nstr = Swap(str, start, index);
					foreach (string cstr in PrintAnagram(nstr, start + 1))
					{
						yield return cstr;
					}
				}
			}
		}

		public static string Swap(string str, int pos1, int pos2)
		{
			char[] arr = str.ToCharArray();
			char ch = arr[pos1];
			arr[pos1] = arr[pos2];
			arr[pos2] = ch;
			return new string(arr);
		}

		public static int MinTurns(string current, string target)
		{
			int length = current.Length;
			int totalSteps = 0;
			
			for(int index=0;index<length;index++)
            {
				int start = Convert.ToInt32(current[index])-48;
				int end = Convert.ToInt32(target[index])-48;
				int fwd = ForWardCount(start, end);
				int bwd = BackWardCount(start, end);
				totalSteps += fwd < bwd ? fwd : bwd;
			}

			return totalSteps;
		}

		public static int ForWardCount(int start, int end)
		{
			int step = 0;
			if (start != end)
			{
				while (start != end)
				{
					start++;
					if (start == 10)
					{
						start = 0;
					}
					step++;
				}
			}
			return step;
		}

		public static int BackWardCount(int start, int end)
		{
			int step = 0;
			if (start != end)
			{
				while (start != end)
				{
					start--;
					if (start == -1)
					{
						start = 9;
					}
					step++;
				}
			}

			return step;
		}

		public static double AverageWordLength(string str)
		{
			str = new string(str.ToCharArray().Where(item => item == ' ' || char.IsLetter(item)).ToArray());
			//str = str.Replace(".", "");
			//str = str.Replace("!", "");
			//str = str.Replace(",", "");
			//str = str.Replace("?", "");
			string[] strs = str.Split(' ');
			double avg = Math.Round((double)strs.Select(item => item.Length).Sum() / strs.Count(),2);
			return avg;
		}

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

		public static bool IsSymmetrical(int num)
		{
			string str = num.ToString();
			bool isFlag = true;
			int length = str.Length;
			for (int index = 0; index < length / 2; index++)
			{
				if (str[index] != str[length - index - 1])
				{
					isFlag = false;
					break;
				}
			}
			return isFlag;
		}

		public static int CounterpartCharCode(char symbol)
		{
			if (char.IsLetter(symbol))
			{
				if (char.IsLower(symbol))
				{
					return (int)char.ToUpper(symbol);
				}
				else
				{
					return (int)char.ToLower(symbol);
				}
			}

			return ((int)symbol);
		}

		public static string Maskify(string str)
		{
			if (str.Length <= 4)
			{
				return str;
			}
			
			int length = str.Length;

			return string.Join("",Enumerable.Repeat("#", length - 4)) + str.Substring(length - 4, 4);
		}

		public static string ReverseCase(string str)
		{
			char[] array = str.ToCharArray();
			for (int index = 0; index < array.Length; index++)
			{
				if (array[index] == char.ToLower(array[index]))
				{
					array[index] = char.ToUpper(array[index]);
				}
				else
				{
					array[index] = char.ToLower(array[index]);
				}
			}

			return new string(array);
		}

		public static bool IsIsogram(string str)
        {
			char[] array = str.ToCharArray();
			bool isAny = array.GroupBy(item => char.ToLower(item)).Any(itm => itm.Count() > 1);
			return !isAny;
        }
	}
}
