using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.EventHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitProjectTest
{
    public class UnitTest1
    {
        Calculator calc = null;

        public UnitTest1()
        {
            calc = new Calculator();
        }

        [Fact]
        public void Test1()
        {
            int result = calc.Add(1, 4);
            Assert.True(result == 5);
        }

        [Theory]
        [InlineData(1, 2, 3)]
        [InlineData(10, 5, 15)]
        [InlineData(8, -2, 6)]
        public void InlineDataTest(int num1, int num2, int expected)
        {
            int result = calc.Add(num1, num2);
            Assert.Equal(result, expected);
        }

        [Theory]
        [ClassData(typeof(CalculatorTestData))]
        public void ClassDataTest(int num1, int num2, int expected)
        {
            int result = calc.Add(num1, num2);
            Assert.Equal(result, expected);
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void MemberDataTest(int num1, int num2, int expected)
        {
            int result = calc.Add(num1, num2);
            Assert.Equal(result, expected);
        }

        [Theory]
        [MemberData(nameof(GetData), parameters:3)]
        public void MemberDataWithParamTest(int num1, int num2, int expected)
        {
            int result = calc.Add(num1, num2);
            Assert.Equal(result, expected);
        }

        [Theory]
        [MemberData(nameof(CalculatorTestData.Data), MemberType = typeof(CalculatorTestData))]
        public void MemberDataWithTypeParamTest(int num1, int num2, int expected)
        {
            int result = calc.Add(num1, num2);
            Assert.Equal(result, expected);
        }

        public static IEnumerable<object[]> Data =>
        new List<object[]>
        {
            new object[] { 1, 2, 3 },
            new object[] { -4, -6, -10 },
            new object[] { -2, 2, 0 },
            new object[] { int.MinValue, -1, int.MaxValue },
        };

        public static IEnumerable<object[]> GetData(int num)
        {
            return new List<object[]>
            {
                new object[] { 1, 2, 3 },
                new object[] { -4, -6, -10 },
                new object[] { -2, 2, 0 },
                new object[] { int.MinValue, -1, int.MaxValue },
            }.Take(num);
        }
    }
}
