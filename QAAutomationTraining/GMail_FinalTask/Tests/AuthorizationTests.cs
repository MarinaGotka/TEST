using GMail_FinalTask.Enum;
using GMail_FinalTask.PageObject;
using NUnit.Framework;

namespace GMail_FinalTask.Tests
{
    [TestFixture]
    public class AuthorizationTests : BaseTest
    {
        private const string user1 = "seleniumtests30";
        private const string user2 = "seleniumtestsnew20";
        private const string password = "060788avavav";

        LoginPage loginPage = new LoginPage();
        HomePage homePage = new HomePage();

        [TestCase("seleniumtestsnew20", "060788avavav")]
        [TestCase("seleniumtests30", "060788avavav")]
        public void LoginTest(string username, string password)
        {
            loginPage.Login(username, password);

            Assert.True(homePage.IsLoggedIn(), "User is not logged in");
        }

        [TestCase("seleniumtestsnew20", "060788avavav")]
        [TestCase("seleniumtests30", "060788avavav")]
        public void LogoutTest(string username, string password)
        {
            loginPage.Login(username, password);

            Assert.True(homePage.IsLoggedIn(), "User is not logged out");

            homePage.Logout();

            Assert.True(loginPage.IsAt(), "User is not logged out");
        }

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

        [Test]
        public void SentEmailApearedInSentFolderTest()
        {
            loginPage.Login(user1, password);

            Assert.True(homePage.IsLoggedIn(), "User is not logged out");

            homePage.SentEmail(user2);

            Assert.True(homePage.IsEmailExistInFolder(Folders.Sent), "Sent email is not apeared in Sent folder");
        }

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
