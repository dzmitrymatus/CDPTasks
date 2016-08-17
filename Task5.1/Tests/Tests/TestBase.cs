using WebDriver.DriverInstance;
using NUnit.Framework;
using System;
using System.IO;

namespace Tests.Tests
{
    [TestFixture]
    public class TestBase
    {
        [SetUp]
        public void SetUp()
        {
            Directory.SetCurrentDirectory(NUnit.Framework.TestContext.CurrentContext.TestDirectory);
            Driver.Instance.Manage().Window.Maximize();
            Driver.Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }

        [TearDown]
        public void TearDown()
        {
            Driver.CloseDriver();
        }
    }
}
