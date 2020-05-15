namespace CRMUITests.UITests.SettingsTests
{
    using BaseUITests;
    using BaseUITests.Pages.LoginPage;
    using CRMUITests.Pages.Settings.OfficePage;
    using CRMUITests.Pages.Settings.SettingsGlobalOptions;
    using DataDriven;
    using DataDriven.Models.CRM.Settings;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Threading;

    [TestClass]
    public class OfficesTests : BaseTest
    {
        private SettingsGlobalOptionsPage settings;
        private LoginPage loginPage;
        private OfficePage office;

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
            this.office = new OfficePage(this.Driver);
            Thread.Sleep(1000);
            this.settings.NavigateToSettings();
            this.settings.NavigateToOffices();
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
        public void AssertOfficesListAppear()
        {
            this.settings.AssertValuesInList();
        }

        [Owner("Diana Grueva")]
        [Priority(1)]
        [TestCategory("Smoke")]
        [TestMethod]
        public void AddNewOffice()
        {
            var office = AccessExcelData.GetTestData<Office>("TestName", "Sanity", "Office", CRMConstants.SettingsXlsxFilename);


            this.settings.AssertValuesInList();
            this.office.ClickAdd();
            this.office.AddNew(office);
            this.office.AssertNewEntryIsListed(office.Name);

            this.office.GetResult(1);
            this.office.ClickDelete();
            this.office.ClickYes();
            Thread.Sleep(500);
        }

        [Owner("Diana Grueva")]
        [Priority(2)]
        [TestCategory("Smoke")]
        [TestMethod]
        public void EditOffice()
        {
            var officeToEdit = AccessExcelData.GetTestData<Office>("TestName", "SanityEditData", "Office", CRMConstants.SettingsXlsxFilename);
            var officeEdit = AccessExcelData.GetTestData<Office>("TestName", "SanityEdit", "Office", CRMConstants.SettingsXlsxFilename);

            try
            {
                this.office.Search(officeToEdit.Name);
                this.office.GetResult(1);
            }
            catch (ArgumentOutOfRangeException)
            {
                this.office.ClickAdd();
                this.office.AddNew(officeToEdit);
                this.office.AssertNewEntryIsListed(officeToEdit.Name);
                this.office.GetResult(1);
            }

            this.office.ClickEdit();
            this.office.Edit(officeEdit);
            this.office.Search(officeEdit.Name);
            this.office.AssertChanges(officeEdit);

            this.office.Search(officeEdit.DisplayName);
            this.office.GetResult(1);
            this.office.ClickDelete();
            this.office.ClickYes();

        }

        [Owner("Diana Grueva")]
        [Priority(2)]
        [TestCategory("Smoke")]
        [TestMethod]
        public void DeleteOffice()

        {
            var officeDelete = AccessExcelData.GetTestData<Office>("TestName", "SanityDelete", "Office", CRMConstants.SettingsXlsxFilename);

            try
            {
                this.settings.Search(officeDelete.Name);
                this.office.GetResult(1);
            }
            catch (ArgumentOutOfRangeException)
            {
                this.office.ClickAdd();
                this.office.AddNew(officeDelete);
                this.office.AssertNewEntryIsListed(officeDelete.Name);
                this.settings.Search(officeDelete.Name);
                this.office.GetResult(1);
            }

            this.settings.DeleteAllResult();
            this.settings.NavigateToSettings();
            this.settings.NavigateToOffices();
            this.settings.Search(officeDelete.Name);
            this.office.AssertNoResult(); ;
        }
    }
}
