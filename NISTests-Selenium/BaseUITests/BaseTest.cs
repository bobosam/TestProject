namespace BaseUITests
{
    using System.IO;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using DataDriven;

    [TestClass]
    public class BaseTest
    {
        private TestContext testContext;

        public TestContext TestContext
        {
            get
            {
                return this.testContext;
            }

            set
            {
                this.testContext = value;
            }
        }

        public IWebDriver Driver { get; set; }

        protected void TestInitialize()
        {
            this.Driver = new ChromeDriver();
            this.Driver.Manage().Window.Maximize();
        }

        protected void TestCleanup()
        {
            if (TestContext.CurrentTestOutcome != UnitTestOutcome.Passed)
            {
                string fileName = TestContext.TestName;
                var directory = HelpMethods.GetDirectory();
                var pathTextLogs = Path.GetFullPath(Path.Combine(directory, @"..\Logs\" + fileName + ".txt"));

                if (File.Exists(pathTextLogs))
                {
                    File.Delete(pathTextLogs);
                }

                var testBody = TestContext.TestName + "        " + TestContext.ResultsDirectory + "            " + TestContext.CurrentTestOutcome;
                File.WriteAllText(pathTextLogs, testBody);

                var pathJpegLogs = Path.GetFullPath(Path.Combine(directory, @"..\Logs\" + fileName + ".jpeg"));
                var screenshot = ((ITakesScreenshot)this.Driver).GetScreenshot();
                screenshot.SaveAsFile(pathJpegLogs, ScreenshotImageFormat.Jpeg);
            }

            this.Driver.Quit();
        }
    }
}
