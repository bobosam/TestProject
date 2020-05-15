namespace CRMUITests.UITests.SettingsTests
{
    using System.Threading;

    using CRMUITests.Pages.Settings.RequestPriorityPage;
    using CRMUITests.Pages.Settings.SettingsGlobalOptions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BaseUITests.Pages.LoginPage;
    using BaseUITests;

    [TestClass]
    public class RequestPriorityTests : BaseTest
    {
        private SettingsGlobalOptionsPage settings;
        private LoginPage loginPage;
        private RequestPriorityPage priorities;

        [ClassInitialize]
        public static void ClassInit(TestContext con)
        {
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
        }

        [TestInitialize]
        public void TestIniti()
        {
            this.TestInitialize();
            this.settings = new SettingsGlobalOptionsPage(this.Driver);
            this.loginPage = new LoginPage(this.Driver);
            this.loginPage.CurrentUserLogin(BaseConstants.TestCRMUrl);
            this.priorities = new RequestPriorityPage(this.Driver);
            Thread.Sleep(1000);
            this.settings.NavigateToSettings();
            this.settings.NavigateToPriorities();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            this.TestCleanup();
        }

        [Owner("Diana Grueva")]
        [Priority(1)]
        [TestCategory("Sanity")]
        [TestMethod]
        public void AssertSetPrioritiesListAppear()
        {
            Assert.AreEqual(BaseConstants.TestCRMUrl +"/#/settings/request-priority", this.Driver.Url);
        }
    }
}
