namespace CRMUITests.UITests.SettingsTests
{
    using BaseUITests;
    using BaseUITests.Pages.LoginPage;
    using CRMUITests.Pages.Settings.ParameterPage;
    using CRMUITests.Pages.Settings.SettingsGlobalOptions;
    using DataDriven;
    using DataDriven.Models.CRM.Settings;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Threading;

    [TestClass]
    public class ParametersTests : BaseTest
    {
        private SettingsGlobalOptionsPage settings;
        private LoginPage loginPage;
        private ParameterPage parameters;

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
            this.parameters = new ParameterPage(this.Driver);
            Thread.Sleep(1000);
            this.settings.NavigateToSettings();
            this.settings.NavigateToParameters();
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
        [Priority(2)]
        [TestCategory("Sanity")]
        [TestMethod]
        public void NoAddExistInParameters()
        {
            this.parameters.AssertNoAddExist();
        }

        [Owner("Diana Grueva")]
        [Priority(2)]
        [TestCategory("Sanity")]
        [TestMethod]
        public void NoDeleteExistInParameters()
        {
            this.parameters.AssertNoDeleteExist();
        }

        [Owner("Diana Grueva")]
        [Priority(2)]
        [TestCategory("Sanity")]
        [TestMethod]
        public void AssertFieldsParameterNotEditable()
        {

            Thread.Sleep(500);
            this.parameters.GetResult(1);
            this.parameters.ClickEdit();
            this.parameters.AssertFieldsNotEditable();
        }

        [Owner("Diana Grueva")]
        [Priority(2)]
        [TestCategory("Sanity")]
        [TestMethod]
        public void EditParameters()
        {
            var param = AccessExcelData.GetTestData<Parameter>("TestName", "SanityEdit", "Parameter", CRMConstants.SettingsXlsxFilename);
            Thread.Sleep(500);
            //this.settings.Search(param.ParamName); BUG
            this.settings.Search(param.Code);
            this.parameters.GetResult(1);
            this.parameters.ClickEdit();
            this.parameters.Edit(param);
            this.parameters.NavigateToSettings();
            this.parameters.NavigateToParameters();
            //this.parameters.Search(param.ParamName); BUG
            this.settings.Search(param.Code);
            this.parameters.AssertChanges(param);
        }

        [Ignore]
        [Owner("Diana Grueva")]
        [Priority(2)]
        [TestCategory("Sanity")]
        [TestMethod]
        public void New()
        {
        }
    }
}
