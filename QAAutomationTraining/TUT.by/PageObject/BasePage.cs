using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;

namespace TUT.by.PageObject
{
    public class BasePage
    {
        private readonly IClock clock = new SystemClock();
        private readonly IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void WaitUntilDisplayed(IWebElement elementForWait)
        {
            //Polling frequency 500 ms is added 
            var element = new WebDriverWait(clock, driver, TimeSpan.FromSeconds(15), TimeSpan.FromMilliseconds(500)).Until(condition =>
            {
                try
                {
                    return elementForWait.Displayed;
                }
                catch (Exception)
                {
                    return false;
                }
            });
        }
    }
}
