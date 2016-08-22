using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System;

namespace WebDriverManager.DriverInstance.DriverDecorator
{
    public abstract class DriverDecorator : IWebDriver, IJavaScriptExecutor
    {
        private IWebDriver driver;

        public DriverDecorator(IWebDriver driver)
        {
            this.driver = driver;
        }

        public string CurrentWindowHandle
        {
            get
            {
                return driver.CurrentWindowHandle;
            }
        }

        public string PageSource
        {
            get
            {
                return driver.PageSource;
            }
        }

        public string Title
        {
            get
            {
                return driver.Title;
            }
        }

        public string Url
        {
            get
            {
                return driver.Url;
            }

            set
            {
                driver.Url = value;
            }
        }

        public ReadOnlyCollection<string> WindowHandles
        {
            get
            {
                return driver.WindowHandles;
            }
        }

        public void Close()
        {
            driver.Close();
        }

        public void Dispose()
        {
            driver.Dispose();
        }

        public object ExecuteAsyncScript(string script, params object[] args)
        {
            return (driver as IJavaScriptExecutor).ExecuteAsyncScript(script, args);
        }

        public object ExecuteScript(string script, params object[] args)
        {
            return (driver as IJavaScriptExecutor).ExecuteScript(script, args);
        }

        public IWebElement FindElement(By by)
        {
            return driver.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return driver.FindElements(by);
        }

        public IOptions Manage()
        {
            return driver.Manage();
        }

        public INavigation Navigate()
        {
            return driver.Navigate();
        }

        public void Quit()
        {
            driver.Quit();
        }

        public ITargetLocator SwitchTo()
        {
            return driver.SwitchTo();
        }
    }
}
