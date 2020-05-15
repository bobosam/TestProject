namespace CRMUITests.UITests.ApplicationTests
{
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using CRMUITests.Pages.Applicaton;
    using CRMUITests.Pages.Applicaton.AdditionalInfoPage;
    using CRMUITests.Pages.Applicaton.AddressPage;
    using CRMUITests.Pages.Applicaton.ClientOpinionPage;
    using CRMUITests.Pages.Applicaton.ContactsPage;
    using CRMUITests.Pages.Applicaton.FraudSuspicionPage;
    using CRMUITests.Pages.Applicaton.IncomePage;
    using CRMUITests.Pages.Applicaton.LoanParametersPage;
    using CRMUITests.Pages.Applicaton.LoanPaymentPage;
    using CRMUITests.Pages.Applicaton.OtherCreditsPage;
    using CRMUITests.Pages.Applicaton.OtherIncomePage;
    using CRMUITests.Pages.Applicaton.PersonalDataPage;
    using CRMUITests.Pages.Applicaton.PrintingDocumentsPage;
    using CRMUITests.Pages.Applicaton.UploadDocumentsPage;
    using CRMUITests.Pages.HomePage;
    using DataDriven.Models.CRM.Applicaton;
    using DataDriven;
    using BaseUITests;
    using BaseUITests.Pages.LoginPage;
    using DataDriven.Models;

    [TestClass]
    public class EditCreditParameters : BaseTest
    {
        private HomePage homePage;
        private LoginPage loginPage;
        private ApplicationMainPage applicationMainPage;
        private LoanParametersPage loanParamPage;
        private PersonalDataPage personalDataPage;
        private AddressPage addressPage;
        private ContactsPage contactsPage;
        private AdditionalInfoPage additionalInfoPage;
        private OtherCreditsPage creditsPage;
        private IncomePage incomePage;
        private OtherIncomePage otherIncomePage;
        private LoanPaymentPage loanPaymentPage;
        private PrintingDocumentsPage printingDocumentsPage;
        private UploadDocumentsPage uploadDocumentsPage;
        private ClientOpinionPage clientOpinionPage;
        private FraudSuspicionPage fraudSuspicionsPage;

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
            this.applicationMainPage = new ApplicationMainPage(this.Driver);
            this.loginPage = new LoginPage(this.Driver);
            this.loanParamPage = new LoanParametersPage(this.Driver);
            this.personalDataPage = new PersonalDataPage(this.Driver);
            this.addressPage = new AddressPage(this.Driver);
            this.contactsPage = new ContactsPage(this.Driver);
            this.additionalInfoPage = new AdditionalInfoPage(this.Driver);
            this.creditsPage = new OtherCreditsPage(this.Driver);
            this.incomePage = new IncomePage(this.Driver);
            this.otherIncomePage = new OtherIncomePage(this.Driver);
            this.homePage = new HomePage(this.Driver);
            this.loanPaymentPage = new LoanPaymentPage(this.Driver);
            this.printingDocumentsPage = new PrintingDocumentsPage(this.Driver);
            this.uploadDocumentsPage = new UploadDocumentsPage(this.Driver);
            this.clientOpinionPage = new ClientOpinionPage(this.Driver);
            this.fraudSuspicionsPage = new FraudSuspicionPage(this.Driver);

            var user = AccessExcelData.GetTestData<User>("TestName", "TestUser", "Users", BaseConstants.UsersXlsxFilename);
            this.loginPage.AnotherUserLogin(user, BaseConstants.TestCRMUrl);
            Thread.Sleep(1500);
            this.homePage.Applications.Click();
            this.applicationMainPage.OpenNewApplication();
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            this.TestCleanup();
        }

        [Owner("Boyko Andonov")]
        [Priority(2)]
        [TestCategory("CRMApplication")]
        [TestCategory("CRMApplication/CreditParameters")]
        [TestMethod]
        public void CreditParameters_ValidData_Create()
        {
            var loanParameters = AccessExcelData.GetTestData<LoanParameters>("TestName", "valid", "LoanParameters", CRMConstants.ApplicationXlsxFilename);
            var pid = HelpMethods.GeneratePID(18, 0);
            loanParameters.Pid = pid;
            this.loanParamPage.FillLoanParameters(loanParameters);
            this.applicationMainPage.SaveAndContiunueGoBackSaveAndContiunue();
        }

        [Owner("Boyko Andonov")]
        [Priority(2)]
        [TestCategory("CRMApplication")]
        [TestCategory("CRMApplication/CreditParameters")]
        [TestMethod]
        public void CreditParameters_InvalidPID_ShowError()
        {
            var loanParameters = AccessExcelData.GetTestData<LoanParameters>("TestName", "valid", "LoanParameters", CRMConstants.ApplicationXlsxFilename);
            var pid = HelpMethods.GeneratePID(18, -1);
            loanParameters.Pid = pid;
            this.loanParamPage.FillLoanParameters(loanParameters);
            this.applicationMainPage.SaveAndContiunueTab();
            loanParamPage.AssertWrongPid();
        }

        [Owner("Boyko Andonov")]
        [Priority(2)]
        [TestCategory("CRMApplication")]
        [TestCategory("CRMApplication/CreditParameters")]
        [TestMethod]
        public void CreditParameters_WithoutParameters_InactiveSave()
        {
            var testNames = new string[] { "WithoutPid", "WithoutLoanRate", "WithoutPaymentDate", "WithoutLoanPurpose", "WithoutRequestSource" };
            foreach (var name in testNames)
            {
                var loanParameters = AccessExcelData.GetTestData<LoanParameters>("TestName", name, "LoanParameters", CRMConstants.ApplicationXlsxFilename);
                this.loanParamPage.FillLoanParameters(loanParameters);
                loanParamPage.AssertDisabledElement(loanParamPage.SaveAndContinueButton);
                homePage.Applications.Click();
                this.applicationMainPage.OpenNewApplication();
            }
        }

        [Owner("Boyko Andonov")]
        [Priority(2)]
        [TestCategory("CRMApplication")]
        [TestCategory("CRMApplication/CreditParameters")]
        [TestMethod]
        public void CreditParameters_ChangeParameters_MustBeChanged()
        {
            var loanParametersFirst = AccessExcelData.GetTestData<LoanParameters>("TestName", "ChangeParametersFirst", "LoanParameters", CRMConstants.ApplicationXlsxFilename);
            var loanParametersSecond = AccessExcelData.GetTestData<LoanParameters>("TestName", "ChangeParametersSecond", "LoanParameters", CRMConstants.ApplicationXlsxFilename);

            this.loanParamPage.FillLoanParameters(loanParametersFirst);
            this.applicationMainPage.SaveAndContinueButton.Click();
            this.applicationMainPage.Back.Click();
            this.loanParamPage.FillLoanParameters(loanParametersSecond);
            loanParametersSecond.Pid = loanParametersFirst.Pid;
            this.applicationMainPage.SaveAndContinueButton.Click();
            Thread.Sleep(1000);
            this.applicationMainPage.Back.Click();
            Thread.Sleep(1000);
            this.loanParamPage.CheckSavedParameters(loanParametersSecond);
        }
    }
}
