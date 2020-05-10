using System;

namespace ConsoleForInterview
{
    public class EnumExample
    {
        public static void Execute()
        {
            Console.WriteLine("Enum Values");
            short[] values = (short[]) Enum.GetValues(typeof(EmployeeType));
            foreach(short value in values)
            {
                Console.Write(value+" ");
            }

            Console.WriteLine("\nEnum Names");
            string[] names = (string[])Enum.GetNames(typeof(EmployeeType));
            foreach (string name in names)
            {
                Console.Write(name + " ");
            }

            EmployeeType empType = (EmployeeType)3;// EmployeeType.Engineer;
            Season season = (Season)empType;
            int enumValue = (int)empType;
            Console.WriteLine("\nName:  {0}, Value: {1}, SeasonType: {2}", Enum.GetName(typeof(EmployeeType), empType), enumValue, season);
        }

        enum EmployeeType : short
        {
            Manager,
            HR,
            Admin,
            Engineer
        }

        enum Season : short
        {
            Winter,
            Summer,
            Autumn,
            Rainy
        }
    }
}
