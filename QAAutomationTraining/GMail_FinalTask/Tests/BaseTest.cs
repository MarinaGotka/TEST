using Allure.Commons;
using GMail_FinalTask.PageObject;
using GMail_FinalTask.WebDriver;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;
using OpenQA.Selenium.Remote;
using GMail_FinalTask.Enum;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace GMail_FinalTask.Tests
{
    public class BaseTest : AllureReport, IDisposable
    {
        private readonly string Url = "https://www.gmail.com";
        private readonly string Username = "marinagotka";
        private readonly string Key = "649d181d-8da4-48f7-97ed-9d63e8084057";
        public static Browsers browser;
        public IWebDriver driver;
        public Strategies strategy;

        public BaseTest(Browsers browsers, Strategies strategy)
        {
            browser = browsers;
            this.strategy = strategy;
        }

        [SetUp]
        public void SetUp()
        {
            var Options = GetOptions(browser);

            if (strategy == Strategies.SauceLabs)
            {
                string uri = "http://{0}:{1}" + "@ondemand.eu-central-1.saucelabs.com:80/wd/hub";
                driver = new RemoteWebDriver(new Uri(string.Format(uri, Username, Key)), Options.ToCapabilities(),
                    TimeSpan.FromSeconds(25000));
            }
            else if (strategy == Strategies.SeleniumGrid)
            {
                driver = new RemoteWebDriver(new Uri("http://localhost:4444/wd/hub"), Options.ToCapabilities(),
                    TimeSpan.FromSeconds(25000));
            }
            else
            {
                driver = DriverFactory.GetDriver();
            }
            driver = DriverFactory.GetDriver();
            driver.Navigate().GoToUrl(Url);
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15); // Implicit waiter for WebDriver. 
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

        private DriverOptions GetOptions(Browsers browserName)
        {
            switch (browserName)
            {
                case Browsers.Firefox:
                    FirefoxOptions OptionsFirefox = new FirefoxOptions();
                    return OptionsFirefox;

                case Browsers.Chrome:
                    ChromeOptions OptionsChrome = new ChromeOptions();
                    return OptionsChrome;
                default:
                    throw new NoSuchElementException("Driver is absent");
            }
        }
    }
}
