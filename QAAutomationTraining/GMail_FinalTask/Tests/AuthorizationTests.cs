using Allure.NUnit.Attributes;
using GMail_FinalTask.Enum;
using NUnit.Framework;
using Allure.Commons.Model;
using GMail_FinalTask.PageObject;

namespace GMail_FinalTask.Tests
{
    [TestFixture]
    [AllureSuite("Tests for GMail.com")]
    public class AuthorizationTests : BaseTest
    {
        private const string user1 = "seleniumtests30";
        private const string user2 = "seleniumtestsnew20";
        private const string password = "060788avavav";
        private LoginPage loginPage = new LoginPage();
        private HomePage homePage = new HomePage();

        [AllureTest("Verifies Login session for gmail.com.")]
        [AllureSeverity(SeverityLevel.Critical)]
        [AllureOwner("Marina Gotka")]
        [TestCase("seleniumtestsnew20", "060788avavav")]
        [TestCase("seleniumtests30", "060788avavav")]
        public void LoginTest(string username, string password)
        {
            loginPage.Login(username, password);

            Assert.True(homePage.IsLoggedIn(), "User is not logged in");
        }

        [AllureTest("Verifies Logout for gmail.com.")]
        [AllureSeverity(SeverityLevel.Critical)]
        [AllureOwner("Marina Gotka")]
        [TestCase("seleniumtestsnew20", "060788avavav")]
        [TestCase("seleniumtests30", "060788avavav")]
        public void LogoutTest(string username, string password)
        {
            loginPage.Login(username, password);

            Assert.True(homePage.IsLoggedIn(), "User is not logged out");

            homePage.Logout();

            Assert.True(loginPage.IsAt(), "User is not logged out");
        }

        [AllureTest("Verify the ability to send emails")]
        [AllureSeverity(SeverityLevel.Critical)]
        [AllureOwner("Marina Gotka")]
        [Test]
        public void SendEmailToTest()
        {
            loginPage.Login(user1, password);

            Assert.True(homePage.IsLoggedIn(), "User is not logged out");

            homePage.SentEmail(user2);
            homePage.Logout();
            loginPage.Login(user2, password);

            Assert.True(homePage.IsEmailReceived(), "Email is not received");
        }

        [AllureTest("Verify that sent email appears in Sent Mail folder")]
        [AllureSeverity(SeverityLevel.Critical)]
        [AllureOwner("Marina Gotka")]
        [Test]
        public void SentEmailApearedInSentFolderTest()
        {
            loginPage.Login(user1, password);

            Assert.True(homePage.IsLoggedIn(), "User is not logged out");

            homePage.SentEmail(user2);

            Assert.True(homePage.IsEmailExistInFolder(Folders.Sent), "Sent email is not apeared in Sent folder");
        }

        [AllureTest("Verify that deleted email is listed in Trash")]
        [AllureSeverity(SeverityLevel.Critical)]
        [AllureOwner("Marina Gotka")]
        [Test]
        public void DeletedEmailApearedInTrashFolderTest()
        {
            loginPage.Login(user1, password);

            Assert.True(homePage.IsLoggedIn(), "User is not logged out");

            homePage.DeleteLastEmail();

            Assert.True(homePage.IsEmailExistInFolder(Folders.Trash), "Sent email is not apeared in Sent folder");
        }
    }
}
