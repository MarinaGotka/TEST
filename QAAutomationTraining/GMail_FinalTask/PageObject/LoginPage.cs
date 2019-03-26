using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace GMail_FinalTask.PageObject
{
    public class LoginPage : BasePage
    {
        private readonly By passwordTextField = By.XPath("//input[@type = 'password']");
        private readonly By usernameTextField = By.XPath("//input[@type = 'email']");
        private readonly By nextButton = By.XPath("//*[contains(@id,'Next')]");
        private readonly By profileIdentifier = By.CssSelector("#profileIdentifier");
        private readonly By useAnotherAccoutnButton = By.XPath("//div[contains(text(),'Use another account')]");
        private readonly By lastMessage = By.XPath("//tr[@class = 'zA zE']//span[@class = 'y2']");

        [FindsBy(How = How.XPath, Using = "//input[@type = 'email']")]
        private readonly IWebElement UsernameTextField;

        [FindsBy(How = How.XPath, Using = "//input[@type = 'password']")]
        private readonly IWebElement PasswordTextField;

        [FindsBy(How = How.XPath, Using = "//*[contains(@id,'Next')]")]
        private readonly IWebElement NextButton;

        public bool IsAt() => NextButton.Displayed;

        public void Login(string username, string password)
        {
            if (PasswordTextField.Displayed)
            {
                UseAnotherAccount(username, password);
            }

            usernameTextField.WaitUntilVisible().SendKeys(username);
            NextButton.Click();
            passwordTextField.WaitUntilVisible().SendKeys(password);
            NextButton.Click();
            (new HomePage()).WaitLoadingPage();
        }

        public void UseAnotherAccount(string username, string password)
        {
            profileIdentifier.WaitUntilVisible().Click();
            useAnotherAccoutnButton.WaitUntilVisible().Click();
        }
    }
}
