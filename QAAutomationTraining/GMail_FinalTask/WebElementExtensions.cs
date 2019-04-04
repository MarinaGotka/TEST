using GMail_FinalTask.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using static SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace GMail_FinalTask
{
    public static class WebElementExtensions
    {
        public static IWebElement WaitUntilVisible(this By locator, int secondsToWait = 15)
        {
            var wait = new WebDriverWait(DriverFactory.GetDriver(), TimeSpan.FromSeconds(secondsToWait));
            wait.Until(ElementIsVisible(locator));

            return DriverFactory.GetDriver().FindElement(locator);
        }

        public static void ClickJS(this IWebElement element)
        {
            ((IJavaScriptExecutor)DriverFactory.GetDriver()).ExecuteScript("arguments[0].click();", element);
        }


        public static bool IsDisplayed(this By locator, int secondsToWait = 5)
        {
            try
            {
                WaitUntilVisible(locator, secondsToWait);
            }
            catch (WebDriverException)
            {
                return false;
            }

            return true;
        }
    }
}
