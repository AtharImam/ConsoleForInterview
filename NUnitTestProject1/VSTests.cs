using ConsoleForInterview.CodingTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProject1
{
    [TestClass]
    public class VSTests
    {
        [TestMethod]
        public void IsPrime_InputIs1_ReturnFalse()
        {
            Calculator calc = new Calculator();
            var result = calc.Add(3,4);

            Assert.AreEqual(7, result);
        }
    }
}
