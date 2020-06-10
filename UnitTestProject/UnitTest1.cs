using ConsoleForInterview.CodingTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Rhino.Mocks;
using System;
using Unity;
using MockRepository = Rhino.Mocks.MockRepository;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckAdd()
        {
            Calculator calc = new Calculator();
            var result = calc.Add(3, 4);
            Assert.AreEqual(7, result);
        }

        [DataTestMethod]
        [DataRow(1,2,3)]
        [DataRow(3, 4, 7)]
        public void CheckAddByData(int x,int y, int result)
        {
            Calculator calc = new Calculator();
            int res = calc.Add(x, y);
            Assert.AreEqual(res, result);
        }

        [TestMethod]
        public void TestCarUnity()
        {
            IUnityContainer container = new UnityContainer();
            Mock<MockTest.ICar> car = new Mock<MockTest.ICar>();
            bool isCarRun = false;
            car.Setup(m => m.Run()).Callback(()=>
            {
                isCarRun = true;
            }).Returns(3);
            container.RegisterInstance(car.Object);
            MockTest mockTest = new MockTest(container);
            int res = mockTest.DoRun();
            Assert.AreEqual(3, res);
            Assert.AreEqual(isCarRun, true);
        }

        
    }
}
