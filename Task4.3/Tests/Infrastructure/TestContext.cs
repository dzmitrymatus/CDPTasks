using Infrastructure.DriverInstance;
using NUnit.Framework;
using System;
using System.IO;

namespace Tests.Tests
{
    [SetUpFixture]
    public class TestContext
    {
        [OneTimeSetUp]
        public void SetUp()
        {
            Directory.SetCurrentDirectory(NUnit.Framework.TestContext.CurrentContext.TestDirectory);
            Driver.Instance.Manage().Window.Maximize();
            Driver.Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            Driver.Instance.Close();
        }
    }
}
