namespace CRMUITests.UITests.OffersTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using BaseUITests;
    using BaseUITests.Pages.LoginPage;
    using CRMUITests.Pages.HomePage;
    using CRMUITests.Pages.Offer.OfferMainPage;
    using DataDriven;
    using DataDriven.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    class SearchOffersTests
    {
        [TestClass]
        public class NewOfferTests : BaseTest
        {
            private LoginPage loginPage;
            private HomePage homePage;
            private OfferMainPage offer;

            [ClassInitialize]
            public static void ClassInit(TestContext con)
            {
            }

            [ClassCleanup]
            public static void ClassClean()
            {
            }

            [TestInitialize]
            public void TestInit()
            {
                this.TestInitialize();
                this.loginPage = new LoginPage(this.Driver);
                this.homePage = new HomePage(this.Driver);
                this.offer = new OfferMainPage(this.Driver);
                var user = AccessExcelData.GetTestData<User>("TestName", "ke.pleven", "Users", BaseConstants.UsersXlsxFilename);
                this.loginPage.AnotherUserLogin(user, BaseConstants.TestCRMUrl);
                Thread.Sleep(1250);
                this.homePage.Offers.Click();
            }

            [TestCleanup]
            public void TestClean()
            {
                this.TestCleanup();
            }

            [Priority(1)]
            [TestCategory("SearchOffer")]
            [Owner("Diana Grueva")]
            [TestMethod]
            public void Search()
            {
                var search = AccessExcelData.GetTestData<DataDriven.Models.CRM.Offer.SearchOffer>("TestName", "Sanity", "SearchOffer", CRMConstants.OfferXlsxFilename);

                this.offer.SearchOffers(search);
                this.offer.AdvancedSearch(search);
                this.offer.Search();
            }
        }
    }
}
