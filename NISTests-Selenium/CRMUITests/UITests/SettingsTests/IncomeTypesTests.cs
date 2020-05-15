namespace CRMUITests.UITests.SettingsTests
{
    using BaseUITests;
    using BaseUITests.Pages.LoginPage;
    using CRMUITests.Pages.Settings.IncomeTermTypePage;
    using CRMUITests.Pages.Settings.SettingsGlobalOptions;
    using DataDriven;
    using DataDriven.Models.CRM.Settings;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Threading;

    [TestClass]
    public class IncomeTypesTests : BaseTest
    {
        private SettingsGlobalOptionsPage settings;
        private LoginPage loginPage;
        private IncomeTermTypePage incomeType;

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
            this.incomeType = new IncomeTermTypePage(this.Driver);
            Thread.Sleep(1000);
            this.settings.NavigateToSettings();
            this.settings.NavigateToIncomeTermTypes();
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
        public void AssertIncomeTermTypeListAppear()
        {
            this.settings.AssertValuesInList();
        }

        [Owner("Diana Grueva")]
        [Priority(1)]
        [TestCategory("Smoke")]
        [TestMethod]
        public void AddNewIncomeTermType()
        {
            var income = AccessExcelData.GetTestData<IncomeTermType>("TestName", "Sanity", "IncomeTermType", CRMConstants.SettingsXlsxFilename);


            this.settings.AssertValuesInList();
            this.incomeType.ClickAdd();
            this.incomeType.AddNew(income);
            this.incomeType.AssertNewEntryIsListed(income.Name);
        }

        [Owner("Diana Grueva")]
        [Priority(2)]
        [TestCategory("Smoke")]
        [TestMethod]
        public void EditIncomeTermType()
        {
            var incomeTypeToEdit = AccessExcelData.GetTestData<IncomeTermType>("TestName", "SanityEditData", "IncomeTermType", CRMConstants.SettingsXlsxFilename);
            var incomePersonTypeEdit = AccessExcelData.GetTestData<IncomeTermType>("TestName", "SanityEdit", "IncomeTermType", CRMConstants.SettingsXlsxFilename);

            try
            {
                this.incomeType.Search(incomeTypeToEdit.Name);
                this.incomeType.GetResult(1);
            }
            catch (ArgumentOutOfRangeException)
            {
                this.incomeType.ClickAdd();
                this.incomeType.AddNew(incomeTypeToEdit);
                this.incomeType.Search(incomeTypeToEdit.Name);
                this.incomeType.GetResult(1);
            }

            this.incomeType.ClickEdit();
            this.incomeType.Edit(incomePersonTypeEdit);
            this.incomeType.Search(incomePersonTypeEdit.Name);
            this.incomeType.AssertChanges(incomePersonTypeEdit);
        }

        [Owner("Diana Grueva")]
        [Priority(2)]
        [TestCategory("Smoke")]
        [TestMethod]
        public void DeleteIncomeTermType()
        {
            var incomeTypeDelete = AccessExcelData.GetTestData<IncomeTermType>("TestName", "SanityDelete", "IncomeTermType", CRMConstants.SettingsXlsxFilename);

            try
            {
                this.incomeType.Search(incomeTypeDelete.Name);
                this.incomeType.GetResult(1);
            }
            catch (ArgumentOutOfRangeException)
            {
                this.incomeType.ClickAdd();
                this.incomeType.AddNew(incomeTypeDelete);
                this.incomeType.Search(incomeTypeDelete.Name);
                this.incomeType.GetResult(1);
            }

            this.settings.DeleteAllResult();
            this.settings.NavigateToSettings();
            this.settings.NavigateToIncomeTermTypes();
            this.settings.Search(incomeTypeDelete.Name);
            this.incomeType.AssertNoResult(); ;
        }
    }
}
