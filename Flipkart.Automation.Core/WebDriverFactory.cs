using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.IO;
using System.Reflection;

namespace Flipkart.Automation.Core
{
    public class WebDriverFactory
    {
        public IWebDriver Create(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    return GetChromeDriver();

                case BrowserType.firefox:
                    return GetFirefoxDriver();

                case BrowserType.Edge:
                    return GetEdgeDriver();
                
                case BrowserType.Safari:
                    return GetSafariDriver();

                default:
                    throw new ArgumentOutOfRangeException("No such browser exists");
            }
        }

        private IWebDriver GetSafariDriver()
        {
            throw new NotImplementedException();
        }

        public IWebDriver CreateRemoteDriver()
        {
            var options = new ChromeOptions();
            options.AcceptInsecureCertificates = true;

            options.AddAdditionalCapability("username", "", true);
            options.AddAdditionalCapability("password", "", true);
            options.AddAdditionalCapability("version", "70", true);
            options.AddAdditionalCapability("platform", "Windows 10", true);

            return new RemoteWebDriver(new Uri(""), options);
        }

        private IWebDriver GetEdgeDriver()
        {
            throw new NotImplementedException();
        }

        private IWebDriver GetFirefoxDriver()
        {
            return new FirefoxDriver();
        }

        private IWebDriver GetChromeDriver()
        {
            var drirectoryWithChromeDriver = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(drirectoryWithChromeDriver);
        }
    }
}
