using NUnit.Framework;
using System.IO;

namespace NUnitTests.Infrastructure
{
    [SetUpFixture]
    public class TestsSetUp
    {
        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            //info https://github.com/nunit/docs/wiki/Breaking-Changes
            Directory.SetCurrentDirectory(NUnit.Framework.TestContext.CurrentContext.TestDirectory);
        }
    }
}
