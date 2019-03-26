using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace GMail_FinalTask.PageObject
{
    public class HomePage : BasePage
    {
        private const string emailText = "Hello";

        private static readonly By _accountIcon = By.XPath("//span[@class = 'gb_ya gbii']");
        private static readonly By _signOutButton = By.CssSelector("#gb_71");
        private static readonly By _messageSentPopup = By.XPath("//*[contains(text(),'Message sent')]");

        [FindsBy(How = How.XPath, Using = "//span[@class = 'gb_ya gbii']")]
        private readonly IWebElement AccountIcon;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Выйти')]")]
        private readonly IWebElement SignOutButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='z0']/div[@role='button']")]
        private IWebElement NewEmailButton;

        [FindsBy(How = How.XPath, Using = "//textarea[@name='to']")]
        private IWebElement ToTextArea;

        [FindsBy(How = How.XPath, Using = "//div[@role='textbox']")]
        private IWebElement TextArea;

        [FindsBy(How = How.XPath, Using = "//*[contains(@data-tooltip,'Send')]")]
        private IWebElement SendButton;

        [FindsBy(How = How.XPath, Using = "//tr[@class = 'zA zE']//span[@class = 'y2']")]
        private readonly IWebElement LastMessage;

        public bool IsLoggedIn() => AccountIcon.Displayed;

        public void WaitLoadingPage() => WaitUntilDisplayed(_accountIcon);

        public void Logout()
        {
            _accountIcon.WaitUntilVisible().Click();
            _signOutButton.WaitUntilVisible().Click();
        }

        public bool IsAccountIconDisplayed()
        {
            return _accountIcon.IsDisplayed();
        }

        public void SentEmail(string receiver)
        {
            NewEmailButton.Click();
            ToTextArea.SendKeys(receiver + "@gmail.com");
            TextArea.SendKeys(emailText);
            SendButton.Click();
            _messageSentPopup.WaitUntilVisible();
        }

        public bool IsEmailReceived()
        {
            return LastMessage.Text == emailText;
        }
    }
}
