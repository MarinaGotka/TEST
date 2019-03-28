using GMail_FinalTask.Enum;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Threading;
using GMail_FinalTask.WebDriver;

namespace GMail_FinalTask.PageObject
{
    public class HomePage : BasePage
    {
        private const string emailText = "Hello";
        private const string lastSentMessageString = "//tr[@class = 'zA yO']//span[contains(text(),{0})]";

        private static readonly By _accountIcon = By.XPath("//span[@class = 'gb_ya gbii']");
        private static readonly By _signOutButton = By.CssSelector("#gb_71");
        private static readonly By _toTextArea = By.XPath("//textarea[@name='to']");

        [FindsBy(How = How.XPath, Using = "//span[@class = 'gb_ya gbii']")]
        private readonly IWebElement AccountIcon;

        [FindsBy(How = How.CssSelector, Using = "#gb_71")]
        private readonly IWebElement SignOutButton;

        [FindsBy(How = How.XPath, Using = "//div[@class='z0']/div[@role='button']")]
        private IWebElement NewEmailButton;

        [FindsBy(How = How.XPath, Using = "//div[@role='textbox']")]
        private IWebElement TextArea;

        [FindsBy(How = How.XPath, Using = "//*[@class='T-I J-J5-Ji aoO T-I-atl L3']")]
        private IWebElement SendButton;

        [FindsBy(How = How.XPath, Using = "//a[contains(@href,'sent')]")]
        private IWebElement SentFolder;

        [FindsBy(How = How.XPath, Using = "//div[@data-tooltip='Trash']")]
        private IWebElement TrashFolder;

        [FindsBy(How = How.XPath, Using = "//tr[@class = 'zA zE']//span[@class = 'y2']")]
        private readonly IWebElement LastInboxMessage;

        [FindsBy(How = How.XPath, Using = "//tr[@class = 'zA zE']//span[@class='y2']")]
        private readonly IWebElement LastTrashMessage;

        [FindsBy(How = How.XPath, Using = "//div[@class='T-I J-J5-Ji nX T-I-ax7 T-I-Js-Gs mA']//*[@class='ar9 T-I-J3 J-J5-Ji']")]
        private readonly IWebElement DeleteIcon;

        [FindsBy(How = How.XPath, Using = "//*[@class='CJ']")]
        private readonly IWebElement MoreButton;

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
            _toTextArea.WaitUntilVisible().SendKeys(receiver + "@gmail.com");
            TextArea.SendKeys(emailText);
            SendButton.Click();
            Thread.Sleep(4000);
        }

        public void DeleteLastEmail()
        {
            LastInboxMessage.Click();
            DeleteIcon.ClickJS();
        }

        public bool IsEmailReceived()
        {
            return IsEmailExistInFolder(Folders.Inbox);
        }

        public bool IsEmailExistInFolder(Folders folder)
        {
            switch (folder)
            {
                case Folders.Sent:
                    SentFolder.Click();
                    return DriverFactory.GetDriver().FindElement(By.XPath(string.Format(lastSentMessageString, emailText))).Displayed;
                case Folders.Trash:
                    MoreButton.Click();
                    TrashFolder.Click();
                    return LastTrashMessage.Text.Contains(emailText);
                case Folders.Inbox:
                    return LastInboxMessage.Text.Contains(emailText);
                default:
                    throw new NoSuchElementException("No such folder");
            }
        }
    }
}
