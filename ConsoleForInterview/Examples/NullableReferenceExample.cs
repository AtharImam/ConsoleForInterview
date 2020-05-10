namespace ConsoleApp1
{
    class NullableReferenceExample
    {
        public static void Execute()
        {
#nullable enable
            string name = null;
            var myName = name.ToString();
#nullable restore
        }

        class NullableEx
        {
            public string Name { get; set; }// = "Hello World";
        }
    }
}
