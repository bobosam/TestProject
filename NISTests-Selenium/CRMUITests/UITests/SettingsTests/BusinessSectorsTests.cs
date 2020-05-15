namespace CRMUITests.UITests.SettingsTests
{
    using BaseUITests;
    using BaseUITests.Pages.LoginPage;
    using CRMUITests.Pages.Settings.BusinessSectorPage;
    using CRMUITests.Pages.Settings.SettingsGlobalOptions;
    using DataDriven;
    using DataDriven.Models.CRM.Settings;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Threading;

    [TestClass]
    public class BusinessSectorTests : BaseTest
    {
        private SettingsGlobalOptionsPage settings;
        private LoginPage loginPage;
        private BusinessSectorPage businessSector;

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
            this.businessSector = new BusinessSectorPage(this.Driver);
            Thread.Sleep(1000);
            this.settings.NavigateToSettings();
            this.settings.NavigateToBusinessSector();
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
        public void AssertBusinessSectorListAppear()
        {
            this.settings.AssertValuesInList();
        }

        [Owner("Diana Grueva")]
        [Priority(1)]
        [TestCategory("Smoke")]
        [TestMethod]
        public void AddNewBusinessSector()
        {
            var bSector = AccessExcelData.GetTestData<BusinessSector>("TestName", "Sanity", "BusinessSector", CRMConstants.SettingsXlsxFilename);


            this.settings.AssertValuesInList();
            this.businessSector.ClickAdd();
            this.businessSector.AddNew(bSector);
            this.businessSector.AssertNewEntryIsListed(bSector.Name);
        }
        [Owner("Diana Grueva")]
        [Priority(2)]
        [TestCategory("Smoke")]
        [TestMethod]
        public void EditSector()
        {
            var bSectorToEdit = AccessExcelData.GetTestData<BusinessSector>("TestName", "SanityEditData", "BusinessSector", CRMConstants.SettingsXlsxFilename);
            var bSectorEdit = AccessExcelData.GetTestData<BusinessSector>("TestName", "SanityEdit", "BusinessSector", CRMConstants.SettingsXlsxFilename);

            try
            {
                this.businessSector.Search(bSectorToEdit.Name);
                this.businessSector.GetResult(1);
            }
            catch (ArgumentOutOfRangeException)
            {
                this.businessSector.ClickAdd();
                this.businessSector.AddNew(bSectorToEdit);
                this.businessSector.Search(bSectorToEdit.Name);
                this.businessSector.GetResult(1);
            }

            this.businessSector.Edit(bSectorEdit);
            this.businessSector.Search(bSectorEdit.Name);
            this.businessSector.AssertChanges(bSectorEdit);
        }

        [Owner("Diana Grueva")]
        [Priority(2)]
        [TestCategory("Smoke")]
        [TestMethod]
        public void DeleteSector()
        {
            var bSectorDelete = AccessExcelData.GetTestData<BusinessSector>("TestName", "SanityDelete", "BusinessSector", CRMConstants.SettingsXlsxFilename);

            try
            {
                this.settings.Search(bSectorDelete.Name);
                this.businessSector.GetResult(1);
            }
            catch (ArgumentOutOfRangeException)
            {
                this.businessSector.ClickAdd();
                this.businessSector.AddNew(bSectorDelete);
                this.settings.Search(bSectorDelete.Name);
                this.businessSector.GetResult(1);
            }

            this.settings.DeleteAllResult();
            this.settings.NavigateToSettings();
            this.settings.NavigateToBusinessSector();
            this.settings.Search(bSectorDelete.Name);
            this.businessSector.AssertNoResult(); ;
        }

    }
}
