using System;
using TechTalk.SpecFlow;
using WebDriverManager.DriverInstance;

namespace Tests.Initialization
{
    [Binding]
    public class Init
    {
        private int waitTime = 15;
        [BeforeScenario]
        public void SetUp()
        {
            Driver.Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(waitTime));
            Driver.Instance.Manage().Window.Maximize();
        }

        [AfterScenario]
        public void TearDown()
        {
            Driver.CloseDriver();
        }
    }
}
