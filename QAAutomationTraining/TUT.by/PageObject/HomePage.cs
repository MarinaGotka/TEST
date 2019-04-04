using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TUT.by.PageObject
{
    public class HomePage : BasePage
    {
        private readonly IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//*[@id='authorize']/div/a")]
        private IWebElement LoginButton;

        [FindsBy(How = How.CssSelector, Using = "span.uname")]
        private IWebElement UsernameAfterlogin;

        [FindsBy(How = How.XPath, Using = "//*[@id='authorize']//a[contains(@href, 'logout')]")]
        private IWebElement LogoutButton;

        public HomePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void LogInClick()
        {
            LoginButton.Click();
        }

        public bool IsAt() => LoginButton.Displayed;

        public void Logout()
        {
            UsernameAfterlogin.Click();
            LogoutButton.Click();
        }
    }
}