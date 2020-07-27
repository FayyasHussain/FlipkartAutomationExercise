using Flipkart.Automation.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Reflection;

namespace Flipkart.Automation.Tests
{
    [TestClass]
    public class TestBase
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public TestBase()
        {
            this.SetupTestData();
        }

        protected IWebDriver Driver = null;

        public TestContext TestContext { get; set; }

        public dynamic TestData
        {
            get;
            private set;
        }

        public ApplicationSettings Settings
        {
            get
            {
                return ApplicationSettings.Instance;
            }
        }

        private ScreenshotTaker ScreenshotTaker { get; set; }

        [TestInitialize]
        public void SetupForEverySingleTestMethod()
        {
            Logger.Debug("*************************************** TEST STARTED");
            Logger.Debug("*************************************** TEST STARTED");
            Reporter.AddTestCaseMetadataToHtmlReport(TestContext);
            var factory = new WebDriverFactory();
            this.Driver = factory.Create(this.Settings.BrowserType);
            Driver.Manage().Window.Maximize();
            Driver.Url = this.Settings.ApplicationUrl;
            ScreenshotTaker = new ScreenshotTaker(Driver, TestContext);
        }

        [TestCleanup]
        public void TearDownForEverySingleTestMethod()
        {
            Logger.Debug(GetType().FullName + " started a method tear down");
            try
            {
                TakeScreenshotForTestFailure();
            }
            catch (Exception e)
            {
                Logger.Error(e.Source);
                Logger.Error(e.StackTrace);
                Logger.Error(e.InnerException);
                Logger.Error(e.Message);
            }
            finally
            {
                StopBrowser();
                Logger.Debug(TestContext.TestName);
                Logger.Debug("*************************************** TEST STOPPED");
                Logger.Debug("*************************************** TEST STOPPED");
            }
        }

        private void TakeScreenshotForTestFailure()
        {
            if (ScreenshotTaker != null)
            {
                ScreenshotTaker.CreateScreenshotIfTestFailed();
                Reporter.ReportTestOutcome(ScreenshotTaker.ScreenshotFilePath);
            }
            else
            {
                Reporter.ReportTestOutcome("");
            }
        }

        private void StopBrowser()
        {
            if (Driver == null)
                return;

            Driver.Quit();
            Driver = null;
            Logger.Trace("Browser stopped successfully.");
        }

        private void SetupTestData()
        {
            var currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var testDataLocation = $@"{currentDirectory}\Data\Tests\{this.GetType().Name}Data.json";

            this.TestData = JsonHelper.ReadJsonTestData(testDataLocation);
        }
    }
}
