namespace AdminPanelUITests.UITests.APSettingsTests
{
    using BaseUITests;
    using BaseUITests.Pages.LoginPage;
    using AdminPanelUITests.Pages.APSettingsPage.PositionPage;
    using DataDriven;
    using DataDriven.Models.AdminPanel.Settings;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Threading;
    using AdminPanelUITests.Pages.Settings.APSettingGlobalOptions;

    [TestClass]
    public class PositionTests : BaseTest
    {
        private LoginPage loginPage;
        private PositionPage position;
        private APSettingsGlobalOptionsPage settings;

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
            this.loginPage = new LoginPage(this.Driver);
            this.loginPage.CurrentUserLogin(BaseConstants.TestAdminPanelUrl);
            this.settings = new APSettingsGlobalOptionsPage(this.Driver);
            this.position = new PositionPage(this.Driver);
            Thread.Sleep(1500);
            Thread.Sleep(1500);
            this.settings.NavigateToSettings();
            this.settings.NavigateToPositions();
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
        public void AssertPositionListAppear()
        {
            this.settings.AssertPage(AdminPanelConstants.PositionsUrl);
            this.settings.AssertValuesInList();
        }

        [Owner("Diana Grueva")]
        [Priority(1)]
        [TestCategory("Sanity")]
        [TestMethod]
        public void AddNewPosition()
        {
            var position = AccessExcelData.GetTestData<Positions>("TestName", "Add", "Positions", AdminPanelConstants.SettingsXlsxFilename);

            this.position.ClickAdd();
            this.position.AddNew(position);
            this.position.AssertNewEntryIsListed(position.Name);
        }
    }
}
