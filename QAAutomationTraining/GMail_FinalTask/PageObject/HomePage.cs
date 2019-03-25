using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace GMail_FinalTask.PageObject
{
    public class HomePage : BasePage
    {
        private static readonly By _accountIcon = By.XPath("//span[@class = 'gb_ya gbii']");
        private static readonly By _signOutButton = By.XPath("//*[contains(text(),'Выйти')]");

        [FindsBy(How = How.XPath, Using = "//span[@class = 'gb_ya gbii']")]
        private readonly IWebElement AccountIcon;

        [FindsBy(How = How.XPath, Using = "//*[contains(text(),'Выйти')]")]
        private readonly IWebElement SignOutButton;

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

    }
}
