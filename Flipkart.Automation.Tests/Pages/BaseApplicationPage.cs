using OpenQA.Selenium;

namespace Flipkart.Automation.Tests.Pages
{
    public class BaseApplicationPage : TestBase
    {
        // protected IWebDriver Driver { get; set; }
        public BaseApplicationPage(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
