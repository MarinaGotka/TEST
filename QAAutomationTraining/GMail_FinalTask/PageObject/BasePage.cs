using GMail_FinalTask.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace GMail_FinalTask.PageObject
{
    public class BasePage
    {
        private readonly IClock clock = new SystemClock();

        public BasePage()
        {
            PageFactory.InitElements(DriverFactory.GetDriver(), this);
        }

        public void WaitUntilDisplayed(By locator)
        {
            WebElementExtensions.WaitUntilVisible(locator);
        }    
    }
}
