using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Chrome;

namespace GMail_FinalTask.WebDriver
{
    public static class DriverFactory
    {
        private static readonly ThreadLocal<IWebDriver> ThreadDriver = new ThreadLocal<IWebDriver>();

        public static IWebDriver GetDriver()
        {
            if (ThreadDriver.Value != null) return ThreadDriver.Value;

            ThreadDriver.Value = new ChromeDriver();

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
