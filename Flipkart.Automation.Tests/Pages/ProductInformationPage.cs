using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace Flipkart.Automation.Tests.Pages
{
    public class ProductInformationPage : BaseApplicationPage
    {
        private static By addToCartButton => By.XPath("//button[text()='ADD TO CART']");
        private static By buyNowButton => By.XPath("//button[text()='BUY NOW']");
        private static By productPrice => By.ClassName("_3qQ9m1");
        private static By productName => By.ClassName("_35KyD6");
        private SeleniumDriverWrapper browser;

        public ProductInformationPage(IWebDriver driver) : base(driver)
        {
            browser = new SeleniumDriverWrapper(driver);
        }

        /// <summary>
        /// Checks and validate if the Add to cart and Buy now items are available
        /// </summary>
        /// <returns></returns>
        public bool IsVisible()
        {
            if (browser.CheckElementExists(addToCartButton, 5000))
            {
                bool addToCartExists = Driver.FindElement(addToCartButton).Displayed;
                bool buyNowExists = Driver.FindElement(buyNowButton).Displayed;
                bool isVisible = addToCartExists == true && buyNowExists == true ? true : false;
                return isVisible;
            }
            return false;
        }

        /// <summary>
        /// Adds to cart the selected items
        /// </summary>
        public void AddToCart()
        {
            browser.FindElement(addToCartButton,5000).Click();
        }

        
        /// <summary>
        /// Returns the list of Product information -price and product details
        /// </summary>
        /// <returns>List of product info in string</returns>
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
    }
}
