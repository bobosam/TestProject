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
    using System.Collections.Generic;

    [TestClass]
    public class EditClientAddress : BaseTest
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
            addressPage.FillPreviousData(homePage, applicationMainPage, loanParamPage, personalDataPage, pid);
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            this.TestCleanup();
        }

        [Owner("Boyko Andonov")]
        [Priority(2)]
        [TestCategory("CRMApplication")]
        [TestCategory("CRMApplication/ClientAddress")]
        [TestMethod]
        public void ClientAddress_ValidData_Created()
        {
            var permanentAddress = AccessExcelData.GetTestData<Address>("TestName", "SanityPermanent", "Address", CRMConstants.ApplicationXlsxFilename);
            var presentAddress = AccessExcelData.GetTestData<Address>("TestName", "Present", "Address", CRMConstants.ApplicationXlsxFilename);
            var correspondationAddress = AccessExcelData.GetTestData<Address>("TestName", "Correspondation", "Address", CRMConstants.ApplicationXlsxFilename);

            this.addressPage.FillAllAddresses(new List<Address> { permanentAddress, presentAddress, correspondationAddress });

            this.addressPage.SaveAndContiunueGoBackSaveAndContiunue();
        }

        [Owner("Boyko Andonov")]
        [Priority(2)]
        [TestCategory("CRMApplication")]
        [TestCategory("CRMApplication/ClientAddress")]
        [TestMethod]
        public void ClientAddress_ValidDiferentData_Created()
        {
            var blockAddress = AccessExcelData.GetTestData<Address>("TestName", "BlockAddress", "Address", CRMConstants.ApplicationXlsxFilename);
            var streetAddress = AccessExcelData.GetTestData<Address>("TestName", "StreetAddress", "Address", CRMConstants.ApplicationXlsxFilename);
            var blockStreetAddress = AccessExcelData.GetTestData<Address>("TestName", "BlockStreetAddress", "Address", CRMConstants.ApplicationXlsxFilename);

            this.addressPage.FillAllAddresses(new List<Address> { blockAddress, streetAddress, blockStreetAddress });

            this.addressPage.SaveAndContiunueGoBackSaveAndContiunue();
        }

        [Owner("Boyko Andonov")]
        [Priority(2)]
        [TestCategory("CRMApplication")]
        [TestCategory("CRMApplication/ClientAddress")]
        [TestMethod]
        public void ClientAddress_WithoutNeighbourhoodAndStreetName_ShowError()
        {
            var permanentAddress = AccessExcelData.GetTestData<Address>("TestName", "SanityPermanent", "Address", CRMConstants.ApplicationXlsxFilename);
            var presentAddress = AccessExcelData.GetTestData<Address>("TestName", "Present", "Address", CRMConstants.ApplicationXlsxFilename);
            var correspondationAddress = AccessExcelData.GetTestData<Address>("TestName", "Correspondation", "Address", CRMConstants.ApplicationXlsxFilename);
            var addresses = new List<Address> { permanentAddress, presentAddress, correspondationAddress };

            foreach (var address in addresses)
            {
                var originNeighbourhood = address.Neighbourhood;
                var originStreetName = address.StreetName;
                address.Neighbourhood = string.Empty;
                address.StreetName = string.Empty;

                this.addressPage.FillAllAddresses(addresses);
                this.addressPage.AssertCountMissingData(2);
                this.addressPage.AssertDisabledElement(this.addressPage.SaveAndContinueButton);

                address.Neighbourhood = originNeighbourhood;
                address.StreetName = originStreetName;

                this.addressPage.RefresheWithYes();
            }
        }

        [Owner("Boyko Andonov")]
        [Priority(2)]
        [TestCategory("CRMApplication")]
        [TestCategory("CRMApplication/ClientAddress")]
        [TestMethod]
        public void ClientAddress_WithoutStreetNumberAndBlockNumber_ShowError()
        {
            var permanentAddress = AccessExcelData.GetTestData<Address>("TestName", "SanityPermanent", "Address", CRMConstants.ApplicationXlsxFilename);
            var presentAddress = AccessExcelData.GetTestData<Address>("TestName", "Present", "Address", CRMConstants.ApplicationXlsxFilename);
            var correspondationAddress = AccessExcelData.GetTestData<Address>("TestName", "Correspondation", "Address", CRMConstants.ApplicationXlsxFilename);
            var addresses = new List<Address> { permanentAddress, presentAddress, correspondationAddress };

            foreach (var address in addresses)
            {
                var originStreetNumber = address.StreetNumber;
                var originBlockNumber = address.Block;
                address.StreetNumber = string.Empty;
                address.Block = string.Empty;

                this.addressPage.FillAllAddresses(addresses);
                this.addressPage.AssertCountMissingData(2);
                this.addressPage.AssertDisabledElement(this.addressPage.SaveAndContinueButton);

                address.Number = originStreetNumber;
                address.Block = originBlockNumber;

                this.addressPage.RefresheWithYes();
            }
        }

        /// <summary>
        /// When the block number is not empty - the floor is required.
        /// </summary>
        [Owner("Boyko Andonov")]
        [Priority(2)]
        [TestCategory("CRMApplication")]
        [TestCategory("CRMApplication/ClientAddress")]
        [TestMethod]
        public void ClientAddress_WithoutFloor_ShowError()
        {
            var permanentAddress = AccessExcelData.GetTestData<Address>("TestName", "SanityPermanent", "Address", CRMConstants.ApplicationXlsxFilename);
            var presentAddress = AccessExcelData.GetTestData<Address>("TestName", "Present", "Address", CRMConstants.ApplicationXlsxFilename);
            var correspondationAddress = AccessExcelData.GetTestData<Address>("TestName", "Correspondation", "Address", CRMConstants.ApplicationXlsxFilename);
            var addresses = new List<Address> { permanentAddress, presentAddress, correspondationAddress };

            foreach (var address in addresses)
            {
                var originFloor = address.Floor;
                address.Floor = string.Empty;

                this.addressPage.FillAllAddresses(addresses);
                this.addressPage.AssertCountMissingData(1);
                this.addressPage.AssertDisabledElement(this.addressPage.SaveAndContinueButton);

                address.Floor = originFloor;

                this.addressPage.RefresheWithYes();
            }
        }

        /// <summary>
        /// When the block number is not empty - the apartment number is required.
        /// </summary>
        [Owner("Boyko Andonov")]
        [Priority(2)]
        [TestCategory("CRMApplication")]
        [TestCategory("CRMApplication/ClientAddress")]
        [TestMethod]
        public void ClientAddress_WithoutApartment_ShowError()
        {
            var permanentAddress = AccessExcelData.GetTestData<Address>("TestName", "SanityPermanent", "Address", CRMConstants.ApplicationXlsxFilename);
            var presentAddress = AccessExcelData.GetTestData<Address>("TestName", "Present", "Address", CRMConstants.ApplicationXlsxFilename);
            var correspondationAddress = AccessExcelData.GetTestData<Address>("TestName", "Correspondation", "Address", CRMConstants.ApplicationXlsxFilename);
            var addresses = new List<Address> { permanentAddress, presentAddress, correspondationAddress };

            foreach (var address in addresses)
            {
                var originApartment = address.Apartment;
                address.Apartment = string.Empty;

                this.addressPage.FillAllAddresses(addresses);
                this.addressPage.AssertCountMissingData(1);
                this.addressPage.AssertDisabledElement(this.addressPage.SaveAndContinueButton);

                address.Apartment = originApartment;

                this.addressPage.RefresheWithYes();
            }
        }

        [Owner("Boyko Andonov")]
        [Priority(2)]
        [TestCategory("CRMApplication")]
        [TestCategory("CRMApplication/ClientAddress")]
        [TestMethod]
        public void ClientAddress_WithouHomeType_ShowError()
        {
            var permanentAddress = AccessExcelData.GetTestData<Address>("TestName", "SanityPermanent", "Address", CRMConstants.ApplicationXlsxFilename);
            var presentAddress = AccessExcelData.GetTestData<Address>("TestName", "Present", "Address", CRMConstants.ApplicationXlsxFilename);
            var correspondationAddress = AccessExcelData.GetTestData<Address>("TestName", "Correspondation", "Address", CRMConstants.ApplicationXlsxFilename);
            var addresses = new List<Address> { permanentAddress, presentAddress, correspondationAddress };

            foreach (var address in addresses)
            {
                address.HomeType = string.Empty;
            }

            this.addressPage.FillAllAddresses(addresses);
            this.addressPage.AssertCountMissingData(1);
            this.addressPage.AssertDisabledElement(this.addressPage.SaveAndContinueButton);
        }

        [Owner("Boyko Andonov")]
        [Priority(2)]
        [TestCategory("CRMApplication")]
        [TestCategory("CRMApplication/ClientAddress")]
        [TestMethod]
        public void ClientAddress_WithoutResidencePeriod_ShowError()
        {
            var permanentAddress = AccessExcelData.GetTestData<Address>("TestName", "SanityPermanent", "Address", CRMConstants.ApplicationXlsxFilename);
            var presentAddress = AccessExcelData.GetTestData<Address>("TestName", "Present", "Address", CRMConstants.ApplicationXlsxFilename);
            var correspondationAddress = AccessExcelData.GetTestData<Address>("TestName", "Correspondation", "Address", CRMConstants.ApplicationXlsxFilename);
            var addresses = new List<Address> { permanentAddress, presentAddress, correspondationAddress };

            foreach (var address in addresses)
            {
                address.ResidencePeriod = string.Empty;
            }

            this.addressPage.FillAllAddresses(addresses);
            this.addressPage.AssertCountMissingData(1);
            this.addressPage.AssertDisabledElement(this.addressPage.SaveAndContinueButton);                     
        }

        [Ignore]
        [Owner("Boyko Andonov")]
        [Priority(2)]
        [TestCategory("CRMApplication")]
        [TestCategory("CRMApplication/ClientAddress")]
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
