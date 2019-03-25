using OpenQA.Selenium;

namespace Test_For_Alerts.PageObject
{
    public class AlertPage
    {
        private const string JsAlertResultMessage = "You successfuly clicked an alert";
        private const string JsConfirmResultMessage = "You clicked: Cancel";
        private const string JsPromptMessage = "You entered: {0}";

        private readonly By ClickForJsAlertButton = By.XPath("//button[@onclick = 'jsAlert()']");
        private readonly By ClickForJsConfirmButton = By.XPath("//button[@onclick = 'jsConfirm()']");
        private readonly By ClickForJsPromptButton = By.XPath("//button[@onclick = 'jsPrompt()']");
        private readonly By Result = By.XPath("//*[@id='result']");
        private readonly IWebDriver driver;
        private IAlert alert;

        public AlertPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void AcceptAlert()
        {
            alert = driver.SwitchTo().Alert();
            alert.Accept();
        }

        public void DissmissAlert()
        {
            alert = driver.SwitchTo().Alert();
            alert.Dismiss();
        }

        public void SendKeysAlert(string text)
        {
            alert = driver.SwitchTo().Alert();
            alert.SendKeys(text);
            AcceptAlert();
        }

        public void ClickForJSAlert()
        {
            driver.FindElement(ClickForJsAlertButton).Click();
            AcceptAlert();
        }

        public void ClickForJSConfirm()
        {
            driver.FindElement(ClickForJsConfirmButton).Click();
            DissmissAlert();
        }

        public void ClickForJSPrompt(string text)
        {
            driver.FindElement(ClickForJsPromptButton).Click();
            SendKeysAlert(text);
        }

        public bool JsAlertIsOKClicked() => driver.FindElement(Result).Text.Equals(JsAlertResultMessage);

        public bool JsConfirmCancelIsClicked() => driver.FindElement(Result).Text.Equals(JsConfirmResultMessage);

        public bool JsPromptIsClickedWithText(string text) => driver.FindElement(Result).Text.Equals(string.Format(JsPromptMessage, text));
    }
}
