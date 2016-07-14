using NUnit.Framework;
using System;
using TestContext = NUnitTests.Infrastructure.TestContext;

namespace NUnitTests.Tests
{
    [TestFixture]
    public class CosTests
    {
        [TestCaseSource(typeof(NUnitTests.InputData.InputData), "IntList")]
        public void TestForIntValues(int value)
        {
            var expectedResult = Math.Cos(value);

            var actualReault = TestContext.Calculator.Cos(value);
            Assert.AreEqual(expectedResult, actualReault, $"Result must be {expectedResult}, but was {actualReault}. Input values: {value}.");
        }

        [TestCaseSource(typeof(NUnitTests.InputData.InputData), "IntStringList")]
        public void TestForStringIntValues(string value)
        {
            var expectedResult = Math.Cos(int.Parse(value));

            var actualReault = TestContext.Calculator.Cos(value);
            Assert.AreEqual(expectedResult, actualReault, $"Result must be {expectedResult}, but was {actualReault}. Input values: '{value}'.");
        }

        [TestCaseSource(typeof(NUnitTests.InputData.InputData), "DoubleList")]
        public void TestForDoubleValues(double value)
        {
            var expectedResult = Math.Cos(value);

            var actualReault = TestContext.Calculator.Cos(value);
            Assert.AreEqual(expectedResult, actualReault, $"Result must be {expectedResult}, but was {actualReault}. Input value: {value}.");
        }

        [TestCaseSource(typeof(NUnitTests.InputData.InputData), "DoubleStringList")]
        public void TestForStringDoubleValues(string value)
        {
            var expectedResult = Math.Cos(double.Parse(value));

            var actualReault = TestContext.Calculator.Cos(value);
            Assert.AreEqual(expectedResult, actualReault, $"Result must be {expectedResult}, but was {actualReault}. Input value: '{value}'.");
        }

        [TestCase(" ")]
        [TestCase("string")]
        [TestCase("0,55")]
        public void TestForBadStringValues(string value)
        {
            Assert.Catch<NotFiniteNumberException>(() => TestContext.Calculator.Cos(value), "Cos method don't throw exception with bad string values");
        }
    }
}
