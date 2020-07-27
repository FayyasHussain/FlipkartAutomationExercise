using System;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace Flipkart.Automation.Tests.Pages
{
    public class CheckoutPage : BaseApplicationPage
    {
        private static By productPrice => By.ClassName("_325-ji");
        private static By productName => By.ClassName("_35KyD6");
        private static By continueButton => By.XPath("//span[@id='to-payment']/button");
        private static By purchaseConfirmation => By.XPath("//span[@id='confirmation']");
        private SeleniumDriverWrapper browser;

        public CheckoutPage(IWebDriver driver) : base(driver)
        {
            browser = new SeleniumDriverWrapper(driver);
        }
        
        /// <summary>
        /// Returns the product information - price and details
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
        /// Completes the purchase
        /// </summary>
        public void CompletePurchase()
        {
            browser.FindElement(continueButton, 2000).Click();
        }

        /// <summary>
        /// Checks if the purchase is completed
        /// </summary>
        /// <returns></returns>
        public bool IsPurchaseCompleted()
        {
            if(browser.CheckElementExists(purchaseConfirmation,2000))
            {
                return true;
            }
            return false;
        }
    }
}
