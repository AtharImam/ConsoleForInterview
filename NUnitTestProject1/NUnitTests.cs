using ConsoleForInterview.CodingTest;
using NUnit.Framework;
using Rhino.Mocks;
using System;
using Unity;

namespace NUnitTestProject1
{
    [TestFixture]
    public class NUnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("ABAB", "CDCD", ExpectedResult = true)]
        [TestCase("AAABBB", "CCCDDD", ExpectedResult = true)]
        [TestCase("ABCBA", "BCDCB", ExpectedResult = true)]
        [TestCase("AAAA", "BBBB", ExpectedResult = true)]
        [TestCase("BAAB", "ABBA", ExpectedResult = true)]
        [TestCase("BAAB", "QZZQ", ExpectedResult = true)]
        [TestCase("TTZZVV", "PPSSBB", ExpectedResult = true)]
        [TestCase("ZYX", "ABC", ExpectedResult = true)]
        [TestCase("AABAA", "SSCSS", ExpectedResult = true)]
        [TestCase("AABAABAA", "SSCSSCSS", ExpectedResult = true)]
        [TestCase("UBUBUBUB", "WEWEWEWE", ExpectedResult = true)]
        [TestCase("FFGG", "FFG", ExpectedResult = false)]
        [TestCase("FFGG", "CDCD", ExpectedResult = false)]
        [TestCase("FFFG", "GGHI", ExpectedResult = false)]
        [TestCase("FFFF", "ABCD", ExpectedResult = false)]
        [TestCase("ABCA", "ABCD", ExpectedResult = false)]
        [TestCase("ABCAAA", "DDABCD", ExpectedResult = false)]
        public static bool SameLetterPattern(string str1, string str2)
        {
            Console.WriteLine($"Input: {str1}, {str2}");
            return MediumTest.SameLetterPattern(str1, str2);
        }

        [Test]
        [TestCase(new int[] { 3, 4, 5, 4, 3 }, ExpectedResult = "mountain")]
        [TestCase(new int[] { 9, 7, 3, 1, 2, 4 }, ExpectedResult = "valley")]
        [TestCase(new int[] { 9, 8, 9 }, ExpectedResult = "valley")]
        [TestCase(new int[] { 9, 8, 9, 8 }, ExpectedResult = "neither", Description = "2 peaks")]
        [TestCase(new int[] { 1, 3, 5, 4, 3, 2 }, ExpectedResult = "mountain")]
        [TestCase(new int[] { -1, 0, -1 }, ExpectedResult = "mountain")]
        [TestCase(new int[] { 10, 9, 8, 7, 2, 3, 4, 5 }, ExpectedResult = "valley")]
        [TestCase(new int[] { 350, 100, 200, 400, 700 }, ExpectedResult = "valley")]
        [TestCase(new int[] { -1, -1, 0, -1, -1 }, ExpectedResult = "mountain")]
        [TestCase(new int[] { 0, -1, -1, 0, -1, -1 }, ExpectedResult = "neither", Description = "2 peaks + boundary")]
        [TestCase(new int[] { 1, 2, 3, 2, 4, 1 }, ExpectedResult = "neither", Description = "2 peaks")]
        [TestCase(new int[] { 5, 4, 3, 2, 1 }, ExpectedResult = "neither", Description = "boundary")]
        [TestCase(new int[] { 1, 2, 3, 4 }, ExpectedResult = "neither", Description = "boundary")]
        public static string LandscapeType(int[] arr)
        {
            Console.WriteLine($"Input: {arr}");
            return MediumTest.LandscapeType(arr);
        }

        [Test]
        [TestCase("one one one one zero zero zero zero", ExpectedResult = "11110000")]
        [TestCase("one Zero zero one zero zero one one one one one zero oNe one one zero one zerO", ExpectedResult = "1001001111101110")]
        [TestCase("one zero one", ExpectedResult = "")]
        [TestCase("one zero zero one zero ten one one one one two", ExpectedResult = "10010111")]
        [TestCase("One zero zero one zero one one one zero one one zero zero zero zero one zero one one one zero one one zero zero zero zero one zero one one one zero one one zero zero zero zero one zero one one one zero one one zero zero zero zero one zero one one one zero one one zero zero zero zero one zero", ExpectedResult = "1001011101100001011101100001011101100001011101100001011101100001")]
        [TestCase("TWO one zero one one zero one zero", ExpectedResult = "")]
        [TestCase("TWO one zero one one zero one zero one", ExpectedResult = "10110101")]
        public static string TextToNumberBinary(string str)
        {
            Console.WriteLine($"Input: {str}");
            return MediumTest.TextToNumberBinary(str);
        }

        [Test]
        [TestCase("eA2a1E", ExpectedResult = "aAeE12")]
        [TestCase("Re4r", ExpectedResult = "erR4")]
        [TestCase("6jnM31Q", ExpectedResult = "jMnQ136")]
        [TestCase("f5Eex", ExpectedResult = "eEfx5")]
        [TestCase("846ZIbo", ExpectedResult = "bIoZ468")]
        [TestCase("2lZduOg1jB8SPXf5rakC37wIE094Qvm6Tnyh", ExpectedResult = "aBCdEfghIjklmnOPQrSTuvwXyZ0123456789")]
        public static string FixedSortingTest(string str)
        {
            return MediumTest.Sorting(str);
        }

        [Test]
        // INVALID PASSWORDS
        [TestCase("P1zz@", ExpectedResult = false)]
        [TestCase("P1zz@P1zz@P1zz@P1zz@P1zz@", ExpectedResult = false)]
        [TestCase("mypassword11", ExpectedResult = false)]
        [TestCase("MYPASSWORD11", ExpectedResult = false)]
        [TestCase("iLoveYou", ExpectedResult = false)]
        [TestCase("Pè7$areLove", ExpectedResult = false)]
        [TestCase("Repeeea7!", ExpectedResult = false)]
        // VALID PASSWORDS
        [TestCase("H4(k+x0", ExpectedResult = true)]
        [TestCase("Fhg93@", ExpectedResult = true)]
        [TestCase("aA0!@#$%^&*()+=_-{}[]:;\"", ExpectedResult = true)]
        [TestCase("zZ9'?<>,.", ExpectedResult = true)]
        public static bool FixedTest(string password)
        {
            return MediumTest.ValidatePassword(password);
        }

        [Test]
        [TestCase("car", "race", ExpectedResult = true)]
        [TestCase("nod", "done", ExpectedResult = true)]
        [TestCase("bag", "grab", ExpectedResult = false)]
        [TestCase("car", "race", ExpectedResult = true)]
        [TestCase("nod", "done", ExpectedResult = true)]
        [TestCase("sap", "spatula", ExpectedResult = true)]
        [TestCase("sat", "spatula", ExpectedResult = false)]
        [TestCase("vein", "universal", ExpectedResult = true)]
        [TestCase("salt", "universal", ExpectedResult = false)]
        [TestCase("roast", "pastoral", ExpectedResult = true)]
        [TestCase("altar", "pastoral", ExpectedResult = false)]
        public static bool IsAnagram(string current, string target)
        {
            Console.WriteLine($"Input: {current}, {target}");
            return MediumTest.AnagramStrStr(current, target);
        }

        [Test]
        [TestCase("4089", "5672", ExpectedResult = 9)]
        [TestCase("1732", "4444", ExpectedResult = 9)]
        [TestCase("7109", "2332", ExpectedResult = 13)]
        [TestCase("2391", "4984", ExpectedResult = 10)]
        [TestCase("1234", "3456", ExpectedResult = 8)]
        [TestCase("1111", "1100", ExpectedResult = 2)]
        [TestCase("1111", "0000", ExpectedResult = 4)]
        [TestCase("0000", "9999", ExpectedResult = 4)]
        public static int MinTurns(string current, string target)
        {
            Console.WriteLine($"Input: {current}, {target}");
            return MediumTest.MinTurns(current, target);
        }

        //[Test]
        //[TestCase("A B C.", ExpectedResult = 1.00)]
        //[TestCase("What a gorgeous day.", ExpectedResult = 4.00)]
        //[TestCase("Dude, this is so awesome!", ExpectedResult = 3.80)]
        //[TestCase("Working on my tan right now.", ExpectedResult = 3.67)]
        //[TestCase("Having a blast partying in Las Vegas.", ExpectedResult = 4.29)]
        //[TestCase("Have you ever wondered what Saturn looks like?", ExpectedResult = 4.75)]
        //[TestCase("I just planted a young oak tree, wonder how tall it will grow in a few years?", ExpectedResult = 3.47)]
        public static double AverageWordLength(string str)
        {
            Console.WriteLine($"Input: {str}");
            return MediumTest.AverageWordLength(str);
        }

       // [Test]
        public void GenericTests()
        {
            double[] haystack_1 = new double[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, -11, -12, -13, -14, -15 };
            double[] haystack_2 = new double[] { 92, 6, 73, -77, 81, -90, 99, 8, -85, 34 };
            double[] haystack_3 = new double[] { 91, -4, 80, -73, -28 };
            double[] haystack_4 = new double[] { };
            double[] haystack_5 = new double[] { 69, 100, 28, 47, 53, -61, -24 };
            double[] haystack_6 = new double[] { 5, 7, 9, -3, -7, 61, -24 };
            double[] haystack_7 = new double[] { 0 };
            double[] haystack_8 = new double[] { 98, 51, -19, -97 };
            double[] haystack_9 = new double[] { -42, 3, -51, -64, 69, 77, -20, -5, 68, -76 };
            double[] haystack_10 = new double[] { 0, 0, 0 };

            Assert.AreEqual(new int[] { 10, -65 }, Program.CountPosSumNeg(haystack_1));
            Assert.AreEqual(new int[] { 7, -252 }, Program.CountPosSumNeg(haystack_2));
            Assert.AreEqual(new int[] { 2, -105 }, Program.CountPosSumNeg(haystack_3));
            Assert.AreEqual(new int[] { }, Program.CountPosSumNeg(haystack_4));
            Assert.AreEqual(new int[] { 5, -85 }, Program.CountPosSumNeg(haystack_5));
            Assert.AreEqual(new int[] { 4, -34 }, Program.CountPosSumNeg(haystack_6));
            Assert.AreEqual(new int[] { 0, 0 }, Program.CountPosSumNeg(haystack_7));
            Assert.AreEqual(new int[] { 2, -116 }, Program.CountPosSumNeg(haystack_8));
            Assert.AreEqual(new int[] { 4, -258 }, Program.CountPosSumNeg(haystack_9));
            Assert.AreEqual(new int[] { 0, 0 }, Program.CountPosSumNeg(haystack_10));
        }

        [Test]
        public void TestCarUnityRhino()
        {
            IUnityContainer container = new UnityContainer();
            var car = MockRepository.GenerateStub<MockTest.ICar>();
            bool isCarRun = false;
            car.Stub(m => m.Run()).Callback(() =>
            {
                isCarRun = true;
                return true;
            }).Return(3);
            container.RegisterInstance(car);
            MockTest mockTest = new MockTest(container);
            int res = mockTest.DoRun();
            Assert.AreEqual(3, res);
            Assert.AreEqual(isCarRun, true);
        }
    }
}