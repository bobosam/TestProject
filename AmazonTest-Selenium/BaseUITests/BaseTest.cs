// <copyright file="BaseTest.cs" company="MyCompany.com">
//       MyCompany.com. All rights reserved.
// </copyright>
// <summary>A sample project for Endava</summary>
// <author>Boyko Andonov</author>

namespace BaseUITests
{
    using System.IO;
    using System.Reflection;

    using NUnit.Framework;
    using NUnit.Framework.Interfaces;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    /// <summary>
    /// BaseTest contains all the common test stuff.
    /// </summary>
    [TestFixture]
    public class BaseTest
    {
        /// <summary>
        /// Gets or sets used to store information that is provided to tests.
        /// </summary>
        /// <value>Store information that is provided to tests.</value>
        public TestContext TestContext { get; set; }

        /// <summary>
        /// Gets or sets driver instance.
        /// </summary>
        /// <value>Driver instance.</value>
        public IWebDriver Driver { get; set; }

        /// <summary>
        /// ClassInitialize called once prior to executing any of the tests in a fixture.
        /// </summary>
        [OneTimeSetUp]
        public static void ClassInitialize()
        {
        }

        /// <summary>
        /// TestInitialize initialize chrome web driver.
        /// </summary>
        protected void TestInitialize()
        {
            this.Driver = new ChromeDriver();
            this.Driver.Manage().Window.Maximize();
        }

        /// <summary>
        /// TestCleanup provides a common set of functions 
        /// that are performed after each test method is run.
        /// </summary>
        [TearDown]
        protected void TestCleanup()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                string fileName = TestContext.CurrentContext.Test.Name;
                var directory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                var pathTextLogs = Path.GetFullPath(Path.Combine(directory, @"..\..\Logs\" + fileName + ".txt"));

                if (File.Exists(pathTextLogs))
                {
                    File.Delete(pathTextLogs);
                }

                var testBody = TestContext.CurrentContext.Test.FullName + "\n"
                    + TestContext.CurrentContext.Test.ClassName + "\n"
                    + TestContext.CurrentContext.Test.MethodName + "\n"
                    + TestContext.CurrentContext.Test.Name + "\n"
                    + TestContext.CurrentContext.Result.Message + "\n"
                    + TestContext.CurrentContext.Result.StackTrace + "\n"
                    + TestContext.CurrentContext.WorkDirectory;
                File.WriteAllText(pathTextLogs, testBody);

                var pathJpegLogs = Path.GetFullPath(Path.Combine(directory, @"..\..\Logs\" + fileName + ".jpeg"));
                var screenshot = ((ITakesScreenshot)this.Driver).GetScreenshot();
                screenshot.SaveAsFile(pathJpegLogs, ScreenshotImageFormat.Jpeg);
            }

            this.Driver.Quit();
        }

        /// <summary>
        /// ClassCleanup called once after executing all the tests in a fixture.
        /// </summary>
        [OneTimeTearDown]
        protected void ClassCleanup()
        {
        }
    }
}
