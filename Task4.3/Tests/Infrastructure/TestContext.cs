using Infrastructure.DriverInstance;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests.Tests
{
    [SetUpFixture]
    public class TestContext
    {
        [OneTimeSetUp]
        public void SetUp()
        {
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
