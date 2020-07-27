using System;
using Flipkart.Automation.Tests.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Flipkart.Automation.Tests
{
    [TestClass]
    [TestCategory("SignIn")]
    public class FlipkartLoginTest : TestBase
    {
        [TestMethod]
        [Description("Test the flipkart aplication with Valid Username and Password.")]
        [TestProperty("Author", "FayyasHussain")]
        public void LoginWithValidInputs()
        {
            var loginPage = new LoginPage(Driver);
            var homePage = new HomePage(Driver);

            Assert.IsTrue(loginPage.IsVisible(), "Login Page did not open successfully");

            // Login with Valid Username and Password
            loginPage.Login(this.TestData.ValidUser.ValidUsername.Value, this.TestData.ValidUser.ValidPassword.Value);

            Assert.IsTrue(homePage.IsVisible(), "Login is failed");
        }

        [TestMethod]
        [Description("Test the flipkart aplication with Invalid Username and Password.")]
        [TestProperty("Author", "FayyasHussain")]
        public void LoginWithInvalidInputs()
        {
            var loginPage = new LoginPage(Driver);
            var homePage = new HomePage(Driver);

            loginPage.CloseDialog();
            Assert.IsTrue(loginPage.IsVisible(), "Login Page did not open successfully");

            loginPage.Login(this.TestData.InvalidUser.InvalidUsername.Value, this.TestData.InvalidUser.InvalidPassword.Value);

            Assert.IsFalse(homePage.IsVisible());
        }

        [TestMethod]
        [Description("Test the flipkart aplication - Logout Functionality.")]
        [TestProperty("Author", "FayyasHussain")]
        public void LogoutTest()
        {
            var loginPage = new LoginPage(Driver);
            var homePage = new HomePage(Driver);

            loginPage.Login(this.TestData.ValidUser.ValidUsername.Value, this.TestData.ValidUser.ValidPassword.Value);
            loginPage.Logout();

            Assert.IsFalse(homePage.IsVisible());
        }
    }

}
