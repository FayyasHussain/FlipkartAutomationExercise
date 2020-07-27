using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Flipkart.Automation.Tests
{
    public class SeleniumDriverWrapper : TestBase
    {

        public SeleniumDriverWrapper(IWebDriver driver)
        {
            this.Driver = driver;
        }

        /// <summary>
        /// Finds the IWebElement with a wait time
        /// </summary>
        /// <param name="search"></param>
        /// <param name="waitTime"></param>
        /// <returns></returns>
        public IWebElement FindElement(By search, int waitTime)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromMilliseconds(waitTime));
            wait.IgnoreExceptionTypes(new Type[] { typeof(NoSuchElementException), typeof(WebDriverTimeoutException), typeof(TimeoutException) });
            IWebElement htmlElement = null;
            try
            {
                htmlElement = wait.Until<IWebElement>(Driver =>
                {
                    var element = Driver.FindElement(search);
                    return element != null ? element : null;
                });
            }
            catch (WebDriverTimeoutException)
            {
                return null;
            }

            return htmlElement;
        }

        /// <summary>
        /// Finds immediate child element with a wait time
        /// </summary>
        /// <param name="search"></param>
        /// <param name="waitTime"></param>
        /// <returns></returns>
        public IList<IWebElement> FindImmediateChildElements(By search, int waitTime)
        {
            IWebElement webElement = this.FindElement(search, waitTime);

            // If element not found, return NULL
            if (webElement == null)
            {
                return null;
            }
            else
            {
                return new List<IWebElement>(webElement.FindElements(By.XPath("*")));
            }
        }

        /// <summary>
        /// Find the parent element with a wait time.
        /// </summary>
        /// <param name="search"></param>
        /// <param name="waitTime"></param>
        /// <returns></returns>
        public IWebElement FindParentElement(By search, int waitTime)
        {
            IWebElement webElement = this.FindElement(search, waitTime);

            // If element not found, return NULL
            if (webElement == null)
            {
                return null;
            }
            else
            {
                // return the parent of the passed-in element
                return webElement.FindElement(By.XPath(".."));
            }
        }

        /// <summary>
        /// Checks if the element exists
        /// </summary>
        /// <param name="by"></param>
        /// <param name="waitTime"></param>
        /// <returns></returns>
        public bool CheckElementExists(By by, int waitTime)
        {
            try
            {
                return this.FindElement(by, waitTime) != null;
            }
            catch
            {
                // In this case we are intrested to know whether the element exists or not. Not worried about exception
            }

            return false;
        }

        /// <summary>
        /// Element Click using Javascript executor.
        /// </summary>
        /// <param name="element"></param>
        public void HtmlELementClickJS(IWebElement element)
        {
            if (element != null)
            {
                IJavaScriptExecutor jsExecutor = this.Driver as IJavaScriptExecutor;
                jsExecutor.ExecuteScript("arguments[0].click();", element);
            }
        }
    }
}
