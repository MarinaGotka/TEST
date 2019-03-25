using GMail_FinalTask.PageObject;
using NUnit.Framework;

namespace GMail_FinalTask.Tests
{
    [TestFixture]
    public class AuthorizationTests : BaseTest
    {
        LoginPage loginPage = new LoginPage();
        HomePage homePage = new HomePage();
        
        [TestCase("seleniumtests30", "060788avavav")]
        public void LoginTest(string username, string password)
        {
            loginPage.Login(username, password);

            Assert.True(homePage.IsLoggedIn(), "User is not logged in");
        }
        
        [TestCase("seleniumtests30", "060788avavav")]
        public void LogoutTest(string username, string password)
        {
            loginPage.Login(username, password);

            Assert.True(homePage.IsLoggedIn(), "User is not logged out");

            homePage.Logout();

            Assert.True(loginPage.IsAt(), "User is not logged out");
        }
    }
}
