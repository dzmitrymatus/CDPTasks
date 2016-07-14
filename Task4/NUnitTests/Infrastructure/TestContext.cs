using System;
using CSharpCalculator;

namespace NUnitTests.Infrastructure
{
    public static class TestContext
    {
        private static readonly Lazy<Calculator> instance = new Lazy<Calculator>(() => new Calculator());

        public static Calculator Calculator
        {
            get { return instance.Value; }
        }
    }
}
