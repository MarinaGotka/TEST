using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TUT.by.PageObject.Popup
{
    public class LoginPopUp : BasePage
    {
        private readonly IWebDriver driver;

        [FindsBy(How = How.CssSelector, Using = "input[name = 'login']")]
        private IWebElement UsernameField;

        [FindsBy(How = How.XPath, Using = "//input[@name = 'password']")]
        private IWebElement PasswordField;

        [FindsBy(How = How.XPath, Using = "//input[contains(@type, 'submit')]")]
        private IWebElement LoginButton;

        [FindsBy(How = How.CssSelector, Using = "span.uname")]
        private IWebElement UsernameAfterlogin;


        public LoginPopUp(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        public void Login(string username, string password)
        {
            UsernameField.SendKeys(username);
            PasswordField.SendKeys(password);
            LoginButton.Click();
        }

        public bool LoginAs(string username)
        {
            WaitUntilDisplayed(UsernameAfterlogin); //Method with explicit waiter

            return UsernameAfterlogin.Text.Equals(username);
        }
    }
}