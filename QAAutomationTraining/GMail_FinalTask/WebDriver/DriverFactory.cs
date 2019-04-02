using OpenQA.Selenium;
using System.Threading;
using GMail_FinalTask.Enum;
using GMail_FinalTask.Tests;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace GMail_FinalTask.WebDriver
{
    public static class DriverFactory
    {
        private static readonly ThreadLocal<IWebDriver> ThreadDriver = new ThreadLocal<IWebDriver>();

        public static IWebDriver GetDriver()
        {
            if (ThreadDriver.Value != null) return ThreadDriver.Value;

            if (BaseTest.browser == Browsers.Chrome)
                ThreadDriver.Value = new ChromeDriver();
            else if (BaseTest.browser == Browsers.Firefox)
                ThreadDriver.Value = new FirefoxDriver();

            return ThreadDriver.Value;
        }

        public static void CloseBrowser()
        {
            if (ThreadDriver.Value == null) return;

            ThreadDriver.Value.Close();
            ThreadDriver.Value = null;
        }
    }
}
