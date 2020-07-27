using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Flipkart.Automation.Tests.Pages
{
    public class HomePage : BaseApplicationPage
    {
        private static By loginMenu => By.XPath("//div[text()='My Account']");
        private static By searchBox => By.Name("q");
        private SeleniumDriverWrapper browser;

        public HomePage(IWebDriver driver) : base(driver)
        {
            browser = new SeleniumDriverWrapper(driver);
        }

        /// <summary>
        /// Checks if the app is logged In.
        /// </summary>
        /// <returns></returns>
        public bool IsVisible()
        {
            var buttonText = browser.FindElement(loginMenu, 2000).Text;
            bool isVisible = buttonText == "My Account" ? true : false;
            return isVisible;
        }

        /// <summary>
        /// Search for the item in product seach box
        /// </summary>
        /// <param name="productToSearch"></param>
        public void Search(string productToSearch)
        {
            Actions builder = new Actions(Driver);
            
            // Click on Search box and type "Camera and "Enter"
            browser.FindElement(searchBox,2000).SendKeys("Camera");
            builder.SendKeys(Keys.Enter);
            builder.Perform();
        }

    }
}