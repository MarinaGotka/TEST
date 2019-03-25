using Allure.Commons;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.IO;

namespace TUT.by.Tests
{
    public class BaseTest : AllureReport
    {
        private readonly string Url = "https://www.tut.by/";
        public IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            ChromeOptions Options = new ChromeOptions();
            Options.PlatformName = "WIN10";
            driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), Options.ToCapabilities(), TimeSpan.FromSeconds(25000));
            driver.Navigate().GoToUrl(Url);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15); // Implicit waiter for WebDriver. 
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.Out == TestContext.Error)
            {
                TakeScreenshot();
            }

            driver.Quit();
        }

        public void TakeScreenshot()
        {
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(Path.Combine(Environment.CurrentDirectory, "Screenshot " + TestContext.CurrentContext.Test.MethodName.ToString()), ScreenshotImageFormat.Jpeg);
        }
    }
}
