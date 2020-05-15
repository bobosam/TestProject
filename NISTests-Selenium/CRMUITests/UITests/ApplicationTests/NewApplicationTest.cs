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
    using CDataDriven.Models.CRM.Applicaton;
    using BaseUITests;
    using BaseUITests.Pages.LoginPage;
    using DataDriven.Models;

    [TestClass]
    public class NewApplicationTest : BaseTest
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
        [Priority(1)]
        [TestCategory("Sanity")]
        [TestCategory("CRMApplication")]
        [TestMethod]
        public void CreateNewApplication()
        {
            // Add loan parameters
            var loanParameters = AccessExcelData.GetTestData<LoanParameters>("TestName", "Sanity", "LoanParameters", CRMConstants.ApplicationXlsxFilename);
            var pid = HelpMethods.GeneratePID(18, 0);
            loanParameters.Pid = pid;
            this.loanParamPage.FillLoanParameters(loanParameters);
            this.applicationMainPage.SaveAndContiunueGoBackSaveAndContiunue();

            // Add client personal data 
            var personalData = AccessExcelData.GetTestData<PersonalData>("TestName", "Sanity", "PersonalData", CRMConstants.ApplicationXlsxFilename);
            personalData.Pid = pid;
            personalData.BirthDate = HelpMethods.GetBirthDayByPid(pid);
            this.personalDataPage.FillPersonalData(personalData);
            this.applicationMainPage.SaveAndContiunueGoBackSaveAndContiunue();

            // Add client address
            var address = AccessExcelData.GetTestData<Address>("TestName", "SanityPermanent", "Address", CRMConstants.ApplicationXlsxFilename);
            this.addressPage.FillAddress(address, 0);
            this.applicationMainPage.SaveAndContiunueGoBackSaveAndContiunue();

            // Add client contacts
            var contacts = AccessExcelData.GetTestData<Contacts>("TestName", "Sanity", "Contacts", CRMConstants.ApplicationXlsxFilename);
            this.contactsPage.FillContacts(contacts);
            this.applicationMainPage.SaveAndContiunueGoBackSaveAndContiunue();

            // Add additional info - data for partner
            var partnerPid = HelpMethods.GeneratePID(18, 1);
            var additionalInfo = AccessExcelData.GetTestData<GeneralInfo>("TestName", "Sanity", "GeneralInfo", CRMConstants.ApplicationXlsxFilename);
            additionalInfo.PartnerPid = partnerPid;
            this.additionalInfoPage.FillAdditionalInfoPage(additionalInfo);
            this.applicationMainPage.SaveAndContiunueGoBackSaveAndContiunue();

            // Add client other credits
            var otherCredits = AccessExcelData.GetTestData<CreditsInfo>("TestName", "Sanity", "CreditsInfo", CRMConstants.ApplicationXlsxFilename);
            this.creditsPage.FillCredits(otherCredits);
            this.applicationMainPage.SaveAndContiunueGoBackSaveAndContiunue();

            // Add client income
            var income = AccessExcelData.GetTestData<Incomes>("TestName", "Sanity", "Incomes", CRMConstants.ApplicationXlsxFilename);
            var addressEmploee = AccessExcelData.GetTestData<Address>("TestName", "SanityEmployer", "Address", CRMConstants.ApplicationXlsxFilename);
            this.incomePage.FillIncome(addressEmploee, income);
            this.applicationMainPage.SaveAndContiunueGoBackSaveAndContiunue();

            // Add client other income
            var otherIncome = AccessExcelData.GetTestData<OtherIncomes>("TestName", "Sanity", "OtherIncomes", CRMConstants.ApplicationXlsxFilename);
            this.otherIncomePage.FillOtherIncome(otherIncome);
            this.applicationMainPage.SaveAndContiunueGoBackSaveAndContiunue();

            // Add co debtor personal data
            var personalDataCD = AccessExcelData.GetTestData<PersonalData>("TestName", "SanityCD", "PersonalData", CRMConstants.ApplicationXlsxFilename);
            personalDataCD.Pid = HelpMethods.GeneratePID(22, 0);
            personalDataCD.BirthDate = HelpMethods.GetBirthDayByPid(personalDataCD.Pid);
            this.personalDataPage.FillCDPersonalData(personalDataCD);
            this.applicationMainPage.SaveAndContiunueGoBackSaveAndContiunue();

            // Add co debtor address
            var addressCD = AccessExcelData.GetTestData<Address>("TestName", "SanityPermanentCD", "Address", CRMConstants.ApplicationXlsxFilename);
            this.addressPage.FillAddress(addressCD, 0);
            this.applicationMainPage.SaveAndContiunueGoBackSaveAndContiunue();

            // Add co debtor contacts
            var contactsCD = AccessExcelData.GetTestData<Contacts>("TestName", "SanityCD", "Contacts", CRMConstants.ApplicationXlsxFilename);
            this.contactsPage.FillCDContacts(contactsCD);
            this.applicationMainPage.SaveAndContiunueGoBackSaveAndContiunue();

            // Add co debtor additional info
            var additionalInfoCD = AccessExcelData.GetTestData<GeneralInfo>("TestName", "SanityCD", "GeneralInfo", CRMConstants.ApplicationXlsxFilename);
            this.additionalInfoPage.FillCDAdditionalInfoPage(additionalInfoCD);
            this.applicationMainPage.SaveAndContiunueGoBackSaveAndContiunue();

            // Add co debtor credits info
            var otherCreditsCD = AccessExcelData.GetTestData<CreditsInfo>("TestName", "SanityCD", "CreditsInfo", CRMConstants.ApplicationXlsxFilename);
            this.creditsPage.FillCDCredits(otherCreditsCD);
            this.applicationMainPage.SaveAndContiunueGoBackSaveAndContiunue();

            // Add co debtor incomes info
            var incomeCD = AccessExcelData.GetTestData<Incomes>("TestName", "SanityCD", "Incomes", CRMConstants.ApplicationXlsxFilename);
            var addressEmployerCD = AccessExcelData.GetTestData<Address>("TestName", "SanityEmployerCD", "Address", CRMConstants.ApplicationXlsxFilename);
            this.incomePage.FillIncome(addressEmployerCD, incomeCD);
            this.applicationMainPage.SaveAndContiunueGoBackSaveAndContiunue();

            // Add co debtor other incomes info
            var otherIncomeCD = AccessExcelData.GetTestData<OtherIncomes>("TestName", "SanityCD", "OtherIncomes", CRMConstants.ApplicationXlsxFilename);
            this.otherIncomePage.FillOtherIncome(otherIncomeCD);
            this.applicationMainPage.SaveAndContiunueGoBackSaveAndContiunue();

            // Add loan payment type
            var paymentType = AccessExcelData.GetTestData<LoanPayment>("TestName", "Sanity", "LoanPayment", CRMConstants.ApplicationXlsxFilename);
            this.loanPaymentPage.FillLoanPayement(paymentType);
            this.applicationMainPage.SaveAndContiunueGoBackSaveAndContiunue();

            // Printing Documents
            var printingDocuments = AccessExcelData.GetTestData<PrintingDocuments>("TestName", "Sanity", "PrintingDocuments", CRMConstants.ApplicationXlsxFilename);
            this.printingDocumentsPage.FillPrintingDocumentsManual(printingDocuments);
            this.applicationMainPage.SaveAndContiunueTab();

            // Upload Documents
            var uploadDocuments = AccessExcelData.GetTestData<UploadDocuments>("TestName", "Sanity", "UploadDocuments", CRMConstants.ApplicationXlsxFilename);
            this.uploadDocumentsPage.FillUploadDocuments(uploadDocuments);
            this.applicationMainPage.SaveAndContiunueTab();

            // Add opinion for client
            var opinion = AccessExcelData.GetTestData<ClientOpinion>("TestName", "Sanity", "ClientOpinion", CRMConstants.ApplicationXlsxFilename);
            this.clientOpinionPage.FillClientOpinionPage(opinion);
            this.applicationMainPage.SaveAndContiunueGoBackSaveAndContiunue();

            // Add suspicion for fraud 
            var fraudSuspicions = AccessExcelData.GetTestData<FraudSuspicion>("TestName", "Sanity", "FraudSuspicion", CRMConstants.ApplicationXlsxFilename);
            this.fraudSuspicionsPage.FillFraudSuspicionPage(fraudSuspicions);
            this.fraudSuspicionsPage.Send.Click();
            this.fraudSuspicionsPage.AssertForSending();
        }
    }
}
