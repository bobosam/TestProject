namespace AdminPanelUITests.UITests.APSettingsTests
{
    using BaseUITests;
    using BaseUITests.Pages.LoginPage;
    using AdminPanelUITests.Pages.APSettingsPage.PermissionPage;
    using DataDriven;
    using DataDriven.Models.AdminPanel.Settings;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Threading;
    using AdminPanelUITests.Pages.Settings.APSettingGlobalOptions;

    [TestClass]
    public class PermissionsTests : BaseTest
    {
        private LoginPage loginPage;
        private PermissionPage permission;
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
            this.permission = new PermissionPage(this.Driver);
            Thread.Sleep(1500);
            this.settings.NavigateToSettings();
            this.settings.NavigateToPermissions();
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
        public void AssertPermissionsAppears()
        {

            this.settings.AssertPage(AdminPanelConstants.PermissionsUrl);
        }
    }
}
