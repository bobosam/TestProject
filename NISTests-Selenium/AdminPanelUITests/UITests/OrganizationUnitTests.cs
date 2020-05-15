namespace AdminPanelUITests.UITests
{
    using AdminPanelUITests.Pages.APHomePage;
    using AdminPanelUITests.Pages.OrganizationUnitPage;
    using BaseUITests;
    using BaseUITests.Pages.LoginPage;
    using DataDriven;
    using DataDriven.Models;
    using DataDriven.Models.AdminPanel;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Threading;

    [TestClass]
    public class OrganizationUnitTests : BaseTest
    {
        private APHomePage homePage;
        private LoginPage loginPage;
        private OrganizationUnitPage organizatonUnitPage;

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
            this.homePage = new APHomePage(this.Driver);
            this.loginPage = new LoginPage(this.Driver);
            this.organizatonUnitPage = new OrganizationUnitPage(this.Driver);

            var user = AccessExcelData.GetTestData<User>("TestName", "TestUser", "Users", BaseConstants.UsersXlsxFilename);
            this.loginPage.AnotherUserLogin(user, BaseConstants.TestAdminPanelUrl);
            Thread.Sleep(3000);
            this.homePage.OrganizationUnits.Click();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            this.TestCleanup();
        }

        [Owner("Boyko Andonov")]
        [Priority(1)]
        [TestCategory("Sanity")]
        [TestCategory("APOrganizationUnit")]
        [TestMethod]
        public void OrganizationUnitAddTest()
        {
            organizatonUnitPage.AssertDepartments();
            AdminPanelHelpMethods.RightClick(organizatonUnitPage.Marketing, this.Driver);
            organizatonUnitPage.AddUnit.Click();

            var unit = AccessExcelData.GetTestData<OrganizationUnit>("TestName", "Sanity", "Units", AdminPanelConstants.ApplicationXlsxFilename);
            this.organizatonUnitPage.FillUnit(unit, "add");
            this.organizatonUnitPage.Reject.Click();
        }

        [Owner("Boyko Andonov")]
        [Priority(1)]
        [TestCategory("Sanity")]
        [TestCategory("APOrganizationUnit")]
        [TestMethod]
        public void OrganizationUnitUpdateTest()
        {
            organizatonUnitPage.AssertDepartments();
            this.organizatonUnitPage.Marketing.Click();
            AdminPanelHelpMethods.RightClick(organizatonUnitPage.Marketing, this.Driver);
            organizatonUnitPage.UpdateUnit.Click();
            Thread.Sleep(500);
            organizatonUnitPage.AssertUnitName("Маркетинг");
            var unit = AccessExcelData.GetTestData<OrganizationUnit>("TestName", "Sanity", "Units", AdminPanelConstants.ApplicationXlsxFilename);
            this.organizatonUnitPage.FillUnit(unit, "change");
            this.organizatonUnitPage.Reject.Click();
        }

        [Owner("Boyko Andonov")]
        [Priority(1)]
        [TestCategory("Sanity")]
        [TestCategory("APOrganizationUnit")]
        [TestMethod]
        public void OrganizationUnitDeleteTest()
        {
            organizatonUnitPage.AssertDepartments();
            this.organizatonUnitPage.Marketing.Click();
            AdminPanelHelpMethods.RightClick(organizatonUnitPage.Marketing, this.Driver);
            organizatonUnitPage.DeleteUnit.Click();
            Thread.Sleep(500);
            organizatonUnitPage.DoNotDelete.Click();
        }
    }
}
