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
    using System;

    [TestClass]
    public class EditClPersonalData : BaseTest
    {
        private string pid;
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
            pid = HelpMethods.GeneratePID(18, 0);
            Thread.Sleep(1500);
            personalDataPage.FillPreviousData(homePage, applicationMainPage, loanParamPage, pid);
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            this.TestCleanup();
        }

        [Owner("Boyko Andonov")]
        [Priority(2)]
        [TestCategory("CRMApplication")]
        [TestCategory("CRMApplication/ClPersonalData")]
        [TestMethod]
        public void ClientPersonalData_ValidData_Created()
        {
            var personalData = AccessExcelData.GetTestData<PersonalData>("TestName", "Sanity", "PersonalData", CRMConstants.ApplicationXlsxFilename);
            personalData.Pid = pid;
            personalData.BirthDate = HelpMethods.GetBirthDayByPid(pid);
            this.personalDataPage.FillPersonalData(personalData);
            this.applicationMainPage.SaveAndContiunueGoBackSaveAndContiunue();
        }

        [Owner("Boyko Andonov")]
        [Priority(2)]
        [TestCategory("CRMApplication")]
        [TestCategory("CRMApplication/ClPersonalData")]
        [TestMethod]
        public void PersonalData_InvalidName_ShowError()
        {
            var personalData = AccessExcelData.GetTestData<PersonalData>("TestName", "Sanity", "PersonalData", CRMConstants.ApplicationXlsxFilename);
            personalData.Pid = pid;
            personalData.BirthDate = HelpMethods.GetBirthDayByPid(pid);
            var origFirstName = personalData.FirstName;
            var origSecondName = personalData.SecondName;
            var origLastName = personalData.LastName;

            var wrongNames = BaseConstants.wrongNames;

            foreach (var name in wrongNames)
            {
                personalData.FirstName = name;
                this.personalDataPage.FillPersonalData(personalData);
                personalDataPage.AssertCirilik();
                personalDataPage.Refreshe();

                personalData.FirstName = origFirstName;
                personalData.SecondName = name;
                this.personalDataPage.FillPersonalData(personalData);
                personalDataPage.AssertCirilik();
                personalDataPage.Refreshe();

                personalData.SecondName = origSecondName;
                personalData.LastName = name;
                this.personalDataPage.FillPersonalData(personalData);
                personalDataPage.AssertCirilik();
                personalDataPage.Refreshe();

                personalData.LastName = origLastName;
            }
        }

        [Owner("Boyko Andonov")]
        [Priority(2)]
        [TestCategory("CRMApplication")]
        [TestCategory("CRMApplication/ClPersonalData")]
        [TestMethod]
        public void PersonalData_InvalidIdCardNumber_ShowError()
        {
            var personalData = AccessExcelData.GetTestData<PersonalData>("TestName", "Sanity", "PersonalData", CRMConstants.ApplicationXlsxFilename);
            personalData.Pid = pid;
            personalData.BirthDate = HelpMethods.GetBirthDayByPid(pid);
            var wrongCardNumbers = BaseConstants.wrongIdCardNumber;

            foreach (var number in wrongCardNumbers)
            {
                personalData.IdCardNumber = number;
                this.personalDataPage.FillPersonalData(personalData);
                personalDataPage.AssertWrongNumber();
                personalDataPage.Refreshe();
            }
        }

        [Owner("Boyko Andonov")]
        [Priority(2)]
        [TestCategory("CRMApplication")]
        [TestCategory("CRMApplication/ClPersonalData")]
        [TestMethod]
        public void PersonalData_InvalidCardDate_ShowError()
        {
            var personalData = AccessExcelData.GetTestData<PersonalData>("TestName", "Sanity", "PersonalData", CRMConstants.ApplicationXlsxFilename);
            personalData.Pid = pid;
            personalData.BirthDate = HelpMethods.GetBirthDayByPid(pid);

            var currentDay = DateTime.Now;
            var wrongCardCreationDate = currentDay.AddDays(+1).ToString("dd.MM.yyyy");
            var wrongCardExpirationDate = currentDay.AddDays(-1).ToString("dd.MM.yyyy");
            personalData.CardCreationDate = wrongCardCreationDate;
            this.personalDataPage.FillPersonalData(personalData);
            this.personalDataPage.AssertWrongDate();
            this.personalDataPage.Refreshe();

            personalData.CardCreationDate = currentDay.ToString("dd.MM.yyyy");
            personalData.CardExpirationDate = wrongCardExpirationDate;
            this.personalDataPage.FillPersonalData(personalData);
            this.personalDataPage.AssertWrongDate();
            this.personalDataPage.Refreshe();
        }

        [Owner("Boyko Andonov")]
        [Priority(2)]
        [TestCategory("CRMApplication")]
        [TestCategory("CRMApplication/ClPersonalData")]
        [TestMethod]
        public void PersonalData_WithoutParameters_InactiveSaveButton()
        {
            var testNames = new string[] { "WithoutFirstName", "WithoutSecondName", "WithoutLastName", "WithoutPersonType", "WithoutIdCardNumber", "WithoutIdCardCreationDate", "WithoutIdCardExpirationDate", "WithoutIdCardIssuer" };
            foreach (var name in testNames)
            {
                var personalData = AccessExcelData.GetTestData<PersonalData>("TestName", name, "PersonalData", CRMConstants.ApplicationXlsxFilename);
                personalData.Pid = pid;
                personalData.BirthDate = HelpMethods.GetBirthDayByPid(pid);
                this.personalDataPage.FillPersonalData(personalData);
                personalDataPage.AssertDisabledElement(personalDataPage.SaveAndContinueButton);
                personalDataPage.AssertMissingData();
                if (name != "WithoutIdCardIssuer")
                {
                    personalDataPage.FillPreviousData(homePage, applicationMainPage, loanParamPage, pid);
                }
            }
        }

        [Owner("Boyko Andonov")]
        [Priority(2)]
        [TestCategory("CRMApplication")]
        [TestCategory("CRMApplication/ClPersonalData")]
        [TestMethod]
        public void PersonalData_ChangeParameters_MustBeChanging()
        {
            var personalDataFirst = AccessExcelData.GetTestData<PersonalData>("TestName", "ChangeParametersFirst", "PersonalData", CRMConstants.ApplicationXlsxFilename);
            var personalDataSecond = AccessExcelData.GetTestData<PersonalData>("TestName", "ChangeParametersSecond", "PersonalData", CRMConstants.ApplicationXlsxFilename);
            personalDataFirst.Pid = pid;
            personalDataFirst.BirthDate = HelpMethods.GetBirthDayByPid(pid);
            personalDataSecond.Pid = pid;
            personalDataSecond.BirthDate = HelpMethods.GetBirthDayByPid(pid);
            this.personalDataPage.FillPersonalData(personalDataFirst);
            this.applicationMainPage.SaveAndContinueButton.Click();
            Thread.Sleep(1000);
            this.applicationMainPage.Back.Click();
            Thread.Sleep(500);
            this.personalDataPage.FillPersonalData(personalDataSecond);
            this.applicationMainPage.SaveAndContinueButton.Click();
            Thread.Sleep(1000);
            this.applicationMainPage.Back.Click();
            this.personalDataPage.CheckSavedParameters(personalDataSecond);
        }
    }
}
