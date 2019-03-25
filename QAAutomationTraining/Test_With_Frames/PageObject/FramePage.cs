using OpenQA.Selenium;

namespace Test_With_Frames.PageObject
{
    public class Frame
    {
        public static readonly By FrameById = By.Id("mce_0_ifr");
        private readonly By TextArea = By.Id("tinymce");
        private readonly By BoldButton = By.XPath("//div[@aria-label='Bold']/button");
        private readonly By TextWithBoldFont = By.XPath("//*[@id='_mce_caret']/strong");
        private readonly IWebDriver driver;

        public Frame(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void ClearTextArea()
        {
            var textArea = driver.FindElement(TextArea);
            textArea.Clear();
        }

        public bool TextAreaIsCleared()
        {
            var textArea = driver.FindElement(TextArea);
            return textArea.Text.Equals(string.Empty);
        }

        public void EnterText(string text)
        {
            var textArea = driver.FindElement(TextArea);
            textArea.SendKeys(text);
        }

        public bool TextIsEntered(string text)
        {
            return driver.FindElement(TextArea).Text.Equals(text);
        }

        public bool TextIsBold(string text)
        {
            var textArea = driver.FindElement(TextWithBoldFont);
            return textArea.Text.Equals(text);
        }

        public void SetBoldFont()
        {
            driver.SwitchTo().DefaultContent();
            driver.FindElement(BoldButton).Click();
            driver.SwitchTo().Frame(driver.FindElement(FrameById));
        }
    }
}
