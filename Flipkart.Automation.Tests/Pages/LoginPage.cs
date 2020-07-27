using OpenQA.Selenium;

namespace Flipkart.Automation.Tests.Pages
{
    public class LoginPage : BaseApplicationPage
    {
        private static By loginButton => By.XPath("//button//span[text()='Login']");
        private static By loginMenu => By.XPath("//a[text()='Login']");
        private static By userNameTextBox => By.XPath("//span[text()='Enter Email/Mobile number']//ancestor::form//input[@type='text']");
        private static By passwordTextBox => By.XPath("//input[@type='password']");
        private static By closeDialog => By.XPath("//button[text='✕']");
        private static By myAccount => By.XPath("//div[text()='My Account']");
        private static By logout => By.XPath("//li//div[text()='Logout']");

        private SeleniumDriverWrapper browser;

        public LoginPage(IWebDriver driver) : base(driver)
        {
            browser = new SeleniumDriverWrapper(driver);
        }

        /// <summary>
        ///  Checks if the application logged in menu is visible
        /// </summary>
        /// <returns></returns>
        public bool IsVisible()
        {
            var buttonText = browser.FindElement(loginMenu, 2000).Text;
            bool isVisible = buttonText == "Login" ? true : false;
            return isVisible;
        }

        /// <summary>
        /// Logs in to the application
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        public void Login(string userName, string password)
        {
            CloseDialog();
            browser.FindElement(loginMenu, 10000).Click();

            browser.FindElement(userNameTextBox, 500).SendKeys(userName);
            browser.FindElement(passwordTextBox, 500).SendKeys(password);
            browser.FindElement(loginButton,500).Click();
        }

        /// <summary>
        /// Closes the dialog
        /// </summary>
        public void CloseDialog()
        {
            if(browser.CheckElementExists(closeDialog, 2000))
            {
                browser.FindElement(closeDialog, 2000).Click();
            }
        }

        /// <summary>
        /// Logouts from the application
        /// </summary>
        public void Logout()
        {
            browser.FindElement(myAccount, 2000).Click();
            browser.FindElement(logout, 2000).Click();
        }
    }
}