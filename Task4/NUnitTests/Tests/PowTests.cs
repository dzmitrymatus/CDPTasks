using NUnit.Framework;
using System;
using TestContext = NUnitTests.Infrastructure.TestContext;

namespace NUnitTests.Tests
{
    [TestFixture]
    public class PowTests
    {
        [TestCaseSource(typeof(NUnitTests.InputData.InputData), "IntValues")]
        public void TestForIntValues(int firstValue, int secondValue)
        {
            var expectedResult = Math.Pow(firstValue, secondValue);

            var actualReault = TestContext.Calculator.Pow(firstValue, secondValue);
            Assert.AreEqual(expectedResult, actualReault, $"Result must be {expectedResult}, but was {actualReault}. Input values: {firstValue}, {secondValue}.");
        }

        [TestCaseSource(typeof(NUnitTests.InputData.InputData), "IntStringValues")]
        public void TestForStringIntValues(string firstValue, string secondValue)
        {
            var expectedResult = Math.Pow(int.Parse(firstValue), int.Parse(secondValue));

            var actualReault = TestContext.Calculator.Pow(firstValue, secondValue);
            Assert.AreEqual(expectedResult, actualReault, $"Result must be {expectedResult}, but was {actualReault}. Input values: '{firstValue}', '{secondValue}'.");
        }

        [TestCaseSource(typeof(NUnitTests.InputData.InputData), "DoubleValues")]
        public void TestForDoubleValues(double firstValue, double secondValue)
        {
            var expectedResult = Math.Pow(firstValue, secondValue);

            var actualReault = TestContext.Calculator.Pow(firstValue, secondValue);
            Assert.AreEqual(expectedResult, actualReault, $"Result must be {expectedResult}, but was {actualReault}. Input values: {firstValue}, {secondValue}.");
        }

        [TestCaseSource(typeof(NUnitTests.InputData.InputData), "DoubleStringValues")]
        public void TestForStringDoubleValues(string firstValue, string secondValue)
        {
            var expectedResult = Math.Pow(double.Parse(firstValue), double.Parse(secondValue));

            var actualReault = TestContext.Calculator.Pow(firstValue, secondValue);
            Assert.AreEqual(expectedResult, actualReault, $"Result must be {expectedResult}, but was {actualReault}. Input values: '{firstValue}', '{secondValue}'.");
        }

        [TestCase(" ", " ")]
        [TestCase("string", "onemorestring")]
        [TestCase("0,55", "5t")]
        public void TestForBadStringValues(string firstValue, string secondValue)
        {
            Assert.Catch<NotFiniteNumberException>(() => TestContext.Calculator.Pow(firstValue, secondValue), "Pow method don't throw exception with bad string values");
        }
    }
}
