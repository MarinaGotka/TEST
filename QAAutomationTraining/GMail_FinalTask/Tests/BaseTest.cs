using GMail_FinalTask.PageObject;
using GMail_FinalTask.WebDriver;
using NUnit.Framework;
using System;

namespace GMail_FinalTask.Tests
{
    public class BaseTest : IDisposable
    {
        public BaseTest()
        {
            DriverFactory.GetDriver().Navigate().GoToUrl("https://www.gmail.com");
        }

        [TearDown]
        public void TearDown()
        {
            HomePage homePage = new HomePage();
            if (homePage.IsAccountIconDisplayed())
            {
                homePage.Logout();
            }
        }

        public void Dispose()
        {
            DriverFactory.CloseBrowser();
        }
    }
}
