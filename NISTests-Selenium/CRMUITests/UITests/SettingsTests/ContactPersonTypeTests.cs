namespace CRMUITests.UITests.SettingsTests
{
    using BaseUITests;
    using BaseUITests.Pages.LoginPage;
    using CRMUITests.Pages.Settings.ContactPersonTypePage;
    using CRMUITests.Pages.Settings.SettingsGlobalOptions;
    using DataDriven;
    using DataDriven.Models.CRM.Settings;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Threading;

    [TestClass]
    public class ContactPersonTypeTests : BaseTest
    {
        private SettingsGlobalOptionsPage settings;
        private LoginPage loginPage;
        private ContactPersonTypePage contactTypes;

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
            this.contactTypes = new ContactPersonTypePage(this.Driver);
            Thread.Sleep(1000);
            this.settings.NavigateToSettings();
            this.settings.NavigateToContactPersonTypes();
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
        public void AssertContactPersonTypeListAppear()
        {

            this.settings.AssertValuesInList();
        }

        [Owner("Diana Grueva")]
        [Priority(1)]
        [TestCategory("Smoke")]
        [TestMethod]
        public void AddNewContactPersonType()
        {
            var contact = AccessExcelData.GetTestData<ContactPersonType>("TestName", "Sanity", "ContactPersonType", CRMConstants.SettingsXlsxFilename);

            this.settings.AssertValuesInList();
            this.contactTypes.ClickAdd();
            this.contactTypes.AddNew(contact);
            this.contactTypes.AssertNewEntryIsListed(contact.Name);
        }

        [Owner("Diana Grueva")]
        [Priority(2)]
        [TestCategory("Smoke")]
        [TestMethod]
        public void EditContactPersonType()
        {
            var contactPersonTypeToEdit = AccessExcelData.GetTestData<ContactPersonType>("TestName", "SanityEditData", "ContactPersonType", CRMConstants.SettingsXlsxFilename);
            var CcontactPersonTypeEdit = AccessExcelData.GetTestData<ContactPersonType>("TestName", "SanityEdit", "ContactPersonType", CRMConstants.SettingsXlsxFilename);

            try
            {
                this.contactTypes.Search(contactPersonTypeToEdit.Name);
                this.contactTypes.GetResult(1);
            }
            catch (ArgumentOutOfRangeException)
            {
                this.contactTypes.ClickAdd();
                this.contactTypes.AddNew(contactPersonTypeToEdit);
                this.contactTypes.Search(contactPersonTypeToEdit.Name);
                this.contactTypes.GetResult(1);
            }

            this.contactTypes.Edit(CcontactPersonTypeEdit);
            this.contactTypes.Search(CcontactPersonTypeEdit.Name);
            this.contactTypes.AssertChanges(CcontactPersonTypeEdit);
        }

        [Owner("Diana Grueva")]
        [Priority(2)]
        [TestCategory("Smoke")]
        [TestMethod]
        public void DeleteContactPersonType()
        {
            var CcontactPersonTypeDelete = AccessExcelData.GetTestData<ContactPersonType>("TestName", "SanityDelete", "ContactPersonType", CRMConstants.SettingsXlsxFilename);

            try
            {
                this.contactTypes.Search(CcontactPersonTypeDelete.Name);
                this.contactTypes.GetResult(1);
            }
            catch (ArgumentOutOfRangeException)
            {
                this.contactTypes.ClickAdd();
                this.contactTypes.AddNew(CcontactPersonTypeDelete);
                this.contactTypes.Search(CcontactPersonTypeDelete.Name);
                this.contactTypes.GetResult(1);
            }

            this.settings.DeleteAllResult();
            this.settings.NavigateToSettings();
            this.settings.NavigateToContactPersonTypes();
            this.settings.Search(CcontactPersonTypeDelete.Name);
            this.contactTypes.AssertNoResult(); ;
        }
    }
}
