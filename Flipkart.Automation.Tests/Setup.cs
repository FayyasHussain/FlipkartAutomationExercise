using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Flipkart.Automation.Tests
{
    [TestClass]
    public static class Setup
    {
        [AssemblyInitialize]
        public static void ExecuteForCreatingReportsNamespace(TestContext testContext)
        {
            Reporter.StartReporter();
        }
    }
}
