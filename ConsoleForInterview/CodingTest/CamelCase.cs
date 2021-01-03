using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleForInterview.CodingTest
{
    public static class CamelCase
    {
		public static void Execute()
        {
			string str = "_enable_channel_avability";// "project_name"
			Console.WriteLine(ToCamelCaseChar(str));
        }

		public static string ToCamelCaseChar(string text)
		{
			char[] a = text.ToLower().ToCharArray();

			for (int i = 1; i < a.Length; i++)
			{
				a[i] = a[i - 1] == '_' ? char.ToUpper(a[i]) : a[i];
			}

			return new string(a);
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
	}
}
