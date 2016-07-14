using NUnit.Framework;
using System;
using TestContext = NUnitTests.Infrastructure.TestContext;

namespace NUnitTests.Tests
{
    [TestFixture]
    public class isPositiveTests
    {
        [TestCaseSource(typeof(NUnitTests.InputData.InputData), "IntList")]
        public void TestForIntValues(int value)
        {
            var expectedResult = value > 0;

            var actualReault = TestContext.Calculator.isPositive(value);
            Assert.AreEqual(expectedResult, actualReault, $"Result must be {expectedResult.ToString()}, but was {actualReault.ToString()}. Input value: {value}.");
        }

        [TestCaseSource(typeof(NUnitTests.InputData.InputData), "IntStringList")]
        public void TestForStringIntValues(string value)
        {
            var expectedResult = int.Parse(value) > 0;

            var actualReault = TestContext.Calculator.isPositive(value);
            Assert.AreEqual(expectedResult, actualReault, $"Result must be {expectedResult.ToString()}, but was {actualReault.ToString()}. Input value: '{value}'.");
        }

        [TestCaseSource(typeof(NUnitTests.InputData.InputData), "DoubleList")]
        public void TestForDoubleValues(double value)
        {
            var expectedResult = value > 0.0;

            var actualReault = TestContext.Calculator.isPositive(value);
            Assert.AreEqual(expectedResult, actualReault, $"Result must be {expectedResult.ToString()}, but was {actualReault.ToString()}. Input value: {value}.");
        }

        [TestCaseSource(typeof(NUnitTests.InputData.InputData), "DoubleStringList")]
        public void TestForStringDoubleValues(string value)
        {
            var expectedResult = double.Parse(value) > 0.0;

            var actualReault = TestContext.Calculator.isPositive(value);
            Assert.AreEqual(expectedResult, actualReault, $"Result must be {expectedResult.ToString()}, but was {actualReault.ToString()}. Input value: '{value}'.");
        }
    }
}
