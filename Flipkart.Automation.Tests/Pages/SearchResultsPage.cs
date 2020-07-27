using OpenQA.Selenium;
using System;

namespace Flipkart.Automation.Tests.Pages
{
    public class SearchResultsPage : BaseApplicationPage
    {
        private static By searchResults => By.ClassName("_2yAnYN");
        private static By searchProducts => By.ClassName("_3O0U0u");
        private SeleniumDriverWrapper browser;

        public SearchResultsPage(IWebDriver driver) : base(driver)
        {
            browser = new SeleniumDriverWrapper(driver);
        }

        /// <summary>
        /// Checks if the SearchResults are shown
        /// </summary>
        /// <returns></returns>
        public bool IsVisible()
        {
            if (browser.CheckElementExists(searchResults,5000))
            {

                return Driver.FindElement(searchResults).Displayed;
            }
            return false;
        }

        /// <summary>
        /// Clicks on the Random product from the Search results
        /// </summary>
        public void ClickRandomProduct()
        {
            if (browser.CheckElementExists(searchProducts, 5000))
            {
                int count = Driver.FindElements(searchProducts).Count;

                // Find a random number between 0 and 1
                double random = new Random().NextDouble();
                int randomItem = Convert.ToInt32(random * count);

                Driver.FindElement(searchProducts).Click();
            }
        }
    }
}
