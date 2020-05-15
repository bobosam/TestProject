namespace CRMUITests.UITests.SettingsTests
{
    using BaseUITests;
    using BaseUITests.Pages.LoginPage;
    using CRMUITests.Pages.Settings.SettingsGlobalOptions;
    using CRMUITests.Pages.Settings.SourcePage;
    using DataDriven;
    using DataDriven.Models.CRM.Settings;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Threading;

    [TestClass]
    public class SourcesTests : BaseTest
    {
        private SettingsGlobalOptionsPage settings;
        private LoginPage loginPage;
        private SourcePage source;

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
            this.source = new SourcePage(this.Driver);
            Thread.Sleep(1000);
            this.settings.NavigateToSettings();
            this.settings.NavigateToSources();
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
        public void AssertSourcesListAppear()
        {

            this.settings.AssertValuesInList();
        }

        [Owner("Diana Grueva")]
        [Priority(1)]
        [TestCategory("Smoke")]
        [TestMethod]
        public void AddNewSource()
        {
            var source = AccessExcelData.GetTestData<Source>("TestName", "Sanity", "Source", CRMConstants.SettingsXlsxFilename);

            this.settings.AssertValuesInList();
            this.source.ClickAdd();
            this.source.AddNew(source);

            this.settings.NavigateToSettings();
            this.settings.NavigateToSources();
            this.source.AssertNewEntryIsListed(source.Name);

            this.source.GetResult(1);
            this.source.ClickDelete();
            this.source.ClickYes();
            Thread.Sleep(500);
        }

        [Owner("Diana Grueva")]
        [Priority(2)]
        [TestCategory("Smoke")]
        [TestMethod]
        public void EditSource()
        {
            var sourceToEdit = AccessExcelData.GetTestData<Source>("TestName", "SanityEditData", "Source", CRMConstants.SettingsXlsxFilename);
            var sourcee = AccessExcelData.GetTestData<Source>("TestName", "SanityEdit", "Source", CRMConstants.SettingsXlsxFilename);

            this.source.Search(sourceToEdit.Name);

            try
            {
                this.source.GetResult(1);
            }
            catch (ArgumentOutOfRangeException)
            {
                this.source.ClickAdd();
                this.source.AddNew(sourceToEdit);
            }

            this.source.Search(sourceToEdit.Name);

            this.source.GetResult(1);
            this.source.ClickEdit();
            this.source.Edit(sourcee);
            this.source.Search(sourcee.Name);
            this.source.AssertChanges(sourcee);
        }

        [Owner("Diana Grueva")]
        [Priority(2)]
        [TestCategory("Smoke")]
        [TestMethod]
        public void DeleteSource()
        {
            var s = AccessExcelData.GetTestData<Source>("TestName", "SanityDelete", "Source", CRMConstants.SettingsXlsxFilename);

            this.settings.Search(s.Name);

            try
            {
                this.source.GetResult(1);
            }
            catch (ArgumentOutOfRangeException)
            {
                this.source.ClickAdd();
                this.source.AddNew(s);
                this.settings.Search(s.Name);
                this.source.GetResult(1);
            }

            this.settings.DeleteAllResult();
            this.settings.NavigateToSettings();
            this.settings.NavigateToSources();
            this.settings.Search(s.Name);
            this.source.AssertNoResult();
        }
    }
}
