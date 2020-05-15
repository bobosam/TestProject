namespace CRMUITests.UITests.SettingsTests
{
    using BaseUITests;
    using BaseUITests.Pages.LoginPage;
    using CRMUITests.Pages.Settings.BankPage;
    using CRMUITests.Pages.Settings.SettingsGlobalOptions;
    using DataDriven;
    using DataDriven.Models.CRM.Settings;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Threading;

    [TestClass]
    public class BanksTests : BaseTest
    {
        private SettingsGlobalOptionsPage settings;
        private LoginPage loginPage;
        private BankPage bank;

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
            this.bank = new BankPage(this.Driver);
            Thread.Sleep(1500);
            this.settings.NavigateToSettings();
            this.settings.NavigateToBank();
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
        public void AssertBanksListAppear()
        {

            this.settings.AssertValuesInList();
        }

        [Owner("Diana Grueva")]
        [Priority(2)]
        [TestCategory("Smoke")]
        [TestMethod]
        public void AddNewBank()
        {
            var bank = AccessExcelData.GetTestData<Bank>("TestName", "SanityAdd", "Bank", CRMConstants.SettingsXlsxFilename);

            this.settings.AssertValuesInList();
            this.bank.ClickAdd();
            this.bank.AddNew(bank);
            this.settings.AssertNewEntryIsListed(bank.Name);
        }

        [Owner("Diana Grueva")]
        [Priority(2)]
        [TestCategory("Smoke")]
        [TestMethod]
        public void EditBank()
        {
            var bankToEdit = AccessExcelData.GetTestData<Bank>("TestName", "SanityEditData", "Bank", CRMConstants.SettingsXlsxFilename);
            var bankEdit = AccessExcelData.GetTestData<Bank>("TestName", "SanityEdit", "Bank", CRMConstants.SettingsXlsxFilename);

            try
            {
                this.bank.Search(bankToEdit.Name);
                this.bank.GetResult(1);
            }
            catch (ArgumentOutOfRangeException)
            {
                this.bank.ClickAdd();
                this.bank.AddNew(bankToEdit);
                this.bank.Search(bankToEdit.Name);
            }

            this.bank.Edit(bankEdit);
            this.bank.Search(bankEdit.Name);
            this.bank.AssertChanges(bankEdit);
        }

        [Owner("Diana Grueva")]
        [Priority(2)]
        [TestCategory("Smoke")]
        [TestMethod]
        public void DeleteBank()
        {
            var bankDelete = AccessExcelData.GetTestData<Bank>("TestName", "SanityDelete", "Bank", CRMConstants.SettingsXlsxFilename);

            try
            {
                this.settings.Search(bankDelete.Name);
                this.bank.GetResult(1);
            }
            catch (ArgumentOutOfRangeException)
            {
                this.bank.ClickAdd();
                this.bank.AddNew(bankDelete);
                this.settings.Search(bankDelete.Name);
                this.bank.GetResult(1);
            }
            this.settings.DeleteAllResult();
            //this.bank.ClickDelete();
            //this.bank.ClickYes();
            this.settings.NavigateToSettings();
            this.settings.NavigateToBank();
            this.settings.Search(bankDelete.Name);
            this.bank.AssertNoResult(); ;
        }

    }
}
