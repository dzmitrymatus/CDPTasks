using NUnit.Framework;
using System;
using TestContext = NUnitTests.Infrastructure.TestContext;

namespace NUnitTests.Tests
{
    [TestFixture]
    public class SqrtTests
    {
        [TestCaseSource(typeof(NUnitTests.InputData.InputData), "IntList")]
        public void TestForIntValues(int value)
        {
            var expectedResult = Math.Sqrt(value);

            var actualReault = TestContext.Calculator.Sqrt(value);
            Assert.AreEqual(expectedResult, actualReault, $"Result must be {expectedResult}, but was {actualReault}. Input values: {value}.");
        }

        [TestCaseSource(typeof(NUnitTests.InputData.InputData), "IntStringList")]
        public void TestForStringIntValues(string value)
        {
            var expectedResult = Math.Sqrt(int.Parse(value));

            var actualReault = TestContext.Calculator.Sqrt(value);
            Assert.AreEqual(expectedResult, actualReault, $"Result must be {expectedResult}, but was {actualReault}. Input values: '{value}'.");
        }

        [TestCaseSource(typeof(NUnitTests.InputData.InputData), "DoubleList")]
        public void TestForDoubleValues(double value)
        {
            var expectedResult = Math.Sqrt(value);

            var actualReault = TestContext.Calculator.Sqrt(value);
            Assert.AreEqual(expectedResult, actualReault, $"Result must be {expectedResult}, but was {actualReault}. Input value: {value}.");
        }

        [TestCaseSource(typeof(NUnitTests.InputData.InputData), "DoubleStringList")]
        public void TestForStringDoubleValues(string value)
        {
            var expectedResult = Math.Sqrt(double.Parse(value));

            var actualReault = TestContext.Calculator.Sqrt(value);
            Assert.AreEqual(expectedResult, actualReault, $"Result must be {expectedResult}, but was {actualReault}. Input value: '{value}'.");
        }

        [TestCase(" ")]
        [TestCase("string")]
        [TestCase("0,55")]
        public void TestForBadStringValues(string value)
        {
            Assert.Catch<NotFiniteNumberException>(() => TestContext.Calculator.Sqrt(value), "Sqrt method don't throw exception with bad string values");
        }
    }
}
