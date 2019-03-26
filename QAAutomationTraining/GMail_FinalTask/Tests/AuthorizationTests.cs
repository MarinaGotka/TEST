using GMail_FinalTask.PageObject;
using NUnit.Framework;

namespace GMail_FinalTask.Tests
{
    [TestFixture]
    public class AuthorizationTests : BaseTest
    {
        private const string user1 = "seleniumtests10";
        private const string user2 = "seleniumtestsnew20";
        private const string password = "060788avavav";

        LoginPage loginPage = new LoginPage();
        HomePage homePage = new HomePage();

        [TestCase("seleniumtestsnew20", "060788avavav")]
        [TestCase("seleniumtests10", "060788avavav")]
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
        public void SendEmailTo()
        {
            loginPage.Login(user1, password);

            Assert.True(homePage.IsLoggedIn(), "User is not logged out");

            homePage.SentEmail(user2);
            homePage.Logout();
            loginPage.Login(user2, password);

            Assert.True(homePage.IsEmailReceived(), "Email is not received");
        }
    }
}
