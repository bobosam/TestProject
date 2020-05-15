namespace CRMUITests.UITests.SettingsTests
{
    using BaseUITests;
    using BaseUITests.Pages.LoginPage;
    using CRMUITests.Pages.Settings.PartnerEntryPointPage;
    using CRMUITests.Pages.Settings.PartnerPage;
    using CRMUITests.Pages.Settings.SettingsGlobalOptions;
    using DataDriven;
    using DataDriven.Models.CRM.Settings;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System;
    using System.Threading;

    [TestClass]
    public class PartnersTests : BaseTest
    {
        private SettingsGlobalOptionsPage settings;
        private LoginPage loginPage;
        private PartnerPage partners;
        private PartnerEntryPointPage entryPoints;

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
            this.partners = new PartnerPage(this.Driver);
            this.entryPoints = new PartnerEntryPointPage(this.Driver);
            Thread.Sleep(1000);
            this.settings.NavigateToSettings();
            this.settings.NavigateToPartners();
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
        public void AssertParametersListAppear()
        {
            this.settings.AssertValuesInList();
        }

        [Owner("Diana Grueva")]
        [Priority(1)]
        [TestCategory("Smoke")]
        [TestMethod]
        public void AddNewPartner()
        {
            var partner = AccessExcelData.GetTestData<Partner>("TestName", "Sanity", "Partner", CRMConstants.SettingsXlsxFilename);

            this.settings.ClickAdd();
            this.partners.AddNew(partner);

            this.settings.NavigateToSettings();
            this.settings.NavigateToPartners();
            this.partners.AssertNewEntryIsListed(partner.Name);

            this.settings.GetResult(1);
            this.settings.ClickDelete();
            this.settings.ClickYes();
            this.partners.AssertDeleted(partner);

        }

        [Owner("Diana Grueva")]
        [Priority(1)]
        [TestCategory("Smoke")]
        [TestMethod]
        public void AddNewEntryPointToexistingPartner()
        {
            var entryPoint = AccessExcelData.GetTestData<PartnerEntryPoint>("TestName", "SanityAdd", "PartnerEntryPoint", CRMConstants.SettingsXlsxFilename);

            this.entryPoints.AddNew(entryPoint);
            this.entryPoints.AssertNewEntryPointIsListed(entryPoint.Name);
        }

        [Owner("Diana Grueva")]
        [Priority(1)]
        [TestCategory("Smoke")]
        [TestMethod]
        public void EditPartner()
        {
            var partprep = AccessExcelData.GetTestData<Partner>("TestName", "SanityEditData", "Partner", CRMConstants.SettingsXlsxFilename);
            var part = AccessExcelData.GetTestData<Partner>("TestName", "SanityEdit", "Partner", CRMConstants.SettingsXlsxFilename);

            try
            {
                this.settings.Search(partprep.Name);
                this.settings.GetResult(1);
            }
            catch (ArgumentOutOfRangeException)
            {
                this.settings.ClickAdd();
                this.partners.AddNew(partprep);
                this.settings.NavigateToSettings();
                this.settings.NavigateToPartners();
                this.partners.AssertNewEntryIsListed(partprep.Name);
                this.settings.Search(partprep.Name);
                this.settings.GetResult(1);
            }
            
            this.partners.ClickEdit();
            this.partners.Edit(part);
            this.partners.AssertChanges(part);
        }

        [Owner("Diana Grueva")]
        [Priority(1)]
        [TestCategory("Smoke")]
        [TestMethod]
        public void EditEntryPointToPartner()
        {
            var entryPoint = AccessExcelData.GetTestData<PartnerEntryPoint>("TestName", "SanityEdit", "PartnerEntryPoint", CRMConstants.SettingsXlsxFilename);

            this.entryPoints.Edit(entryPoint);
            this.entryPoints.AssertChanges(entryPoint);
        }

        [Owner("Diana Grueva")]
        [Priority(1)]
        [TestCategory("Smoke")]
        [TestMethod]
        public void DeleteEntryPointToPartner()
        {
            var entryPoint = AccessExcelData.GetTestData<PartnerEntryPoint>("TestName", "SanityDelete", "PartnerEntryPoint", CRMConstants.SettingsXlsxFilename);
            try
            {
                this.entryPoints.Delete(entryPoint);
                this.entryPoints.AssertDeleted(entryPoint);
            }
            catch (Exception)
            {

                this.entryPoints.AddNew(entryPoint);
                this.entryPoints.AssertNewEntryPointIsListed(entryPoint.Name);
                this.entryPoints.Delete(entryPoint);
                this.entryPoints.AssertDeleted(entryPoint);
            }
        }

        
        [Owner("Diana Grueva")]
        [Priority(1)]
        [TestCategory("Smoke")]
        [TestMethod]
        public void DeletePartner()
        {
            var partner = AccessExcelData.GetTestData<Partner>("TestName", "SanityDelete", "Partner", CRMConstants.SettingsXlsxFilename);

            this.partners.Search(partner.Name);

            try
            {
                this.partners.GetResult(1);
            }
            catch (ArgumentOutOfRangeException)
            {
                this.partners.ClickAdd();
                this.partners.AddNew(partner);
                this.partners.AssertNewEntryIsListed(partner.Name);
                this.partners.Search(partner.Name);
                this.partners.GetResult(1);
            }

            this.settings.DeleteAllResult();
            this.partners.AssertDeleted(partner);
        }
    }
}
