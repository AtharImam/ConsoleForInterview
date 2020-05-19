using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleForInterview.Examples
{
	class LargestConcurrentStringExample
	{
		public static void Execute()
		{
			string sample = "aahhjjjjffbnjjk";
			var res = sample.GroupBy(p => p)
						  .Select((p) => new { Count = p.Count(), Char = p.Key })
						  .GroupBy(p => p.Count, p => p.Char)
						  .OrderByDescending(p => p.Key)
						  .First();
			
			foreach (var r in res)
			{
				Console.WriteLine("{0}: {1}", res.Key, r);

				string text = "aahhjjjjfffbnjjk";
				char maxC = ' ';
				int MaxCount = 0;
				char currentChar;
				string ms = String.Empty;
				while (text.Length > 0)
				{
					currentChar = text[0];
					int strLen = text.Length;
					text = text.Replace(currentChar.ToString(), "");
					strLen = strLen - text.Length;
					if (MaxCount < strLen)
					{
						MaxCount = strLen;
						maxC = currentChar;
					}
				}
				Console.WriteLine(maxC);
				Console.WriteLine(MaxCount);
			}
		}

		public static void LargestConsecutiveSubstring()
		{
			string sample = "aahhjjjjffbnjjk";
			string longestRun = new string(sample.Select((c, index) => sample
																	 .Substring(index)
																	 .TakeWhile(e => e == c))
													  .OrderByDescending(e => e.Count())
													  .First()
													  .ToArray());

			Console.WriteLine(longestRun);

			string text = "aahhjjjjffffffbnjjk";
			string cs = text[0].ToString();
			string ms = String.Empty;
			for (int i = 1; i < text.Length; i++)
			{
				if (text[i - 1] == text[i])
				{
					cs += text[i];
				}
				else
				{
					if (ms.Length < cs.Length)
					{
						ms = cs;
					}
					cs = text[i].ToString();
				}
			}

			Console.WriteLine(ms);
		}
	}
}
