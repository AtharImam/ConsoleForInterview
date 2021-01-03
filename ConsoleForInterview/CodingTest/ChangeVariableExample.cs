
namespace ConsoleForInterview.CodingTest
{
    public class ChangeVariableExample
    {
        public static void Execute()
        {
            string variable = "_enable_channel_avability";// "this_is_a_variable";
            System.Console.WriteLine(ChangeVariable(variable));
            variable = "thisIsAVariable";
            System.Console.WriteLine(ChangeVariable(variable));
        }

        static string ChangeVariable(string origStr)
        {
            System.Console.WriteLine($"Original String : {origStr}");
            string result = string.Empty;
            for(int index = 0; index < origStr.Length; index++)
            {
                char ch = origStr[index];
                if (ch == '_')
                {
                    if (index < (origStr.Length - 1))
                    {
                        if (result == string.Empty)
                        {
                            result += origStr[index + 1];
                        }
                        else
                        {
                            result += char.ToUpper(origStr[index + 1]);
                        }
                        index++;
                    }
                }
                else if (char.IsUpper(ch))
                {
                    result += '_'.ToString() + char.ToLower(ch);
                }
                else
                {
                    result += ch;
                }
            }

            return result;
        }
    }
}
