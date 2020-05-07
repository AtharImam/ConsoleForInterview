using System;
using System.Collections.Generic;
using System.Text;

namespace TestConsole
{
    internal class NonNullableType
    {
        public string Name { get; set; } = null!;

        public string? Name1 { get; set; }
    }
}
