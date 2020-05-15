namespace CRMUITests.UITests.OffersTests
{
    using BaseUITests;
    using BaseUITests.Pages.LoginPage;
    using CRMUITests.Pages.Applicaton.LoanParametersPage;
    using CRMUITests.Pages.HomePage;
    using CRMUITests.Pages.Offer.AutoOfferPage;
    using CRMUITests.Pages.Offer.CustomOfferPage;
    using CRMUITests.Pages.Offer.OfferMainPage;
    using DataDriven;
    using DataDriven.Models.CRM.Offer;
    using DataDriven.Models;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Threading;

    [TestClass]
    public class NewOfferTest : BaseTest
    {
        private LoginPage loginPage;
        private HomePage homePage;
        private OfferMainPage offerMainPage;
        private CustomOfferPage customOffer;
        private AutoOfferPage autoOffer;

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
            this.offerMainPage = new OfferMainPage(this.Driver);
            this.customOffer = new CustomOfferPage(this.Driver);
            this.autoOffer = new AutoOfferPage(this.Driver);
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
        [TestCategory("Sanity")]
        [Owner("Diana Grueva")]
        [TestMethod]
        public void AssertOfferPages()
        {
            this.offerMainPage.AssertMainPage();

            this.offerMainPage.NewOffer.Click();
            this.offerMainPage.AssertNewOfferPage();

            this.customOffer.NavigateTo();
            this.offerMainPage.AssertCustomOfferPage();
        }

        [Priority(2)]
        [TestCategory("Sanity")]
        [Owner("Diana Grueva")]
        [TestMethod]
        public void RejectManualOffer()
        {
            var mOffer = AccessExcelData.GetTestData<CustomOffer>("TestName", "Sanity", "CustomOffer", CRMConstants.OfferXlsxFilename);

            this.offerMainPage.NewOffer.Click();
            this.customOffer.NavigateTo();
            this.customOffer.CreateCustomOfferOne(mOffer);
            this.customOffer.RejectAllOffers();
            this.offerMainPage.AssertRejectionPage();
            this.customOffer.RejectionReason(CRMConstants.reasons[1]);
            this.offerMainPage.AssertMainPage();
        }

        [Priority(2)]
        [TestCategory("Sanity")]
        [Owner("Diana Grueva")]
        [TestMethod]
        public void AcceptManualOffer()
        {
            var mOffer = AccessExcelData.GetTestData<CustomOffer>("TestName", "Sanity", "CustomOffer", CRMConstants.OfferXlsxFilename);

            this.offerMainPage.NewOffer.Click();
            this.customOffer.NavigateTo();
            this.customOffer.CreateCustomOfferOne(mOffer);
            this.customOffer.AcceptOfferOne();

            Thread.Sleep(1000);
            LoanParametersPage loanParamPage = new LoanParametersPage(this.Driver);
            loanParamPage.AssertApplicationPage();
            loanParamPage.AssertAcceptedOfferParameters(mOffer);
        }

        [Priority(2)]
        [TestCategory("Sanity")]
        [Owner("Diana Grueva")]
        [TestMethod]
        public void PendingDecisionManualOffer()
        {
            var mOffer = AccessExcelData.GetTestData<CustomOffer>("TestName", "Sanity", "CustomOffer", CRMConstants.OfferXlsxFilename);

            this.offerMainPage.NewOffer.Click();
            this.customOffer.NavigateTo();
            this.customOffer.CreateCustomOfferOne(mOffer);
            this.customOffer.RethinkDecision();
            this.offerMainPage.AssertMainPage();
        }

        [Priority(2)]
        [TestCategory("Sanity")]
        [Owner("Diana Grueva")]
        [TestMethod]
        public void AcceptAutomaticOfferWithJD()
        {
            var aOfferCl = AccessExcelData.GetTestData<AutoOffer>("TestName", "Sanity", "AutoOffer", CRMConstants.OfferXlsxFilename);
            var aOfferJD = AccessExcelData.GetTestData<AutoOffer>("TestName", "SanityJD", "AutoOffer", CRMConstants.OfferXlsxFilename);

            this.offerMainPage.NewOffer.Click();
            this.autoOffer.CheckClientPid(aOfferCl);
            this.autoOffer.CheckJDPid(aOfferJD);
            this.autoOffer.GoToAutoOfferPage();
            this.autoOffer.FilloutClientData(aOfferCl);
            this.autoOffer.FilloutJDData(aOfferJD);

            this.autoOffer.CalculateOfferts();

            CustomOffer AcceptedOffer = this.autoOffer.GetOffer("Upsell");
            this.autoOffer.AcceptOffer("Upsell");
            //this.autoOffer.SigningUpHand(); отпада наччин на подписване

            LoanParametersPage loanParamPage = new LoanParametersPage(this.Driver);
            loanParamPage.AssertApplicationPage();
            loanParamPage.AssertAcceptedOfferParameters(AcceptedOffer);
        }

        [Priority(2)]
        [TestCategory("Sanity")]
        [Owner("Diana Grueva")]
        [TestMethod]
        public void AcceptAutomaticOfferWithoutJD()
        {
            var aOfferCl = AccessExcelData.GetTestData<AutoOffer>("TestName", "Sanity", "AutoOffer", CRMConstants.OfferXlsxFilename);

            this.offerMainPage.NewOffer.Click();
            this.autoOffer.CheckClientPid(aOfferCl);
            this.autoOffer.GoToAutoOfferPage();
            this.autoOffer.FilloutClientData(aOfferCl);

            this.autoOffer.CalculateOfferts();

            CustomOffer AcceptedOffer = this.autoOffer.GetOffer("RequestedParams");
            this.autoOffer.AcceptOffer("RequestedParams");
            //this.autoOffer.SigningUpHand(); отпада начин на подписване

            LoanParametersPage loanParamPage = new LoanParametersPage(this.Driver);
            loanParamPage.AssertApplicationPage();
            loanParamPage.AssertAcceptedOfferParameters(AcceptedOffer);
        }

        [Priority(3)]
        [TestCategory("Sanity")]
        [Owner("Diana Grueva")]
        [TestMethod]
        public void RemoveAutomaticOffer()
        {
            var aOfferCl = AccessExcelData.GetTestData<AutoOffer>("TestName", "Sanity", "AutoOffer", CRMConstants.OfferXlsxFilename);

            this.offerMainPage.NewOffer.Click();
            this.autoOffer.CheckClientPid(aOfferCl);
            this.autoOffer.GoToAutoOfferPage();
            this.autoOffer.FilloutClientData(aOfferCl);

            this.autoOffer.CalculateOfferts();
            this.autoOffer.AssertOfferTypeExist("RequestedParams");
            this.autoOffer.RemoveOffer("RequestedParams");
            this.autoOffer.AssertOfferRemoved("RequestedParams");
        }

        [Priority(3)]
        [TestCategory("Sanity")]
        [Owner("Diana Grueva")]
        [TestMethod]
        public void RejectAutomaticOffers()
        {
            var aOfferCl = AccessExcelData.GetTestData<AutoOffer>("TestName", "Sanity", "AutoOffer", CRMConstants.OfferXlsxFilename);

            this.offerMainPage.NewOffer.Click();
            this.autoOffer.CheckClientPid(aOfferCl);
            this.autoOffer.GoToAutoOfferPage();
            this.autoOffer.FilloutClientData(aOfferCl);

            this.autoOffer.CalculateOfferts();
            this.autoOffer.RejectAllOffers();
            this.autoOffer.RejectionReason(CRMConstants.reasons[2]);
            this.offerMainPage.AssertMainPage();
        }

        [Priority(3)]
        [TestCategory("Sanity")]
        [Owner("Diana Grueva")]
        [TestMethod]
        public void PendingDecisionAutomaticOffers()
        {
            var aOfferCl = AccessExcelData.GetTestData<AutoOffer>("TestName", "Sanity", "AutoOffer", CRMConstants.OfferXlsxFilename);

            this.offerMainPage.NewOffer.Click();
            this.autoOffer.CheckClientPid(aOfferCl);
            this.autoOffer.GoToAutoOfferPage();
            this.autoOffer.FilloutClientData(aOfferCl);

            this.autoOffer.CalculateOfferts();
            this.autoOffer.RethinkDecision();
            this.offerMainPage.AssertMainPage();
        }

        [Priority(3)]
        [TestCategory("Sanity")]
        [Owner("Diana Grueva")]
        [TestMethod]
        public void CheckPidInvalidPids()
        {
            AutoOffer invalidClientPid = new AutoOffer();
            AutoOffer invalidJDPid = new AutoOffer();
            invalidClientPid.Pid = "0000001212";
            invalidJDPid.Pid = "0710128595";

            this.offerMainPage.NewOffer.Click();
            this.autoOffer.CheckClientPid(invalidClientPid);
            this.autoOffer.AssertPidValidation();
            this.autoOffer.CheckJDPid(invalidJDPid);
            this.autoOffer.AssertPidValidation();
        }

        [Priority(3)]
        [TestCategory("Sanity")]
        [Owner("Diana Grueva")]
        [TestMethod]
        public void CheckPidInvalidJDPid()
        {
            AutoOffer validClientPid = new AutoOffer();
            AutoOffer invalidJDPid = new AutoOffer();
            validClientPid.Pid = "6312168899";
            invalidJDPid.Pid = "0710128595";

            this.offerMainPage.NewOffer.Click();
            this.autoOffer.CheckClientPid(validClientPid);
            this.autoOffer.CheckJDPid(invalidJDPid);
            Thread.Sleep(1000);
            this.autoOffer.AssertPidValidation();
        }

        [Priority(3)]
        [TestCategory("Sanity")]
        [Owner("Diana Grueva")]
        [TestMethod]
        public void CheckPidUnder18JD()
        {
            AutoOffer validClientPid = new AutoOffer();
            AutoOffer invalidJDPid = new AutoOffer();
            validClientPid.Pid = "0743144618 ";
            invalidJDPid.Pid = "0346136118";

            this.offerMainPage.NewOffer.Click();
            this.autoOffer.CheckClientPid(validClientPid);
            this.autoOffer.CheckJDPid(invalidJDPid);
            Thread.Sleep(1000);
            this.autoOffer.AssertPidValidation();
        }

        [Priority(3)]
        [TestCategory("Sanity")]
        [Owner("Diana Grueva")]
        [TestMethod]
        public void CheckPidUnder18Client()
        {
            AutoOffer under18ClientPid = new AutoOffer();
            AutoOffer validJDPid = new AutoOffer();
            under18ClientPid.Pid = "0346136118 ";
            validJDPid.Pid = "0743144618";

            this.offerMainPage.NewOffer.Click();
            this.autoOffer.CheckClientPid(under18ClientPid);
            this.autoOffer.CheckJDPid(validJDPid);
            Thread.Sleep(1000);
            this.autoOffer.AssertPidValidation();
        }
    }
}
