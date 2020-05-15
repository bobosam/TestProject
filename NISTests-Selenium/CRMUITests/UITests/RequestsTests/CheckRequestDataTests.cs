namespace CRMUITests.UITests.RequestsTests
{
    using BaseUITests;
    using BaseUITests.Pages.LoginPage;
    using CRMUITests.Pages.HomePage;
    using CRMUITests.Pages.Request.RequestMainPage;
    using DataDriven;
    using DataDriven.Models;
    using DataDriven.Models.CRM.Request;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Threading;

    [TestClass]
    public class CheckRequestDataTests : BaseTest
    {
        private HomePage homePage;
        private LoginPage loginPage;
        private RequestMainPage requestMainPage;

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
            this.requestMainPage = new RequestMainPage(this.Driver);
            this.homePage = new HomePage(this.Driver);
            this.loginPage = new LoginPage(this.Driver);

            var user = AccessExcelData.GetTestData<User>("TestName", "TestUser", "Users", BaseConstants.UsersXlsxFilename);
            this.loginPage.AnotherUserLogin(user, BaseConstants.TestCRMUrl);
            Thread.Sleep(1500);
            this.homePage.Requests.Click();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            this.TestCleanup();
        }

        [Owner("Boyko Andonov")]
        [Priority(1)]
        [TestCategory("Sanity")]
        [TestCategory("CRMRequest")]
        [TestMethod]
        public void CheckRequestMainPageGridOrderByDate()
        {
            this.requestMainPage.CheckGridOrderByCreatedOn(this.requestMainPage.AllRequestCreatedOn);
        }

        [Owner("Boyko Andonov")]
        [Priority(1)]
        [TestCategory("Sanity")]
        [TestCategory("CRMRequest")]
        [TestMethod]
        public void FirstRequestDetailsData()
        {
            Thread.Sleep(1000);
            RequestData requestData = this.requestMainPage.GetFirstRequestData();
            this.requestMainPage.FirstRequestID.Click();
            this.requestMainPage.CheckRequestDetailsData(requestData);
        }

        [Owner("Boyko Andonov")]
        [Priority(1)]
        [TestCategory("Sanity")]
        [TestCategory("CRMRequest")]
        [TestMethod]
        public void FirstRequestModalData()
        {
            RequestData requestData = this.requestMainPage.GetFirstRequestData();
            this.requestMainPage.FirstRequestID.Click();
            this.requestMainPage.DetailsButton.Click();
            this.requestMainPage.CheckRequestModalData(requestData);
            this.requestMainPage.ModalDetailsClosingButton.Click();
        }

        [Owner("Boyko Andonov")]
        [Priority(1)]
        [TestCategory("Sanity")]
        [TestCategory("CRMRequest")]
        [TestMethod]
        public void RedistibuteToTS()
        {
            this.requestMainPage.GoToRedistribution();
            this.requestMainPage.RedistrbutionToTS.Click();
            this.requestMainPage.Redistribute.Click();
        }

        [Owner("Boyko Andonov")]
        [Priority(1)]
        [TestCategory("Sanity")]
        [TestCategory("CRMRequest")]
        [TestMethod]
        public void RedistibuteToSNOffice()
        {
            this.requestMainPage.GoToRedistribution();
            this.requestMainPage.RedistrbutionToSN.Click();
            this.requestMainPage.OffisRedistribution.Click();
            this.requestMainPage.Type(this.requestMainPage.RedstrbutionSelectOffices, "о");
            this.requestMainPage.RedstrbutionSelectOfficesFirst.Click();
            Thread.Sleep(500);
            this.requestMainPage.RedstrbutionOrganizationUnitDropdown.Click();
            this.requestMainPage.RedstrbutionOrganizationUnitDropdownFirst.Click();
            this.requestMainPage.Redistribute.Click();
        }

        [Owner("Boyko Andonov")]
        [Priority(1)]
        [TestCategory("Sanity")]
        [TestCategory("CRMRequest")]
        [TestMethod]
        public void RedistibuteToSNSubarea()
        {
            this.requestMainPage.GoToRedistribution();
            this.requestMainPage.RedistrbutionToSN.Click();
            this.requestMainPage.Type(this.requestMainPage.RedstrbutionSelectOrganizatonUnit, "о");
            this.requestMainPage.RedstrbutionSelectOrganizatonUnitFirst.Click();
            this.requestMainPage.Redistribute.Click();
        }

        [Owner("Boyko Andonov")]
        [Priority(1)]
        [TestCategory("Sanity")]
        [TestCategory("CRMRequest")]
        [TestMethod]
        public void RequestGoToOffer()
        {
            this.requestMainPage.FirstRequestID.Click();
            this.requestMainPage.DetailsActions.Click();
            this.requestMainPage.DetailsActionsToOffer.Click();

            // TODO Go to offer asserts
        }
    }
}
