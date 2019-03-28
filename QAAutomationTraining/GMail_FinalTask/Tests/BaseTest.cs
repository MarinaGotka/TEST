using Allure.Commons;
using GMail_FinalTask.PageObject;
using GMail_FinalTask.WebDriver;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;

namespace GMail_FinalTask.Tests
{
    public class BaseTest : AllureReport, IDisposable
    {
        public BaseTest()
        {
            DriverFactory.GetDriver().Navigate().GoToUrl("https://www.gmail.com");
            DriverFactory.GetDriver().Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            HomePage homePage = new HomePage();
            if (homePage.IsAccountIconDisplayed())
            {
                homePage.Logout();
            }
            if (TestContext.Out == TestContext.Error)
            {
                TakeScreenshot();
            }
        }

        public void TakeScreenshot()
        {
            Screenshot screenshot = ((ITakesScreenshot)DriverFactory.GetDriver()).GetScreenshot();
            screenshot.SaveAsFile(Path.Combine(Environment.CurrentDirectory, "Screenshot " + TestContext.CurrentContext.Test.Name.ToString()), ScreenshotImageFormat.Jpeg);
        }

        public void Dispose()
        {
            DriverFactory.CloseBrowser();
        }
    }
}
