namespace Flipkart.Automation.Tests
{
    using Flipkart.Automation.Core;
    using System;
    using System.IO;
    using System.Reflection;

    public sealed class ApplicationSettings
    {
        private static readonly ApplicationSettings _instance;
       
        public static ApplicationSettings Instance
        {
            get
            {
                return _instance;
            }
        }

        static ApplicationSettings()
        {
            // TODO: Read the settings from JSON file.
            var currentDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var testDataLocation = $@"{currentDirectory}\Data\Application\RunSettings.json";

            var testData = JsonHelper.ReadJsonTestData(testDataLocation);

            _instance = new ApplicationSettings()
            {
                BrowserType = (BrowserType)Enum.Parse(typeof(BrowserType), testData.Browser.Value, true), // Read "Chrome" from Json
                ApplicationUrl = testData.ApplicationUrl.Value
            };
        }

        public BrowserType BrowserType
        {
            get;
            set;
        }

        public string ApplicationUrl
        {
            get;
            set;
        }

        public RemoteDriverDetails RemoteDriver
        {
            get;
            set;
        }
         
        
    }
    public class RemoteDriverDetails
    {
        public string SeleniumURL { get; set; }
        public string OS { get; set; }
        public string Browser { get; set; }
        public string DeviceName { get; set; }
        public string Password { get; set; }
    }
}
