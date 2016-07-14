using NUnit.Framework;
using System;
using TestContext = NUnitTests.Infrastructure.TestContext;

namespace NUnitTests.Tests
{
    [TestFixture]
    public class DivideTests
    {
        [TestCaseSource(typeof(NUnitTests.InputData.InputData), "DoubleValues")]
        public void TestForDoubleValues(double firstValue, double secondValue)
        {
            var expectedResult = firstValue / secondValue;

            var actualReault = TestContext.Calculator.Divide(firstValue, secondValue);
            Assert.AreEqual(expectedResult, actualReault, $"Result must be {expectedResult}, but was {actualReault}. Input values: {firstValue}, {secondValue}.");
        }
    }
}
