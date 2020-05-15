namespace AdminPanelUITests.UITests.APSettingsTests
{
    using BaseUITests;
    using BaseUITests.Pages.LoginPage;
    using AdminPanelUITests.Pages.APSettingsPage.RolePage;
    using DataDriven;
    using DataDriven.Models.AdminPanel.Settings;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Threading;
    using AdminPanelUITests.Pages.Settings.APSettingGlobalOptions;

    [TestClass]
    public class RolesTests : BaseTest
    {
        private LoginPage loginPage;
        private RolePage role;
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
            this.role = new RolePage(this.Driver);
            Thread.Sleep(1500);
            this.settings.NavigateToSettings();
            this.settings.NavigateToRoles();
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
        public void AssertRoleListAppear()
        {
            this.settings.AssertPage(AdminPanelConstants.RolesUrl);
            this.settings.AssertValuesInList();
        }

        [Owner("Diana Grueva")]
        [Priority(1)]
        [TestCategory("Sanity")]
        [TestMethod]
        public void AddNewExistingRole()
        {
            var role = AccessExcelData.GetTestData<Roles>("TestName", "Add", "Roles", AdminPanelConstants.SettingsXlsxFilename);

            this.settings.ClickAdd();
            this.role.AddNew(role);
            this.role.AssertValidationMsg();
            this.role.ClickRejectModal();
            this.role.Search(role.Name);
            this.role.AssertNoResult();
        }

    }
}
