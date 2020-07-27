using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace Flipkart.Automation.Tests.Pages
{
    public class MyCartPage : BaseApplicationPage
    {
        private static By myCartPage => By.ClassName("_1lBhq8");
        private static By productPrice => By.ClassName("XU9vZa");
        private static By productName => By.ClassName("_3ROAwx");
        private static By cartButton => By.XPath("//span[text()='Cart']");
        private static By removeButton => By.XPath("//div[text()='Remove']");
        private static By removeConfirmationButton => By.ClassName("_2nQDKB");
        private static By homeButton => By.XPath("//img[@alt='Flipkart']");
        private static By placeOrderButton => By.XPath("//button//span[text()='Place Order']");
        private SeleniumDriverWrapper browser;

        public MyCartPage(IWebDriver driver) : base(driver)
        {
            browser = new SeleniumDriverWrapper(driver);
        }

        
        /// <summary>
        /// Checks if MyCartPage is loaded
        /// </summary>
        /// <returns></returns>
        public bool IsLoaded()
        {
            if (browser.CheckElementExists(myCartPage,5000))
            {
                return Driver.FindElement(myCartPage).Displayed;
            }
            return false;
        }
        
        /// <summary>
        /// Remove all items from the My Cart Page
        /// </summary>
        public void RemoveAllItems()
        {
            browser.FindElement(cartButton, 5000).Click();
            if (browser.CheckElementExists(removeButton, 5000))
            {
                while (Driver.FindElement(removeButton).Displayed)
                {
                    Driver.FindElements(removeButton)[1].Click();
                    Driver.FindElement(removeConfirmationButton).Click();
                }
                Driver.FindElement(homeButton).Click();
            }
        }

        /// <summary>
        /// Goes to the my cart page
        /// </summary>
        public void Goto()
        {
            browser.FindElement(myCartPage, 5000).Click();
        }

        /// <summary>
        /// Returns the list of product price and information
        /// </summary>
        /// <returns></returns>
        public List<String> ProductInformation()
        {
            if (browser.CheckElementExists(productPrice, 2000))
            {
                List<String> productInfo = new List<String>();
                productInfo.Add(Driver.FindElement(productPrice).Text);
                productInfo.Add(Driver.FindElement(productName).Text);

                return productInfo;
            }
            return null;
        }

        /// <summary>
        /// Place order on the product
        /// </summary>
        public void PlaceOrder()
        {
            browser.FindElement(placeOrderButton,2000).Click();
        }
    }
}
