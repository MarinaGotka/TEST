using Allure.Commons.Model;
using Allure.NUnit.Attributes;
using NUnit.Framework;
using System.Threading;
using TUT.by.PageObject;
using TUT.by.PageObject.Popup;

namespace TUT.by.Tests
{
    [TestFixture]
    [AllureSuite("Tests for Tut.by")]
    public class TutByTests : BaseTest
    {
        private readonly string UserNameAfterLogin = "Selenium Test";

        [AllureTest("Verifies Login session.")]
        [AllureSeverity(SeverityLevel.Critical)]
        [AllureOwner("Marina Gotka")]
        [TestCase("seleniumtests@tut.by", "123456789zxcvbn")]
        [TestCase("seleniumtests2@tut.by", "123456789zxcvbn")]
        public void LoginTutByTest(string username, string password)
        {
            HomePage homePage = new HomePage(driver);
            LoginPopUp loginPopUp = new LoginPopUp(driver);

            homePage.LogInClick();
            Thread.Sleep(1000); // Explicit wait
            loginPopUp.Login(username, password);

            Assert.True(loginPopUp.LoginAs(UserNameAfterLogin), "Username after login is wrong.");
        }

        [AllureTest("Verifies Logout tut.by.")]
        [AllureSeverity(SeverityLevel.Critical)]
        [AllureOwner("Marina Gotka")]
        [TestCase("seleniumtests@tut.by", "123456789zxcvbn")]
        public void LogoutTutByTest(string username, string password)
        {
            HomePage homePage = new HomePage(driver);
            LoginPopUp loginPopUp = new LoginPopUp(driver);

            homePage.LogInClick();
            Thread.Sleep(1000); // Explicit wait
            loginPopUp.Login(username, password);

            Assert.True(loginPopUp.LoginAs(UserNameAfterLogin), "Username after login is wrong.");

            homePage.Logout();

            Assert.True(homePage.IsAt(), "Home page isn't opened.");
        }
    }
}
