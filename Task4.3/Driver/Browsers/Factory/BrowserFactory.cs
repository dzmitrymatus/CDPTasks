using Infrastructure.Browsers.Interface;
using System;
using System.Collections.Generic;

namespace Infrastructure.Browsers.Factory
{
    public static class BrowserFactory
    {
        private static Dictionary<string, Func<IBrowser>> browsers = new Dictionary<string, Func<IBrowser>>();
        
        static BrowserFactory()
        {
            browsers.Add("firefox", () => new Firefox());
            //drivers.Add("chrome", () => new Firefox());
            //drivers.Add("opera", () => new Firefox());
        }

        public static IBrowser GetBrowser(string name)
        {
            return browsers.ContainsKey(name) ? browsers[name].Invoke() : browsers["firefox"].Invoke();
        }
    }
}
