using System;

namespace ConsoleForInterview.Examples
{
    class EnumBitFieldExample
    {
        public static void Execute()
        {
            string iGrade = (Grade.Low | Grade.High).ToString(); //"5"
            Console.WriteLine(iGrade.ToString());
            GradeFlags fGrade = GradeFlags.Low | GradeFlags.High;//Low|High
            Console.WriteLine(fGrade.ToString()); //Low,High
        }

        enum Grade { Low = 1, Medium = 2, High = 4, Maximum = 8 }
        [Flags]
        enum GradeFlags { Low = 1, Medium = 2, High = 4, Maximum = 8 }

        [Flags]
        public enum Colors
        {
            Red,
            Black,
            White,
            All = Red | Black | White
        }

        [Flags]
        public enum Days
        {
            None = 0b_0000_0000,  // 0
            Monday = 0b_0000_0001,  // 1
            Tuesday = 0b_0000_0010,  // 2
            Wednesday = 0b_0000_0100,  // 4
            Thursday = 0b_0000_1000,  // 8
            Friday = 0b_0001_0000,  // 16
            Saturday = 0b_0010_0000,  // 32
            Sunday = 0b_0100_0000,  // 64
            Weekend = Saturday | Sunday
        }
    }
}
